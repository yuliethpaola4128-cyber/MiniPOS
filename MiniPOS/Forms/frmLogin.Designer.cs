namespace MiniPOS.Forms
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCentro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Label lblMensaje;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCentro = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIniciarSesion = new Button();
            lblMensaje = new Label();
            pnlCentro.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCentro
            // 
            pnlCentro.BackColor = Color.White;
            pnlCentro.Controls.Add(lblTitulo);
            pnlCentro.Controls.Add(lblSubtitulo);
            pnlCentro.Controls.Add(lblUsuario);
            pnlCentro.Controls.Add(txtUsuario);
            pnlCentro.Controls.Add(lblContrasena);
            pnlCentro.Controls.Add(txtContrasena);
            pnlCentro.Controls.Add(btnIniciarSesion);
            pnlCentro.Controls.Add(lblMensaje);
            pnlCentro.Location = new Point(290, 100);
            pnlCentro.Name = "pnlCentro";
            pnlCentro.Padding = new Padding(30);
            pnlCentro.Size = new Size(320, 390);
            pnlCentro.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(26, 82, 118);
            lblTitulo.Location = new Point(0, 54);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "MiniPOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Location = new Point(0, 84);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(320, 20);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Sistema de Inventario y Ventas";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.Location = new Point(30, 148);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(260, 20);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(30, 168);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(260, 30);
            txtUsuario.TabIndex = 4;
            txtUsuario.Text = "admin";
            // 
            // lblContrasena
            // 
            lblContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblContrasena.Location = new Point(30, 205);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(260, 20);
            lblContrasena.TabIndex = 5;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtContrasena.Location = new Point(30, 225);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '●';
            txtContrasena.Size = new Size(260, 30);
            txtContrasena.TabIndex = 6;
            txtContrasena.KeyDown += txtContrasena_KeyDown;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.FromArgb(26, 82, 118);
            btnIniciarSesion.Cursor = Cursors.Hand;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.Location = new Point(30, 268);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(260, 38);
            btnIniciarSesion.TabIndex = 7;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblMensaje.Location = new Point(30, 315);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(260, 35);
            lblMensaje.TabIndex = 8;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmLogin
            // 
            BackColor = Color.FromArgb(26, 82, 118);
            ClientSize = new Size(882, 553);
            Controls.Add(pnlCentro);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiniPOS — Iniciar Sesión";
            pnlCentro.ResumeLayout(false);
            pnlCentro.PerformLayout();
            ResumeLayout(false);
        }
    }
}