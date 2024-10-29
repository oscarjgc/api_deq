using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{// mapeo
    public class CheckListEA
    {
        public int IdChecklistEA { get; set; }
        public string Presion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdAutonomo { get; set; }
        public EquipoAutonomo EquipoAutonomo { get;set; }
        public bool Obstrucciones { get; set; }

    }
}
