namespace TiendaAPI.Models
{
    public class Productos
    {
        public int productoId { get; set; }
        public string nombreProducto { get; set; }
        public decimal precioVenta { get; set; }
        public decimal precioEnvioMinimo { get; set; }
        public bool activo { get; set; }
        public Productos()
        {
            activo = true;
        }

    }
}
