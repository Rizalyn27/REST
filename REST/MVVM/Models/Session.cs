using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.MVVM.Models
{
    public class Session
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public string CounselorName { get; set; }
        public string SessionDate { get; set; }
        public string Notes { get; set; }
    }
}
