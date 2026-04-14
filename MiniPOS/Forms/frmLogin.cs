using System;
using System.Drawing;
using System.Windows.Forms;
using MiniPOS.Database;
using MySql.Data.MySqlClient;

namespace MiniPOS.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (usuario == "" || password == "")
            {
                lblMensaje.Text = "Por favor llene todos los campos";
                return;
            }

            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT nombre_completo FROM usuarios " +
                             "WHERE nombre_usuario=@u AND contrasena=@p AND activo=1";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@p", password);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    string nombre = resultado.ToString();
                    frmPrincipal ventana = new frmPrincipal(nombre);
                    Hide();
                    ventana.ShowDialog();
                    Close();
                }
                else
                {
                    lblMensaje.Text = "Usuario o contrasena incorrectos";
                    txtContrasena.Clear();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnIniciarSesion_Click(sender, e);
        }
    }
}