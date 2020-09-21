using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeSolution.HomeRepairVR.DataAccess.Model;
using MakeSolution.HomeRepairVR.Entity.Entities;

namespace MakeSolution.HomeRepairVR.Business
{
    public class BaseBusiness
    {
        public BDHomeRepairVREntities Context { set; get; } = new BDHomeRepairVREntities();
    }
}
