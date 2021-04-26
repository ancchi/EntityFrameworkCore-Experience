using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApplication.Models {
    // Zwischentabelle für ManyToMany-Beziehung
    class ResidentCareTaker {
        public int CareTakerId { get; set; }
        public CareTaker CareTaker { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }


    }
}
