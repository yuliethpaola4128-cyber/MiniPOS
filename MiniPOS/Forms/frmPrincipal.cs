using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MiniPOS.Database;
using MySql.Data.MySqlClient;

namespace MiniPOS.Forms
{
    public partial class frmPrincipal : Form
    {
        private string nombreUsuario = "";

        public frmPrincipal(string nombre)
        {
            nombreUsuario = nombre;
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = "Bienvenido, " + nombreUsuario;
            lblFecha.Text = "Resumen del dia — " + DateTime.Now.ToString("dddd, dd/MM/yyyy");

            CargarIndicadores();
            CargarStockBajo();
            CargarProveedores();
            CargarGrafica();
        }

        private void CargarIndicadores()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                MySqlCommand cmd1 = new MySqlCommand("SELECT COUNT(*) FROM productos", conn);
                lblTotalProductos.Text = cmd1.ExecuteScalar().ToString();

                MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM clientes", conn);
                lblTotalClientes.Text = cmd2.ExecuteScalar().ToString();

                MySqlCommand cmd3 = new MySqlCommand("SELECT COUNT(*) FROM proveedores", conn);
                lblTotalProveedores.Text = cmd3.ExecuteScalar().ToString();

                MySqlCommand cmd4 = new MySqlCommand("SELECT COUNT(*) FROM categorias", conn);
                lblTotalCategorias.Text = cmd4.ExecuteScalar().ToString();

                MySqlCommand cmd5 = new MySqlCommand("SELECT COUNT(*) FROM productos WHERE stock < 5", conn);
                lblStockBajo.Text = cmd5.ExecuteScalar().ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void CargarStockBajo()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT p.nombre as Producto, c.nombre as Categoria, p.stock as Stock " +
                             "FROM productos p " +
                             "INNER JOIN categorias c ON p.id_categoria = c.id_categoria " +
                             "WHERE p.stock < 5 " +
                             "ORDER BY p.stock ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStockBajo.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarProveedores()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT nombre_empresa as Empresa, telefono as Telefono, " +
                             "productos_suministra as Productos " +
                             "FROM proveedores " +
                             "ORDER BY fecha_registro DESC LIMIT 5";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProveedores.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // grafica de barras con cantidad de productos por categoria
        private void CargarGrafica()
        {
            try
            {
                MySqlConnection conn = ConexionDB.ObtenerConexion();

                string sql = "SELECT c.nombre as Categoria, COUNT(p.id_producto) as Total " +
                             "FROM categorias c " +
                             "LEFT JOIN productos p ON c.id_categoria = p.id_categoria " +
                             "GROUP BY c.id_categoria " +
                             "ORDER BY c.nombre";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartCategorias.Series["Productos"].Points.Clear();

                foreach (DataRow fila in dt.Rows)
                {
                    string categoria = fila["Categoria"].ToString();
                    int total = Convert.ToInt32(fila["Total"]);
                    chartCategorias.Series["Productos"].Points.AddXY(categoria, total);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar grafica: " + ex.Message);
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos ventana = new frmProductos();
            ventana.ShowDialog();
            CargarIndicadores();
            CargarStockBajo();
            CargarGrafica();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias ventana = new frmCategorias();
            ventana.ShowDialog();
            CargarIndicadores();
            CargarGrafica();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes ventana = new frmClientes();
            ventana.ShowDialog();
            CargarIndicadores();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores ventana = new frmProveedores();
            ventana.ShowDialog();
            CargarIndicadores();
            CargarProveedores();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Desea salir del sistema?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                Application.Exit();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}