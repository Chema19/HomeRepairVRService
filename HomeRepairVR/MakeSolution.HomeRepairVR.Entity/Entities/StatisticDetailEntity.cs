using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class StatisticDetailEntity
    {
        public String StatusActivity { set; get; }
        public DateTime DateCreate { set; get; }
        public String Description { set; get; }
        public Int32 StatisticTimeElapsed { set; get; }
        public Int32? StepsCorrects { set; get; }
        public Int32? StepIncorrects { set; get; }
        public int? StepTutorial { set; get; }

    }
}
