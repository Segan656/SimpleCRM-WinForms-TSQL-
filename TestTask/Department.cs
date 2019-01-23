using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Department
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public String ParentDepartmentID { get; set; }

        public Department(){}
    }
}
