using System.Windows.Forms;
using System.Drawing;

namespace MiniPOS.Forms
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblUsuario;
        private Label lblPassword;
        private Label lblTitulo;
        private Label lblMensaje;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnEntrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblPassword = new Label();
            lblMensaje = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnEntrar = new Button();

            // form
            Text = "Login - MiniPOS";
            Size = new Size(400, 320);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // titulo
            lblTitulo.Text = "MiniPOS - Iniciar Sesion";
            lblTitulo.Location = new Point(80, 20);
            lblTitulo.Size = new Size(230, 25);
            lblTitulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // usuario
            lblUsuario.Text = "Usuario:";
            lblUsuario.Location = new Point(50, 70);
            lblUsuario.Size = new Size(60, 20);

            txtUsuario.Location = new Point(50, 92);
            txtUsuario.Size = new Size(280, 25);

            // password
            lblPassword.Text = "Contrasena:";
            lblPassword.Location = new Point(50, 128);
            lblPassword.Size = new Size(80, 20);

            txtPassword.Location = new Point(50, 150);
            txtPassword.Size = new Size(280, 25);
            txtPassword.PasswordChar = '*';

            btnEntrar.Text = "Iniciar Sesion";
            btnEntrar.Location = new Point(50, 195);
            btnEntrar.Size = new Size(280, 35);
            btnEntrar.Click += btnEntrar_Click;

            lblMensaje.Text = "";
            lblMensaje.Location = new Point(50, 240);
            lblMensaje.Size = new Size(280, 20);
            lblMensaje.ForeColor = Color.Red;

            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnEntrar);
            Controls.Add(lblMensaje);
        }
    }
}