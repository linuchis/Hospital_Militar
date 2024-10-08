using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoxterMilitar.classe
{
    public class dato_paciente
    {
        public long Id { get; set; }
        public string? Foto { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Genero { get; set; }
        public long Altura { get; set; }
        public long Peso { get; set; }
        
    }
}
