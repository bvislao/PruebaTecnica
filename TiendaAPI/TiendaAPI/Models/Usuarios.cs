namespace TiendaAPI.Models
{
    public class Usuarios
    {
        public int usuarioId { get; set; }
        public string documentoIdentidad { get; set; }
        public string passwordUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string correoElectronica { get; set; }
        public bool activo { get; set; }
        public Usuarios()
        {
            activo = true;
        }
    }
}
