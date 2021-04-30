using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreWithDependencyInjection.Models {
    public class Room {
        public int RoomId { get; set; }

        public int Floor { get; set; }

        public string Equipment { get; set; }

        // Foreign Keys

        // OneToOne
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }
}
