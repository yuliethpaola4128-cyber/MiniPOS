using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using MiniPOS.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace MiniPOS.Forms
{
    public partial class frmClientes : Form
    {
        private int idSeleccionado = 0;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT id_cliente as ID, nombre_completo as Nombre, " +
                             "telefono as Telefono, correo as Correo, direccion as Direccion " +
                             "FROM clientes ORDER BY nombre_completo";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;
                lblTotal.Text = "Total: " + dt.Rows.Count + " clientes";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string tel = txtTelefono.Text;
            bool valido = Regex.IsMatch(tel, @"^\d{4}-\d{4}$");

            if (valido)
            {
                lblTelStatus.Text = "Formato valido";
                lblTelStatus.ForeColor = Color.Green;
            }
            else
            {
                lblTelStatus.Text = "Formato invalido (ej: 9999-9999)";
                lblTelStatus.ForeColor = Color.Red;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            bool valido = correo.Contains("@") && correo.Contains(".");

            if (valido)
            {
                lblCorreoStatus.Text = "Correo valido";
                lblCorreoStatus.ForeColor = Color.Green;
            }
            else
            {
                lblCorreoStatus.Text = "Correo invalido";
                lblCorreoStatus.ForeColor = Color.Red;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            bool telOk = Regex.IsMatch(txtTelefono.Text, @"^\d{4}-\d{4}$");
            bool correoOk = txtCorreo.Text.Contains("@") && txtCorreo.Text.Contains(".");

            if (!telOk || !correoOk)
            {
                MessageBox.Show("Corrija el telefono o el correo antes de guardar");
                return;
            }

            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                if (idSeleccionado == 0)
                {
                    string sql = "INSERT INTO clientes (nombre_completo, telefono, correo, direccion) " +
                                 "VALUES (@n,@t,@c,@d)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@c", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sql = "UPDATE clientes SET nombre_completo=@n, telefono=@t, " +
                                 "correo=@c, direccion=@d WHERE id_cliente=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@c", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Cliente guardado");
                LimpiarCampos();
                CargarClientes();
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
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            DialogResult resp = MessageBox.Show("Desea eliminar este cliente?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = ConexionDB.ObtenerConexion();
                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM clientes WHERE id_cliente=@id", conn);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cliente eliminado");
                    LimpiarCampos();
                    CargarClientes();
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
                DataTable dt = (DataTable)dgvClientes.DataSource;
                XLWorkbook wb = new XLWorkbook();
                var hoja = wb.Worksheets.Add("Clientes");
                hoja.Cell(1, 1).InsertTable(dt);
                hoja.Columns().AdjustToContents();

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel|*.xlsx";
                dlg.FileName = "Clientes";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(dlg.FileName);
                    MessageBox.Show("Exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            idSeleccionado = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);
            txtId.Text = idSeleccionado.ToString();
            txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = dgvClientes.CurrentRow.Cells["Correo"].Value.ToString();
            txtDireccion.Text = dgvClientes.CurrentRow.Cells["Direccion"].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT id_cliente as ID, nombre_completo as Nombre, " +
                             "telefono as Telefono, correo as Correo, direccion as Direccion " +
                             "FROM clientes " +
                             "WHERE nombre_completo LIKE @f OR telefono LIKE @f OR correo LIKE @f";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@f", "%" + txtBuscar.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClientes.DataSource = dt;
                conn.Close();
            }
            catch { }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            lblTelStatus.Text = "";
            lblCorreoStatus.Text = "";
        }
    }
}