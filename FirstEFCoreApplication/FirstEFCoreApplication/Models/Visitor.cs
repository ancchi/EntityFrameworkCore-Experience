using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApplication.Models {
    class Visitor {

        public int VisitorId { get; set; }
        public string PreName { get; set; }
        public string LastName { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }
}
