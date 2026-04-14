using DocumentFormat.OpenXml.Wordprocessing;
using MiniPOS.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MiniPOS.Forms
{
    public partial class frmCategorias : Form
    {
        private int idSeleccionado = 0;

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT c.id_categoria as ID, c.nombre as Nombre, " +
                             "c.descripcion as Descripcion, COUNT(p.id_producto) as Productos " +
                             "FROM categorias c " +
                             "LEFT JOIN productos p ON c.id_categoria = p.id_categoria " +
                             "GROUP BY c.id_categoria " +
                             "ORDER BY c.nombre";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCategorias.DataSource = dt;
                lblTotal.Text = "Total: " + dt.Rows.Count + " categorias";

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

                if (idSeleccionado == 0)
                {
                    string sql = "INSERT INTO categorias (nombre, descripcion) VALUES (@n, @d)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@d", txtDescripcion.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoria guardada");
                }
                else
                {
                    string sql = "UPDATE categorias SET nombre=@n, descripcion=@d WHERE id_categoria=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@d", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoria actualizada");
                }

                conn.Close();
                LimpiarCampos();
                CargarCategorias();
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
                MessageBox.Show("Seleccione una categoria");
                return;
            }

            DialogResult resp = MessageBox.Show("Desea eliminar esta categoria?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = ConexionDB.ObtenerConexion();

                    MySqlCommand cmdVerificar = new MySqlCommand(
                        "SELECT COUNT(*) FROM productos WHERE id_categoria=@id", conn);
                    cmdVerificar.Parameters.AddWithValue("@id", idSeleccionado);
                    int cantidad = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (cantidad > 0)
                    {
                        MessageBox.Show("No se puede eliminar, tiene " + cantidad + " productos asociados");
                        return;
                    }

                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM categorias WHERE id_categoria=@id", conn);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Categoria eliminada");
                    LimpiarCampos();
                    CargarCategorias();
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

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            idSeleccionado = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["ID"].Value);
            txtId.Text = idSeleccionado.ToString();
            txtNombre.Text = dgvCategorias.CurrentRow.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = dgvCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT c.id_categoria as ID, c.nombre as Nombre, " +
                             "c.descripcion as Descripcion, COUNT(p.id_producto) as Productos " +
                             "FROM categorias c " +
                             "LEFT JOIN productos p ON c.id_categoria = p.id_categoria " +
                             "WHERE c.nombre LIKE @f " +
                             "GROUP BY c.id_categoria";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@f", "%" + txtBuscar.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategorias.DataSource = dt;

                conn.Close();
            }
            catch { }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
    }
}