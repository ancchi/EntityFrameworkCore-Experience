using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreWithDependencyInjection.Models {
    // Zwischentabelle für ManyToMany-Beziehung
    public class ResidentCareTaker {
        public int CareTakerId { get; set; }
        public CareTaker CareTaker { get; set; }

        public int ResidentId { get; set; }
        public Resident Resident { get; set; }


    }
}
