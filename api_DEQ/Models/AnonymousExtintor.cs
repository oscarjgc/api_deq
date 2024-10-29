using LC_DEQ.Models.BaseDeDatos;

namespace api_DEQ.Models
{
    public class AnonymousExtintor
    {

        public int IdExtintor { get; set; }
        public string NumeroDeExtintor { get; set; }
        public int IdCliente { get; set; }
        public bool Status { get; set; }
        public DateTime? FechaFabricacion { get; set; }
        public int IdTipoExtintor { get; set; }
    }
}
