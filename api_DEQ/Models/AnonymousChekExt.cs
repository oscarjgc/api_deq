using LC_DEQ.Models.BaseDeDatos;

namespace api_DEQ.Models
{
    public class AnonymousChekExt
    {
        public int IdChekList { get; set; }
        public int IdExtintor { get; set; }
        public bool Letrero { get; set; }
        public bool NumeroExtintor { get; set; }
        public bool Funda { get; set; }
        public string Base { get; set; }
        public bool Seguro { get; set; }
        public bool? Manometro { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public DateTime FechaServicio { get; set; }
        public int IdUsuario { get; set; }
        public bool Obstrucciones { get; set; }
        public int TipoDeRevision { get; set; }
    }
}
