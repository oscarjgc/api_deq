using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class Hidrante
    {
        public int IdHidrante { get; set; }
        public string NumeroHidrante { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public bool Status { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public List<CheckListH> CheckListH { get; set; }

    }
}
