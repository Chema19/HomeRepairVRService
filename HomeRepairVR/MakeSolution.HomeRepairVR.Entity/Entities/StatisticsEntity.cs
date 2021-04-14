using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class StatisticsEntity
    {
        public Int32? Correctas { set; get; }
        public Int32? Incorrectas { set; get; }
        public String Titulo { set; get; }
        public Int32? TiempoTranscurrido { set; get; } 
        public String Pasos { set; get; }
        public String Foto { set; get; }
    }
}
