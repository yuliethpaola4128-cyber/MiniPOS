using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using MiniPOS.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MiniPOS.Forms
{
    public partial class frmProductos : Form
    {
        private int idSeleccionado = 0;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT id_categoria, nombre FROM categorias ORDER BY nombre", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "nombre";
                cmbCategoria.ValueMember = "id_categoria";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT p.id_producto as ID, p.nombre as Producto, " +
                             "c.nombre as Categoria, p.precio as Precio, " +
                             "p.stock as Stock " +
                             "FROM productos p " +
                             "INNER JOIN categorias c ON p.id_categoria = c.id_categoria " +
                             "ORDER BY p.nombre";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;

                // colorear filas segun stock
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    int stock = Convert.ToInt32(fila.Cells["Stock"].Value);
                    if (stock < 5)
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    else
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                }

                lblTotal.Text = "Total: " + dt.Rows.Count + " productos";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();
                int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                int stock = Convert.ToInt32(txtStock.Text);

                if (idSeleccionado == 0)
                {
                    string sql = "INSERT INTO productos (nombre, id_categoria, precio, stock) VALUES (@n,@c,@p,@s)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@c", idCategoria);
                    cmd.Parameters.AddWithValue("@p", precio);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sql = "UPDATE productos SET nombre=@n, id_categoria=@c, precio=@p, stock=@s WHERE id_producto=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@c", idCategoria);
                    cmd.Parameters.AddWithValue("@p", precio);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                if (stock < 5)
                {
                    lblAdvertencia.Visible = true;
                    MessageBox.Show("Advertencia: este producto tiene stock bajo");
                }
                else
                {
                    lblAdvertencia.Visible = false;
                }

                conn.Close();
                MessageBox.Show("Producto guardado");
                LimpiarCampos();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            DialogResult resp = MessageBox.Show("Desea eliminar este producto?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = ConexionDB.ObtenerConexion();
                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM productos WHERE id_producto=@id", conn);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Producto eliminado");
                    LimpiarCampos();
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvProductos.DataSource;
                XLWorkbook wb = new XLWorkbook();
                var hoja = wb.Worksheets.Add("Productos");
                hoja.Cell(1, 1).InsertTable(dt);
                hoja.Columns().AdjustToContents();

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel|*.xlsx";
                dlg.FileName = "Productos";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dlg.FileName);
                    MessageBox.Show("Archivo exportado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message);
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            idSeleccionado = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ID"].Value);
            txtId.Text = idSeleccionado.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells["Producto"].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();

            int stock = Convert.ToInt32(txtStock.Text);
            lblAdvertencia.Visible = stock < 5;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT p.id_producto as ID, p.nombre as Producto, " +
                             "c.nombre as Categoria, p.precio as Precio, p.stock as Stock " +
                             "FROM productos p " +
                             "INNER JOIN categorias c ON p.id_categoria = c.id_categoria " +
                             "WHERE p.nombre LIKE @f";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@f", "%" + txtBuscar.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
                conn.Close();
            }
            catch { }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            lblAdvertencia.Visible = false;
        }
    }
}