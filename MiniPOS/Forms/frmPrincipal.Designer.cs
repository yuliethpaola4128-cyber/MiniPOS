using System.Windows.Forms;
using System.Drawing;

namespace MiniPOS.Forms
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip    menuPrincipal;
        private ToolStripMenuItem mnuInicio;
        private ToolStripMenuItem mnuProductos;
        private ToolStripMenuItem mnuCategorias;
        private ToolStripMenuItem mnuClientes;
        private ToolStripMenuItem mnuProveedores;
        private ToolStripMenuItem mnuSalir;

        private Label        lblBienvenido;
        private Label        lblFecha;

        private GroupBox     grpIndicadores;
        private Label        lblTotalProductos;
        private Label        lblTotalClientes;
        private Label        lblTotalProveedores;
        private Label        lblTotalCategorias;
        private Label        lblStockBajo;
        private Label        lblSubProductos;
        private Label        lblSubClientes;
        private Label        lblSubProveedores;
        private Label        lblSubCategorias;
        private Label        lblSubStock;

        private GroupBox     grpStockBajo;
        private DataGridView dgvStockBajo;

        private GroupBox     grpProveedores;
        private DataGridView dgvProveedores;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuPrincipal    = new MenuStrip();
            mnuInicio        = new ToolStripMenuItem();
            mnuProductos     = new ToolStripMenuItem();
            mnuCategorias    = new ToolStripMenuItem();
            mnuClientes      = new ToolStripMenuItem();
            mnuProveedores   = new ToolStripMenuItem();
            mnuSalir         = new ToolStripMenuItem();

            lblBienvenido    = new Label();
            lblFecha         = new Label();

            grpIndicadores   = new GroupBox();
            lblTotalProductos   = new Label();
            lblTotalClientes    = new Label();
            lblTotalProveedores = new Label();
            lblTotalCategorias  = new Label();
            lblStockBajo        = new Label();
            lblSubProductos     = new Label();
            lblSubClientes      = new Label();
            lblSubProveedores   = new Label();
            lblSubCategorias    = new Label();
            lblSubStock         = new Label();

            grpStockBajo  = new GroupBox();
            dgvStockBajo  = new DataGridView();

            grpProveedores = new GroupBox();
            dgvProveedores = new DataGridView();

            // ── FORM ──────────────────────────────
            Text          = "MiniPOS - Panel Principal";
            Size          = new Size(1100, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Load         += frmPrincipal_Load;
            FormClosed   += frmPrincipal_FormClosed;

            // ── MENU ──────────────────────────────
            mnuInicio.Text      = "Inicio";
            mnuProductos.Text   = "Productos";
            mnuCategorias.Text  = "Categorias";
            mnuClientes.Text    = "Clientes";
            mnuProveedores.Text = "Proveedores";
            mnuSalir.Text       = "Salir";
/*
            mnuProductos.Click   += mnuProductos_Click;
            mnuCategorias.Click  += mnuCategorias_Click;
            mnuClientes.Click    += mnuClientes_Click;
            mnuProveedores.Click += mnuProveedores_Click;
            mnuSalir.Click       += mnuSalir_Click;
*/
            menuPrincipal.Items.Add(mnuInicio);
            menuPrincipal.Items.Add(mnuProductos);
            menuPrincipal.Items.Add(mnuCategorias);
            menuPrincipal.Items.Add(mnuClientes);
            menuPrincipal.Items.Add(mnuProveedores);
            menuPrincipal.Items.Add(mnuSalir);

            // ── BIENVENIDO ────────────────────────
            lblBienvenido.Location = new Point(10, 35);
            lblBienvenido.Size     = new Size(500, 25);
            lblBienvenido.Font     = new Font("Arial", 11, FontStyle.Bold);
            lblBienvenido.Text     = "Bienvenido";

            lblFecha.Location = new Point(10, 60);
            lblFecha.Size     = new Size(500, 20);
            lblFecha.Text     = "Fecha: ";

            // ── INDICADORES ───────────────────────
            grpIndicadores.Text     = "Resumen General";
            grpIndicadores.Location = new Point(10, 88);
            grpIndicadores.Size     = new Size(1060, 110);

            // productos
            lblTotalProductos.Text      = "0";
            lblTotalProductos.Location  = new Point(20, 25);
            lblTotalProductos.Size      = new Size(170, 45);
            lblTotalProductos.Font      = new Font("Arial", 26, FontStyle.Bold);
            lblTotalProductos.ForeColor = Color.DarkBlue;
            lblTotalProductos.TextAlign = ContentAlignment.MiddleCenter;

            lblSubProductos.Text      = "Productos";
            lblSubProductos.Location  = new Point(20, 70);
            lblSubProductos.Size      = new Size(170, 18);
            lblSubProductos.TextAlign = ContentAlignment.MiddleCenter;

            // clientes
            lblTotalClientes.Text      = "0";
            lblTotalClientes.Location  = new Point(210, 25);
            lblTotalClientes.Size      = new Size(170, 45);
            lblTotalClientes.Font      = new Font("Arial", 26, FontStyle.Bold);
            lblTotalClientes.ForeColor = Color.DarkGreen;
            lblTotalClientes.TextAlign = ContentAlignment.MiddleCenter;

            lblSubClientes.Text      = "Clientes";
            lblSubClientes.Location  = new Point(210, 70);
            lblSubClientes.Size      = new Size(170, 18);
            lblSubClientes.TextAlign = ContentAlignment.MiddleCenter;

            // proveedores
            lblTotalProveedores.Text      = "0";
            lblTotalProveedores.Location  = new Point(400, 25);
            lblTotalProveedores.Size      = new Size(170, 45);
            lblTotalProveedores.Font      = new Font("Arial", 26, FontStyle.Bold);
            lblTotalProveedores.ForeColor = Color.DarkCyan;
            lblTotalProveedores.TextAlign = ContentAlignment.MiddleCenter;

            lblSubProveedores.Text      = "Proveedores";
            lblSubProveedores.Location  = new Point(400, 70);
            lblSubProveedores.Size      = new Size(170, 18);
            lblSubProveedores.TextAlign = ContentAlignment.MiddleCenter;

            // categorias
            lblTotalCategorias.Text      = "0";
            lblTotalCategorias.Location  = new Point(590, 25);
            lblTotalCategorias.Size      = new Size(170, 45);
            lblTotalCategorias.Font      = new Font("Arial", 26, FontStyle.Bold);
            lblTotalCategorias.ForeColor = Color.Purple;
            lblTotalCategorias.TextAlign = ContentAlignment.MiddleCenter;

            lblSubCategorias.Text      = "Categorias";
            lblSubCategorias.Location  = new Point(590, 70);
            lblSubCategorias.Size      = new Size(170, 18);
            lblSubCategorias.TextAlign = ContentAlignment.MiddleCenter;

            // stock bajo
            lblStockBajo.Text      = "0";
            lblStockBajo.Location  = new Point(780, 25);
            lblStockBajo.Size      = new Size(170, 45);
            lblStockBajo.Font      = new Font("Arial", 26, FontStyle.Bold);
            lblStockBajo.ForeColor = Color.Red;
            lblStockBajo.TextAlign = ContentAlignment.MiddleCenter;

            lblSubStock.Text      = "Stock Bajo";
            lblSubStock.Location  = new Point(780, 70);
            lblSubStock.Size      = new Size(170, 18);
            lblSubStock.TextAlign = ContentAlignment.MiddleCenter;

            grpIndicadores.Controls.Add(lblTotalProductos);
            grpIndicadores.Controls.Add(lblSubProductos);
            grpIndicadores.Controls.Add(lblTotalClientes);
            grpIndicadores.Controls.Add(lblSubClientes);
            grpIndicadores.Controls.Add(lblTotalProveedores);
            grpIndicadores.Controls.Add(lblSubProveedores);
            grpIndicadores.Controls.Add(lblTotalCategorias);
            grpIndicadores.Controls.Add(lblSubCategorias);
            grpIndicadores.Controls.Add(lblStockBajo);
            grpIndicadores.Controls.Add(lblSubStock);

            // ── STOCK BAJO ────────────────────────
            grpStockBajo.Text     = "Productos con poco stock";
            grpStockBajo.Location = new Point(10, 210);
            grpStockBajo.Size     = new Size(520, 360);

            dgvStockBajo.Location            = new Point(10, 20);
            dgvStockBajo.Size                = new Size(495, 325);
            dgvStockBajo.ReadOnly            = true;
            dgvStockBajo.AllowUserToAddRows  = false;
            dgvStockBajo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockBajo.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;

            grpStockBajo.Controls.Add(dgvStockBajo);

            // ── PROVEEDORES RECIENTES ─────────────
            grpProveedores.Text     = "Proveedores recientes";
            grpProveedores.Location = new Point(545, 210);
            grpProveedores.Size     = new Size(525, 360);

            dgvProveedores.Location            = new Point(10, 20);
            dgvProveedores.Size                = new Size(500, 325);
            dgvProveedores.ReadOnly            = true;
            dgvProveedores.AllowUserToAddRows  = false;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;

            grpProveedores.Controls.Add(dgvProveedores);

            // ── AGREGAR AL FORM ───────────────────
            MainMenuStrip = menuPrincipal;
            Controls.Add(menuPrincipal);
            Controls.Add(lblBienvenido);
            Controls.Add(lblFecha);
            Controls.Add(grpIndicadores);
            Controls.Add(grpStockBajo);
            Controls.Add(grpProveedores);
        }
    }
}