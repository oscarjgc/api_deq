using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UsuarioName { get; set; }
        public string Contrasenia { get; set; }
        public bool Status {  get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public List<CheckListExtintor> ChekListExtintors { get; set; }
        public List<CheckListEA> ChekListEA { get; set; }
        public List<CheckListH> ChekListH { get; set; }




    }
}
