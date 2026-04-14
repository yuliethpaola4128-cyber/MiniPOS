using System.Drawing;
using System.Windows.Forms;

namespace MiniPOS.Forms
{
    partial class frmProveedores
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpDatos;
        private GroupBox grpLista;
        private Label lblId;
        private Label lblEmpresa;
        private Label lblContacto;
        private Label lblTelefono;
        private Label lblTelStatus;
        private Label lblCorreo;
        private Label lblCorreoStatus;
        private Label lblDireccion;
        private Label lblProductos;
        private Label lblTotal;
        private TextBox txtId;
        private TextBox txtEmpresa;
        private TextBox txtContacto;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private TextBox txtProductos;
        private TextBox txtBuscar;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnExportar;
        private DataGridView dgvProveedores;

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
            lblEmpresa = new Label();
            lblContacto = new Label();
            lblTelefono = new Label();
            lblTelStatus = new Label();
            lblCorreo = new Label();
            lblCorreoStatus = new Label();
            lblDireccion = new Label();
            lblProductos = new Label();
            lblTotal = new Label();
            txtId = new TextBox();
            txtEmpresa = new TextBox();
            txtContacto = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            txtProductos = new TextBox();
            txtBuscar = new TextBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            btnExportar = new Button();
            dgvProveedores = new DataGridView();

            // form
            Text = "Proveedores";
            Size = new Size(1050, 620);
            StartPosition = FormStartPosition.CenterParent;
            Load += frmProveedores_Load;

            // grupo datos
            grpDatos.Text = "Datos del Proveedor";
            grpDatos.Location = new Point(10, 10);
            grpDatos.Size = new Size(350, 560);

            int y = 30;
            int sep = 55;

            lblId.Text = "ID:"; lblId.Location = new Point(15, y); lblId.Size = new Size(25, 20);
            y += 20;
            txtId.Location = new Point(15, y); txtId.Size = new Size(310, 25); txtId.Enabled = false;
            y += sep;

            lblEmpresa.Text = "Empresa:"; lblEmpresa.Location = new Point(15, y); lblEmpresa.Size = new Size(65, 20);
            y += 20;
            txtEmpresa.Location = new Point(15, y); txtEmpresa.Size = new Size(310, 25);
            y += sep;

            lblContacto.Text = "Contacto:"; lblContacto.Location = new Point(15, y); lblContacto.Size = new Size(65, 20);
            y += 20;
            txtContacto.Location = new Point(15, y); txtContacto.Size = new Size(310, 25);
            y += sep;

            lblTelefono.Text = "Telefono:"; lblTelefono.Location = new Point(15, y); lblTelefono.Size = new Size(65, 20);
            y += 20;
            txtTelefono.Location = new Point(15, y); txtTelefono.Size = new Size(310, 25);
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            y += 28;
            lblTelStatus.Location = new Point(15, y); lblTelStatus.Size = new Size(310, 18);
            y += 28;

            lblCorreo.Text = "Correo:"; lblCorreo.Location = new Point(15, y); lblCorreo.Size = new Size(55, 20);
            y += 20;
            txtCorreo.Location = new Point(15, y); txtCorreo.Size = new Size(310, 25);
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            y += 28;
            lblCorreoStatus.Location = new Point(15, y); lblCorreoStatus.Size = new Size(310, 18);
            y += 28;

            lblDireccion.Text = "Direccion:"; lblDireccion.Location = new Point(15, y); lblDireccion.Size = new Size(70, 20);
            y += 20;
            txtDireccion.Location = new Point(15, y); txtDireccion.Size = new Size(310, 25);
            y += sep;

            lblProductos.Text = "Productos que suministra:"; lblProductos.Location = new Point(15, y); lblProductos.Size = new Size(180, 20);
            y += 20;
            txtProductos.Location = new Point(15, y); txtProductos.Size = new Size(310, 25);
            y += 40;

            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(15, y);
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.Click += btnGuardar_Click;

            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new Point(115, y);
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.Click += btnNuevo_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(215, y);
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Click += btnEliminar_Click;

            grpDatos.Controls.Add(lblId); grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(lblEmpresa); grpDatos.Controls.Add(txtEmpresa);
            grpDatos.Controls.Add(lblContacto); grpDatos.Controls.Add(txtContacto);
            grpDatos.Controls.Add(lblTelefono); grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(lblTelStatus);
            grpDatos.Controls.Add(lblCorreo); grpDatos.Controls.Add(txtCorreo);
            grpDatos.Controls.Add(lblCorreoStatus);
            grpDatos.Controls.Add(lblDireccion); grpDatos.Controls.Add(txtDireccion);
            grpDatos.Controls.Add(lblProductos); grpDatos.Controls.Add(txtProductos);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnEliminar);

            // grupo lista
            grpLista.Text = "Lista de Proveedores";
            grpLista.Location = new Point(370, 10);
            grpLista.Size = new Size(655, 560);

            txtBuscar.Location = new Point(15, 25);
            txtBuscar.Size = new Size(615, 25);
            txtBuscar.PlaceholderText = "Buscar por empresa o contacto...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            dgvProveedores.Location = new Point(15, 60);
            dgvProveedores.Size = new Size(620, 430);
            dgvProveedores.ReadOnly = true;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;

            lblTotal.Location = new Point(15, 500);
            lblTotal.Size = new Size(250, 20);
            lblTotal.Text = "Total: 0 proveedores";

            btnExportar.Text = "Exportar a Excel";
            btnExportar.Location = new Point(460, 496);
            btnExportar.Size = new Size(150, 28);
            btnExportar.Click += btnExportar_Click;

            grpLista.Controls.Add(txtBuscar);
            grpLista.Controls.Add(dgvProveedores);
            grpLista.Controls.Add(lblTotal);
            grpLista.Controls.Add(btnExportar);

            Controls.Add(grpDatos);
            Controls.Add(grpLista);
        }
    }
}