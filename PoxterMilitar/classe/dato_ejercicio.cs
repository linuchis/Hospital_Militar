using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoxterMilitar.classe
{
    public class dato_ejercicio
    {
        public long Id { get; set; }
        public string Ejercicio { get; set; }
        public string Dispositivo { get; set; }
        public string Extremidad { get; set; }
        public bool PrimerosPasos { get; set; }
        public string Repeticiones { get; set; }
        public string Estado { get; set; }
    }
}
