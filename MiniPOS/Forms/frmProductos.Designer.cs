using System.Drawing;
using System.Windows.Forms;

namespace MiniPOS.Forms
{
    partial class frmProductos
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpDatos;
        private GroupBox grpLista;
        private Label lblId;
        private Label lblNombre;
        private Label lblCategoria;
        private Label lblPrecio;
        private Label lblStock;
        private Label lblAdvertencia;
        private Label lblTotal;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtBuscar;
        private ComboBox cmbCategoria;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnExportar;
        private DataGridView dgvProductos;

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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblAdvertencia = new Label();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnEliminar = new Button();
            grpLista = new GroupBox();
            txtBuscar = new TextBox();
            dgvProductos = new DataGridView();
            lblTotal = new Label();
            btnExportar = new Button();
            grpDatos.SuspendLayout();
            grpLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(lblId);
            grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblCategoria);
            grpDatos.Controls.Add(cmbCategoria);
            grpDatos.Controls.Add(lblPrecio);
            grpDatos.Controls.Add(txtPrecio);
            grpDatos.Controls.Add(lblStock);
            grpDatos.Controls.Add(txtStock);
            grpDatos.Controls.Add(lblAdvertencia);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Location = new Point(10, 10);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(340, 460);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del Producto";
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
            txtId.Size = new Size(300, 27);
            txtId.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(15, 85);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(90, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(15, 105);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 27);
            txtNombre.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.Location = new Point(15, 140);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(162, 20);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoria:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new Point(15, 160);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(300, 28);
            cmbCategoria.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.Location = new Point(15, 195);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(90, 20);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(15, 215);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(300, 27);
            txtPrecio.TabIndex = 7;
            // 
            // lblStock
            // 
            lblStock.Location = new Point(15, 250);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(106, 20);
            lblStock.TabIndex = 8;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(15, 270);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(300, 27);
            txtStock.TabIndex = 9;
            // 
            // lblAdvertencia
            // 
            lblAdvertencia.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblAdvertencia.ForeColor = Color.Red;
            lblAdvertencia.Location = new Point(15, 305);
            lblAdvertencia.Name = "lblAdvertencia";
            lblAdvertencia.Size = new Size(300, 25);
            lblAdvertencia.TabIndex = 10;
            lblAdvertencia.Text = "ADVERTENCIA: Stock bajo";
            lblAdvertencia.Visible = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(15, 340);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(115, 340);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(215, 340);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // grpLista
            // 
            grpLista.Controls.Add(txtBuscar);
            grpLista.Controls.Add(dgvProductos);
            grpLista.Controls.Add(lblTotal);
            grpLista.Controls.Add(btnExportar);
            grpLista.Location = new Point(360, 10);
            grpLista.Name = "grpLista";
            grpLista.Size = new Size(610, 460);
            grpLista.TabIndex = 1;
            grpLista.TabStop = false;
            grpLista.Text = "Lista de Productos";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 25);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.Size = new Size(470, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(15, 60);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(575, 330);
            dgvProductos.TabIndex = 1;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(15, 400);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(250, 20);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: 0 productos";
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(420, 396);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(150, 28);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.Click += btnExportar_Click;
            // 
            // frmProductos
            // 
            ClientSize = new Size(982, 483);
            Controls.Add(grpDatos);
            Controls.Add(grpLista);
            Name = "frmProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Productos";
            Load += frmProductos_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpLista.ResumeLayout(false);
            grpLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }
    }
}