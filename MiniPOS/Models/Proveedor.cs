namespace MiniPOS.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string NombreContacto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string ProductosSuministra { get; set; } = string.Empty;
    }
}