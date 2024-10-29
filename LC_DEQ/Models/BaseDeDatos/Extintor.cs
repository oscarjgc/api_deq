using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_DEQ.Models.BaseDeDatos
{
    public class Extintor
    {
        public int IdExtintor { get; set; }
        public string NumeroDeExtintor { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public bool Status { get; set; }
        public DateTime FechaHoraCaptura { get; set; }
        public DateTime? FechaFabricacion { get; set; }
        public int IdTipoExtintor { get; set; }
        public TipoExtintor TipoExtintor { get; set;}
        public List <CheckListExtintor> Extintores { get; set; }


        


    }
}
