using System;
using System.Data;
using System.Windows.Forms;
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
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");

            CargarIndicadores();
            CargarStockBajo();
            CargarProveedores();
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

      /*  private void mnuProductos_Click(object sender, EventArgs e)
        {
            frmProductos ventana = new frmProductos();
            ventana.ShowDialog();
            CargarIndicadores();
            CargarStockBajo();
        }

        private void mnuCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias ventana = new frmCategorias();
            ventana.ShowDialog();
            CargarIndicadores();
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            frmClientes ventana = new frmClientes();
            ventana.ShowDialog();
            CargarIndicadores();
        }
      */
        private void mnuProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores ventana = new frmProveedores();
            ventana.ShowDialog();
            CargarIndicadores();
            CargarProveedores();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Desea salir del sistema?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}