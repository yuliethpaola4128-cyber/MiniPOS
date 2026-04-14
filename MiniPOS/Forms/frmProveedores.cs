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
    public partial class frmProveedores : Form
    {
        private int idSeleccionado = 0;

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT id_proveedor as ID, nombre_empresa as Empresa, " +
                             "nombre_contacto as Contacto, telefono as Telefono, " +
                             "correo as Correo, productos_suministra as Productos " +
                             "FROM proveedores ORDER BY nombre_empresa";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProveedores.DataSource = dt;
                lblTotal.Text = "Total: " + dt.Rows.Count + " proveedores";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            bool valido = System.Text.RegularExpressions.Regex.IsMatch(
                txtTelefono.Text, @"^\d{4}-\d{4}$");

            lblTelStatus.Text = valido ? "Formato valido" : "Formato invalido";
         
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            bool valido = txtCorreo.Text.Contains("@") && txtCorreo.Text.Contains(".");
            lblCorreoStatus.Text = valido ? "Correo valido" : "Correo invalido";
       
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == "")
            {
                MessageBox.Show("El nombre de la empresa es obligatorio");
                return;
            }

            bool telOk = System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d{4}-\d{4}$");
            bool correoOk = txtCorreo.Text.Contains("@") && txtCorreo.Text.Contains(".");

            if (!telOk || !correoOk)
            {
                MessageBox.Show("Corrija el telefono o el correo");
                return;
            }

            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                if (idSeleccionado == 0)
                {
                    string sql = "INSERT INTO proveedores (nombre_empresa, nombre_contacto, telefono, correo, direccion, productos_suministra) " +
                                 "VALUES (@e,@c,@t,@m,@d,@p)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@e", txtEmpresa.Text);
                    cmd.Parameters.AddWithValue("@c", txtContacto.Text);
                    cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@m", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@p", txtProductos.Text);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string sql = "UPDATE proveedores SET nombre_empresa=@e, nombre_contacto=@c, " +
                                 "telefono=@t, correo=@m, direccion=@d, productos_suministra=@p " +
                                 "WHERE id_proveedor=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@e", txtEmpresa.Text);
                    cmd.Parameters.AddWithValue("@c", txtContacto.Text);
                    cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@m", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@p", txtProductos.Text);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                MessageBox.Show("Proveedor guardado");
                LimpiarCampos();
                CargarProveedores();
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
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            DialogResult resp = MessageBox.Show("Desea eliminar este proveedor?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resp == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn = ConexionDB.ObtenerConexion();
                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM proveedores WHERE id_proveedor=@id", conn);
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Proveedor eliminado");
                    LimpiarCampos();
                    CargarProveedores();
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
                DataTable dt = (DataTable)dgvProveedores.DataSource;
                XLWorkbook wb = new XLWorkbook();
                var hoja = wb.Worksheets.Add("Proveedores");
                hoja.Cell(1, 1).InsertTable(dt);
                hoja.Columns().AdjustToContents();

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel|*.xlsx";
                dlg.FileName = "Proveedores";

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

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;

            idSeleccionado = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["ID"].Value);
            txtId.Text = idSeleccionado.ToString();
            txtEmpresa.Text = dgvProveedores.CurrentRow.Cells["Empresa"].Value.ToString();
            txtContacto.Text = dgvProveedores.CurrentRow.Cells["Contacto"].Value.ToString();
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = dgvProveedores.CurrentRow.Cells["Correo"].Value.ToString();
            txtProductos.Text = dgvProveedores.CurrentRow.Cells["Productos"].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT id_proveedor as ID, nombre_empresa as Empresa, " +
                             "nombre_contacto as Contacto, telefono as Telefono, " +
                             "correo as Correo, productos_suministra as Productos " +
                             "FROM proveedores " +
                             "WHERE nombre_empresa LIKE @f OR nombre_contacto LIKE @f";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@f", "%" + txtBuscar.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProveedores.DataSource = dt;
                conn.Close();
            }
            catch { }
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtId.Text = "";
            txtEmpresa.Text = "";
            txtContacto.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtProductos.Text = "";
            lblTelStatus.Text = "";
            lblCorreoStatus.Text = "";
        }
    }
}