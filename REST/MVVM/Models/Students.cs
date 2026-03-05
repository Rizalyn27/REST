using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.MVVM.Models
{
    internal class Students
    {
        public int StuID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public int YearLevel { get; set; }
        public string Address { get; set; }
        public string Program { get; set; }

    }
}
