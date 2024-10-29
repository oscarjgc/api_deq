using LC_DEQ.Models.BaseDeDatos;

namespace api_DEQ.Models
{
    public class AnonymousChekEA
    {
        public int IdChecklistEA { get; set; }
        public string Presion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public int IdUsuario { get; set; }
        public int IdAutonomo { get; set; }
        public bool Obstrucciones { get; set; }
    }
}
