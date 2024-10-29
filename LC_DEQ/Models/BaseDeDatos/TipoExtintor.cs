using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class TipoExtintor
    {
        public int IdTipoExtintor { get; set; }
        public string Descripcion { get; set; }
        public bool Status { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public List<Extintor> Extintors { get; set; }

    }
}
