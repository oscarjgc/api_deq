using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public bool Status { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public List <Extintor> Extintors { get; set; }
        public List<Hidrante> Hidrantes { get; set; }
        public List<EquipoAutonomo> EquiposAutonomos { get; set; }

    }
}
