using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApplication.Models {
    class Resident {

        public int ResidentId { get; set; }

        public string Prename { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string CareLevel { get; set; }

        // Foreign Keys
        
        // OneToOne
        public Room Room { get; set; }

        // ManyToMany
        public IList<ResidentCareTaker> ResidentCareTakers { get; set; }
    }
}
