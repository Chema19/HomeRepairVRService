using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class UserEntity
    {
        public Int32? UserId { set; get; }
        public String UserName { set; get; }
        public String UserUrlPicture { set; get; }
        public DateTime? DateCreate { set; get; }
        public String Status { set; get; }
        public DateTime? DateUpdate { set; get; }
    }
}
