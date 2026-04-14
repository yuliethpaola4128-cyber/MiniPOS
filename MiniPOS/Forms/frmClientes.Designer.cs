using System.Drawing;
using System.Windows.Forms;

namespace MiniPOS.Forms
{
    partial class frmClientes
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpDatos;
        private GroupBox grpLista;
        private Label lblId;
        private Label lblNombre;
        private Label lblTelefono;
        private Label lblTelStatus;
        private Label lblCorreo;
        private Label lblCorreoStatus;
        private Label lblDireccion;
        private Label lblTotal;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private TextBox txtBuscar;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnExportar;
        private DataGridView dgvClientes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpDatos = new GroupBox();
            grpLista = new GroupBox();
            lblId = new Label();
            lblNombre = new Label();
            lblTelefono = new Label();
            lblTelStatus = new Label();
            lblCorreo = new Label();
            lblCorreoStatus = new Label();
            lblDireccion = new Label();
            lblTotal = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            txtBuscar = new TextBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            btnExportar = new Button();
            dgvClientes = new DataGridView();

            // form
            Text = "Clientes";
            Size = new Size(1000, 560);
            StartPosition = FormStartPosition.CenterParent;
            Load += frmClientes_Load;

            // grupo datos
            grpDatos.Text = "Datos del Cliente";
            grpDatos.Location = new Point(10, 10);
            grpDatos.Size = new Size(350, 500);

            lblId.Text = "ID:";
            lblId.Location = new Point(15, 30);
            lblId.Size = new Size(25, 20);

            txtId.Location = new Point(15, 50);
            txtId.Size = new Size(310, 25);
            txtId.Enabled = false;

            lblNombre.Text = "Nombre completo:";
            lblNombre.Location = new Point(15, 85);
            lblNombre.Size = new Size(110, 20);

            txtNombre.Location = new Point(15, 105);
            txtNombre.Size = new Size(310, 25);

            lblTelefono.Text = "Telefono (ej: 9999-9999):";
            lblTelefono.Location = new Point(15, 140);
            lblTelefono.Size = new Size(180, 20);

            txtTelefono.Location = new Point(15, 160);
            txtTelefono.Size = new Size(310, 25);
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;

            lblTelStatus.Location = new Point(15, 188);
            lblTelStatus.Size = new Size(310, 18);
            lblTelStatus.ForeColor = Color.Gray;

            lblCorreo.Text = "Correo electronico:";
            lblCorreo.Location = new Point(15, 215);
            lblCorreo.Size = new Size(130, 20);

            txtCorreo.Location = new Point(15, 235);
            txtCorreo.Size = new Size(310, 25);
            txtCorreo.TextChanged += txtCorreo_TextChanged;

            lblCorreoStatus.Location = new Point(15, 263);
            lblCorreoStatus.Size = new Size(310, 18);
            lblCorreoStatus.ForeColor = Color.Gray;

            lblDireccion.Text = "Direccion:";
            lblDireccion.Location = new Point(15, 290);
            lblDireccion.Size = new Size(70, 20);

            txtDireccion.Location = new Point(15, 310);
            txtDireccion.Size = new Size(310, 25);

            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(15, 355);
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.Click += btnGuardar_Click;

            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new Point(115, 355);
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.Click += btnNuevo_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(215, 355);
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Click += btnEliminar_Click;

            grpDatos.Controls.Add(lblId);
            grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblTelefono);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(lblTelStatus);
            grpDatos.Controls.Add(lblCorreo);
            grpDatos.Controls.Add(txtCorreo);
            grpDatos.Controls.Add(lblCorreoStatus);
            grpDatos.Controls.Add(lblDireccion);
            grpDatos.Controls.Add(txtDireccion);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnEliminar);

            // grupo lista
            grpLista.Text = "Lista de Clientes";
            grpLista.Location = new Point(370, 10);
            grpLista.Size = new Size(600, 500);

            txtBuscar.Location = new Point(15, 25);
            txtBuscar.Size = new Size(560, 25);
            txtBuscar.PlaceholderText = "Buscar por nombre, telefono o correo...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            dgvClientes.Location = new Point(15, 60);
            dgvClientes.Size = new Size(565, 370);
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;

            lblTotal.Location = new Point(15, 440);
            lblTotal.Size = new Size(250, 20);
            lblTotal.Text = "Total: 0 clientes";

            btnExportar.Text = "Exportar a Excel";
            btnExportar.Location = new Point(410, 436);
            btnExportar.Size = new Size(150, 28);
            btnExportar.Click += btnExportar_Click;

            grpLista.Controls.Add(txtBuscar);
            grpLista.Controls.Add(dgvClientes);
            grpLista.Controls.Add(lblTotal);
            grpLista.Controls.Add(btnExportar);

            Controls.Add(grpDatos);
            Controls.Add(grpLista);
        }
    }
}