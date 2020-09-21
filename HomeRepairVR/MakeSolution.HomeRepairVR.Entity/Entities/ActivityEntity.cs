using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class ActivityEntity
    {
        public Int32? ActivityId { set; get; }
        public String ActivityName { set; get; }
        public int ActivityTime { set; get; }
        public String ActivityUrlPicture { set; get; }
        public DateTime? DateCreate { set; get; }
        public String ActivityDescription { set; get; }
        public DateTime? DateUpdate { set; get; }
    }
}
