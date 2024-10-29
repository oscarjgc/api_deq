using LC_DEQ.Models.BaseDeDatos;

namespace api_DEQ.Models
{
    public class AnonymousChekH
    {
        public int IdChecklistH { get; set; }
        public bool NumeroHidrante { get; set; }
        public bool Boquilla { get; set; }
        public bool Funda { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public int IdUsuario { get; set; }
        public int IdHidrante { get; set; }
        public bool Obstrucciones { get; set; }
        public string Observaciones { get; set; }
    }
}
