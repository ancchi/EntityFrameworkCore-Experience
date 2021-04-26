using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApplication.Models {
    class CareTaker {

        public int CareTakerId { get; set; }

        public string Prename { get; set; }

        public string LastName { get; set; }


        // Foreign Keys

        // ManyToMany

        public IList<ResidentCareTaker> ResidentCareTakers { get; set; }
    }
}

