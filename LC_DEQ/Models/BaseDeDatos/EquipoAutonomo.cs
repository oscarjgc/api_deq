using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class EquipoAutonomo
    {
        public int IdAutonomo { get; set; }
        public string NumeroAutonomo { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public bool Status { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public List<CheckListEA> CheckListEA { get; set; }

    }
}
