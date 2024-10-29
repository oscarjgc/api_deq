using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class CheckListH
    {
        public int IdChecklistH { get; set; }
        public bool NumeroHidrante { get; set; }
        public bool Boquilla { get; set; }
        public bool Funda { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdHidrante { get; set; }
        public Hidrante Hidrante { get; set; }
        public bool Obstrucciones { get; set; }
        public string Observaciones { get; set; }

    }
}
