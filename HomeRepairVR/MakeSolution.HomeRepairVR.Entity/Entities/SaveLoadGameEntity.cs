using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class SaveLoadGameEntity
    {
        public Int32 UserActivityId { set; get; }
        public Int32? StepId { set; get; }
        public String Description { set; get; }
        public String Status { set; get; }
        public Int32 TimeElapse { set; get; }
        public Int32? CorrectSteps { set; get; }
        public Int32? WrongSteps { set; get; }
        public String StatusActivity { set; get; }
    }
}
