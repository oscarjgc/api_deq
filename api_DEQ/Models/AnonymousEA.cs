using LC_DEQ.Models.BaseDeDatos;

namespace api_DEQ.Models
{
    public class AnonymousEA
    {
        public int IdAutonomo { get; set; }
        public string NumeroAutonomo { get; set; }
        public int IdCliente { get; set; }
        public bool Status { get; set; }
    }
}
