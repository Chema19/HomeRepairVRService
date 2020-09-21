using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSolution.HomeRepairVR.Entity.Entities
{
    public class ResponseEntity<T>
    {
        public T Data { set; get; }
        public Boolean Error { set; get; }
        public String Message { set; get; }
    }
}
