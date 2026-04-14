using System;
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (usuario == "" || password == "")
            {
                lblMensaje.Text = "Por favor llene todos los campos";
                return;
            }

            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT nombre_completo FROM usuarios WHERE nombre_usuario=@u AND contrasena=@p";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@p", password);

                object resultado = cmd.ExecuteScalar();

                if (resultado != null)
                {
                    string nombre = resultado.ToString();
                    frmPrincipal ventanaPrincipal = new frmPrincipal(nombre);
                    Hide();
                    ventanaPrincipal.ShowDialog();
                    Close();
                }
                else
                {
                    lblMensaje.Text = "Usuario o contrasena incorrectos";
                    txtPassword.Clear();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}