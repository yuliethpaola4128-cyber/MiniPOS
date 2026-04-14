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
            lblId = new Label();
            txtId = new TextBox();
            lblEmpresa = new Label();
            txtEmpresa = new TextBox();
            lblContacto = new Label();
            txtContacto = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblTelStatus = new Label();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblCorreoStatus = new Label();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            lblProductos = new Label();
            txtProductos = new TextBox();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnEliminar = new Button();
            grpLista = new GroupBox();
            txtBuscar = new TextBox();
            dgvProveedores = new DataGridView();
            lblTotal = new Label();
            btnExportar = new Button();
            grpDatos.SuspendLayout();
            grpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblId);
            grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(lblEmpresa);
            grpDatos.Controls.Add(txtEmpresa);
            grpDatos.Controls.Add(lblContacto);
            grpDatos.Controls.Add(txtContacto);
            grpDatos.Controls.Add(lblTelefono);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(lblTelStatus);
            grpDatos.Controls.Add(lblCorreo);
            grpDatos.Controls.Add(txtCorreo);
            grpDatos.Controls.Add(lblCorreoStatus);
            grpDatos.Controls.Add(lblDireccion);
            grpDatos.Controls.Add(txtDireccion);
            grpDatos.Controls.Add(lblProductos);
            grpDatos.Controls.Add(txtProductos);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Location = new Point(10, 10);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(350, 560);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del Proveedor";
            // 
            // lblId
            // 
            lblId.Location = new Point(15, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(25, 20);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(15, 50);
            txtId.Name = "txtId";
            txtId.Size = new Size(310, 27);
            txtId.TabIndex = 1;
            // 
            // lblEmpresa
            // 
            lblEmpresa.Location = new Point(15, 85);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(90, 20);
            lblEmpresa.TabIndex = 2;
            lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(15, 105);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(310, 27);
            txtEmpresa.TabIndex = 3;
            // 
            // lblContacto
            // 
            lblContacto.Location = new Point(15, 140);
            lblContacto.Name = "lblContacto";
            lblContacto.Size = new Size(76, 20);
            lblContacto.TabIndex = 4;
            lblContacto.Text = "Contacto:";
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(15, 160);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(310, 27);
            txtContacto.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(15, 195);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(98, 20);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(15, 215);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(310, 27);
            txtTelefono.TabIndex = 7;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // lblTelStatus
            // 
            lblTelStatus.Location = new Point(15, 243);
            lblTelStatus.Name = "lblTelStatus";
            lblTelStatus.Size = new Size(310, 18);
            lblTelStatus.TabIndex = 8;
            // 
            // lblCorreo
            // 
            lblCorreo.Location = new Point(15, 270);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(76, 20);
            lblCorreo.TabIndex = 9;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(15, 290);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(310, 27);
            txtCorreo.TabIndex = 10;
            txtCorreo.TextChanged += txtCorreo_TextChanged;
            // 
            // lblCorreoStatus
            // 
            lblCorreoStatus.Location = new Point(15, 318);
            lblCorreoStatus.Name = "lblCorreoStatus";
            lblCorreoStatus.Size = new Size(310, 18);
            lblCorreoStatus.TabIndex = 11;
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(15, 345);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(134, 20);
            lblDireccion.TabIndex = 12;
            lblDireccion.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(15, 365);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(310, 27);
            txtDireccion.TabIndex = 13;
            // 
            // lblProductos
            // 
            lblProductos.Location = new Point(15, 400);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(180, 20);
            lblProductos.TabIndex = 14;
            lblProductos.Text = "Productos que suministra:";
            // 
            // txtProductos
            // 
            txtProductos.Location = new Point(15, 420);
            txtProductos.Name = "txtProductos";
            txtProductos.Size = new Size(310, 27);
            txtProductos.TabIndex = 15;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(15, 465);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(115, 465);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 17;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(215, 465);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 18;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // grpLista
            // 
            grpLista.Controls.Add(txtBuscar);
            grpLista.Controls.Add(dgvProveedores);
            grpLista.Controls.Add(lblTotal);
            grpLista.Controls.Add(btnExportar);
            grpLista.Location = new Point(370, 10);
            grpLista.Name = "grpLista";
            grpLista.Size = new Size(655, 560);
            grpLista.TabIndex = 1;
            grpLista.TabStop = false;
            grpLista.Text = "Lista de Proveedores";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 25);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por empresa o contacto";
            txtBuscar.Size = new Size(615, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.ColumnHeadersHeight = 29;
            dgvProveedores.Location = new Point(15, 60);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(620, 430);
            dgvProveedores.TabIndex = 1;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(15, 500);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(250, 20);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: 0 proveedores";
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(460, 496);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(150, 28);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.Click += btnExportar_Click;
            // 
            // frmProveedores
            // 
            ClientSize = new Size(1032, 573);
            Controls.Add(grpDatos);
            Controls.Add(grpLista);
            Name = "frmProveedores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Proveedores";
            Load += frmProveedores_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpLista.ResumeLayout(false);
            grpLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
        }
    }
}