namespace TiendaAPI.Models
{
    public class ResponseAPI<T>
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        
        public T responsedata { get; set; }
    }
}
