using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartArea = System.Windows.Forms.DataVisualization.Charting.ChartArea;

namespace MiniPOS.Forms
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMenu;
        private Button btnInicio;
        private Button btnProductos;
        private Button btnCategorias;
        private Button btnClientes;
        private Button btnProveedores;
        private Button btnSalir;
        private Label lblBienvenido;
        private Label lblFecha;
        private Panel pnlIndicadores;
        private Label lblTotalProductos;
        private Label lblSubProductos;
        private Label lblTotalClientes;
        private Label lblSubClientes;
        private Label lblTotalProveedores;
        private Label lblSubProveedores;
        private Label lblTotalCategorias;
        private Label lblSubCategorias;
        private Label lblStockBajo;
        private Label lblSubStock;
        private GroupBox grpStockBajo;
        private DataGridView dgvStockBajo;
        private GroupBox grpProveedores;
        private DataGridView dgvProveedores;
        private GroupBox grpGrafica;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategorias;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            btnInicio = new Button();
            btnProductos = new Button();
            btnCategorias = new Button();
            btnClientes = new Button();
            btnProveedores = new Button();
            btnSalir = new Button();
            lblBienvenido = new Label();
            lblFecha = new Label();
            pnlIndicadores = new Panel();
            lblTotalProductos = new Label();
            lblSubProductos = new Label();
            lblTotalClientes = new Label();
            lblSubClientes = new Label();
            lblTotalProveedores = new Label();
            lblSubProveedores = new Label();
            lblTotalCategorias = new Label();
            lblSubCategorias = new Label();
            lblStockBajo = new Label();
            lblSubStock = new Label();
            grpStockBajo = new GroupBox();
            dgvStockBajo = new DataGridView();
            grpProveedores = new GroupBox();
            dgvProveedores = new DataGridView();
            grpGrafica = new GroupBox();
            chartCategorias = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // form
            Text = "MiniPOS - Panel Principal";
            Size = new Size(1150, 750);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 245, 245);
            Load += frmPrincipal_Load;
            FormClosed += frmPrincipal_FormClosed;

            // menu superior azul con botones de navegacion
            pnlMenu.Dock = DockStyle.Top;
            pnlMenu.Height = 44;
            pnlMenu.BackColor = Color.FromArgb(26, 82, 118);

            btnInicio.Text = "Inicio";
            btnInicio.Location = new Point(5, 7);
            btnInicio.Size = new Size(100, 30);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.ForeColor = Color.White;
            btnInicio.BackColor = Color.Transparent;
            btnInicio.Font = new Font("Segoe UI", 9);
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatAppearance.BorderSize = 0;

            btnProductos.Text = "Productos";
            btnProductos.Location = new Point(110, 7);
            btnProductos.Size = new Size(100, 30);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.ForeColor = Color.White;
            btnProductos.BackColor = Color.Transparent;
            btnProductos.Font = new Font("Segoe UI", 9);
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.Click += btnProductos_Click;

            btnCategorias.Text = "Categorias";
            btnCategorias.Location = new Point(215, 7);
            btnCategorias.Size = new Size(100, 30);
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.ForeColor = Color.White;
            btnCategorias.BackColor = Color.Transparent;
            btnCategorias.Font = new Font("Segoe UI", 9);
            btnCategorias.Cursor = Cursors.Hand;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.Click += btnCategorias_Click;

            btnClientes.Text = "Clientes";
            btnClientes.Location = new Point(320, 7);
            btnClientes.Size = new Size(100, 30);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.ForeColor = Color.White;
            btnClientes.BackColor = Color.Transparent;
            btnClientes.Font = new Font("Segoe UI", 9);
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.Click += btnClientes_Click;

            btnProveedores.Text = "Proveedores";
            btnProveedores.Location = new Point(425, 7);
            btnProveedores.Size = new Size(100, 30);
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.ForeColor = Color.White;
            btnProveedores.BackColor = Color.Transparent;
            btnProveedores.Font = new Font("Segoe UI", 9);
            btnProveedores.Cursor = Cursors.Hand;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.Click += btnProveedores_Click;

            btnSalir.Text = "Salir";
            btnSalir.Location = new Point(530, 7);
            btnSalir.Size = new Size(100, 30);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Font = new Font("Segoe UI", 9);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Click += btnSalir_Click;

            pnlMenu.Controls.Add(btnInicio);
            pnlMenu.Controls.Add(btnProductos);
            pnlMenu.Controls.Add(btnCategorias);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(btnProveedores);
            pnlMenu.Controls.Add(btnSalir);

            // bienvenido y fecha
            lblBienvenido.Location = new Point(12, 52);
            lblBienvenido.Size = new Size(600, 24);
            lblBienvenido.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblBienvenido.ForeColor = Color.FromArgb(26, 82, 118);

            lblFecha.Location = new Point(12, 74);
            lblFecha.Size = new Size(500, 18);
            lblFecha.Font = new Font("Segoe UI", 9);
            lblFecha.ForeColor = Color.Gray;

            // panel de indicadores numericos
            pnlIndicadores.Location = new Point(12, 96);
            pnlIndicadores.Size = new Size(1110, 95);
            pnlIndicadores.BackColor = Color.White;

            lblTotalProductos.Text = "0";
            lblTotalProductos.Location = new Point(10, 8);
            lblTotalProductos.Size = new Size(200, 45);
            lblTotalProductos.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTotalProductos.ForeColor = Color.FromArgb(26, 82, 118);
            lblTotalProductos.TextAlign = ContentAlignment.MiddleCenter;

            lblSubProductos.Text = "Productos registrados";
            lblSubProductos.Location = new Point(10, 55);
            lblSubProductos.Size = new Size(200, 18);
            lblSubProductos.Font = new Font("Segoe UI", 8);
            lblSubProductos.ForeColor = Color.Gray;
            lblSubProductos.TextAlign = ContentAlignment.MiddleCenter;

            lblTotalClientes.Text = "0";
            lblTotalClientes.Location = new Point(225, 8);
            lblTotalClientes.Size = new Size(200, 45);
            lblTotalClientes.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTotalClientes.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalClientes.TextAlign = ContentAlignment.MiddleCenter;

            lblSubClientes.Text = "Clientes registrados";
            lblSubClientes.Location = new Point(225, 55);
            lblSubClientes.Size = new Size(200, 18);
            lblSubClientes.Font = new Font("Segoe UI", 8);
            lblSubClientes.ForeColor = Color.Gray;
            lblSubClientes.TextAlign = ContentAlignment.MiddleCenter;

            lblTotalProveedores.Text = "0";
            lblTotalProveedores.Location = new Point(440, 8);
            lblTotalProveedores.Size = new Size(200, 45);
            lblTotalProveedores.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTotalProveedores.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalProveedores.TextAlign = ContentAlignment.MiddleCenter;

            lblSubProveedores.Text = "Proveedores activos";
            lblSubProveedores.Location = new Point(440, 55);
            lblSubProveedores.Size = new Size(200, 18);
            lblSubProveedores.Font = new Font("Segoe UI", 8);
            lblSubProveedores.ForeColor = Color.Gray;
            lblSubProveedores.TextAlign = ContentAlignment.MiddleCenter;

            lblTotalCategorias.Text = "0";
            lblTotalCategorias.Location = new Point(655, 8);
            lblTotalCategorias.Size = new Size(200, 45);
            lblTotalCategorias.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTotalCategorias.ForeColor = Color.FromArgb(142, 68, 173);
            lblTotalCategorias.TextAlign = ContentAlignment.MiddleCenter;

            lblSubCategorias.Text = "Categorias";
            lblSubCategorias.Location = new Point(655, 55);
            lblSubCategorias.Size = new Size(200, 18);
            lblSubCategorias.Font = new Font("Segoe UI", 8);
            lblSubCategorias.ForeColor = Color.Gray;
            lblSubCategorias.TextAlign = ContentAlignment.MiddleCenter;

            // productos con stock menor a 5 se muestran en rojo
            lblStockBajo.Text = "0";
            lblStockBajo.Location = new Point(870, 8);
            lblStockBajo.Size = new Size(200, 45);
            lblStockBajo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblStockBajo.ForeColor = Color.FromArgb(192, 57, 43);
            lblStockBajo.TextAlign = ContentAlignment.MiddleCenter;

            lblSubStock.Text = "Productos con stock bajo";
            lblSubStock.Location = new Point(870, 55);
            lblSubStock.Size = new Size(200, 18);
            lblSubStock.Font = new Font("Segoe UI", 8);
            lblSubStock.ForeColor = Color.Gray;
            lblSubStock.TextAlign = ContentAlignment.MiddleCenter;

            pnlIndicadores.Controls.Add(lblTotalProductos);
            pnlIndicadores.Controls.Add(lblSubProductos);
            pnlIndicadores.Controls.Add(lblTotalClientes);
            pnlIndicadores.Controls.Add(lblSubClientes);
            pnlIndicadores.Controls.Add(lblTotalProveedores);
            pnlIndicadores.Controls.Add(lblSubProveedores);
            pnlIndicadores.Controls.Add(lblTotalCategorias);
            pnlIndicadores.Controls.Add(lblSubCategorias);
            pnlIndicadores.Controls.Add(lblStockBajo);
            pnlIndicadores.Controls.Add(lblSubStock);

            // lista de productos con stock bajo para reposicion
            grpStockBajo.Text = "Productos con menor stock";
            grpStockBajo.Location = new Point(12, 200);
            grpStockBajo.Size = new Size(530, 220);

            dgvStockBajo.Location = new Point(10, 20);
            dgvStockBajo.Size = new Size(505, 185);
            dgvStockBajo.ReadOnly = true;
            dgvStockBajo.AllowUserToAddRows = false;
            dgvStockBajo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockBajo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockBajo.BackgroundColor = Color.White;

            grpStockBajo.Controls.Add(dgvStockBajo);

            // lista de proveedores registrados recientemente
            grpProveedores.Text = "Proveedores registrados recientemente";
            grpProveedores.Location = new Point(555, 200);
            grpProveedores.Size = new Size(567, 220);

            dgvProveedores.Location = new Point(10, 20);
            dgvProveedores.Size = new Size(542, 185);
            dgvProveedores.ReadOnly = true;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.BackgroundColor = Color.White;

            grpProveedores.Controls.Add(dgvProveedores);

            // grafica de productos por categoria
            grpGrafica.Text = "Productos por categoria";
            grpGrafica.Location = new Point(12, 430);
            grpGrafica.Size = new Size(1110, 250);

            chartCategorias.Location = new Point(10, 20);
            chartCategorias.Size = new Size(1085, 215);
            chartCategorias.BackColor = Color.White;

            ChartArea area = new ChartArea("area1");
            area.BackColor = Color.White;
            chartCategorias.ChartAreas.Add(area);

            System.Windows.Forms.DataVisualization.Charting.Series serie = new System.Windows.Forms.DataVisualization.Charting.Series("Productos");
            serie.ChartType = SeriesChartType.Column;
            serie.Color = Color.FromArgb(26, 82, 118);
            serie.IsValueShownAsLabel = true;
            chartCategorias.Series.Add(serie);

            grpGrafica.Controls.Add(chartCategorias);

            Controls.Add(pnlMenu);
            Controls.Add(lblBienvenido);
            Controls.Add(lblFecha);
            Controls.Add(pnlIndicadores);
            Controls.Add(grpStockBajo);
            Controls.Add(grpProveedores);
            Controls.Add(grpGrafica);
        }
    }
}