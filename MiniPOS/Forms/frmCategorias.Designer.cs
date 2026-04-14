using System.Windows.Forms;
using System.Drawing;

namespace MiniPOS.Forms
{
    partial class frmCategorias
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblId;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblTotal;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtBuscar;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private DataGridView dgvCategorias;
        private GroupBox grpDatos;
        private GroupBox grpLista;

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
            lblDescripcion = new Label();
            lblTotal = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtBuscar = new TextBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            dgvCategorias = new DataGridView();

            // form
            Text = "Categorias";
            Size = new Size(900, 500);
            StartPosition = FormStartPosition.CenterParent;
            Load += frmCategorias_Load;

            // grupo datos
            grpDatos.Text = "Datos de la Categoria";
            grpDatos.Location = new Point(10, 10);
            grpDatos.Size = new Size(340, 430);

            lblId.Text = "ID:";
            lblId.Location = new Point(15, 30);
            lblId.Size = new Size(30, 20);

            txtId.Location = new Point(15, 50);
            txtId.Size = new Size(300, 25);
            txtId.Enabled = false;

            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(15, 85);
            lblNombre.Size = new Size(60, 20);

            txtNombre.Location = new Point(15, 105);
            txtNombre.Size = new Size(300, 25);

            lblDescripcion.Text = "Descripcion:";
            lblDescripcion.Location = new Point(15, 140);
            lblDescripcion.Size = new Size(80, 20);

            txtDescripcion.Location = new Point(15, 160);
            txtDescripcion.Size = new Size(300, 80);
            txtDescripcion.Multiline = true;

            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(15, 260);
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.Click += btnGuardar_Click;

            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new Point(115, 260);
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.Click += btnNuevo_Click;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(215, 260);
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Click += btnEliminar_Click;

            grpDatos.Controls.Add(lblId);
            grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblDescripcion);
            grpDatos.Controls.Add(txtDescripcion);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnNuevo);
            grpDatos.Controls.Add(btnEliminar);

            // grupo lista
            grpLista.Text = "Lista de Categorias";
            grpLista.Location = new Point(360, 10);
            grpLista.Size = new Size(510, 430);

            txtBuscar.Location = new Point(15, 25);
            txtBuscar.Size = new Size(470, 25);
            txtBuscar.PlaceholderText = "Buscar...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            dgvCategorias.Location = new Point(15, 60);
            dgvCategorias.Size = new Size(470, 320);
            dgvCategorias.ReadOnly = true;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;

            lblTotal.Location = new Point(15, 390);
            lblTotal.Size = new Size(300, 20);
            lblTotal.Text = "Total: 0 categorias";

            grpLista.Controls.Add(txtBuscar);
            grpLista.Controls.Add(dgvCategorias);
            grpLista.Controls.Add(lblTotal);

            Controls.Add(grpDatos);
            Controls.Add(grpLista);
        }
    }
}