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
        
        // OneToOne (1 Zimmer pro Bewohner)
        public Room Room { get; set; }

        // ManyToMany (viele Bewohner, viele Pfleger)
        public IList<ResidentCareTaker> ResidentCareTakers { get; set; }

        // ManyToOne-Beziehung (viele Besucher, ein Bewohner)
        public IList<Visitor> Visitors { get; set; }

        public override string  ToString() {
            return Prename + " " + LastName + ",\nAge: " + Age + ",\nCareLevel: " + CareLevel;
        }
    }
}
