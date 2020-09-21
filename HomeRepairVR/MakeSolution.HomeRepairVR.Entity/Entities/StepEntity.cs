using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class StepEntity
    {
        public Int32? StepId { set; get; }
        public String StepName { set; get; }
        public Int32? StepNumber { set; get; }
        public String StepDrescription { set; get; }
        public Int32? StepTimeAverage { set; get; }
        public Int32? ActivityStep { set; get; }
    }
}
