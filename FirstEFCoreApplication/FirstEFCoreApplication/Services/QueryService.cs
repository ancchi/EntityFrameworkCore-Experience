using FirstEFCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstEFCoreApplication.Services {
    class QueryService {

        public List<Resident> FilterResidentsByCareLevel(string careLevel) {

            List<Resident> residents = new List<Resident>();

            using (var context = new CareContext()) {
                
                 residents = context.Residents.Where(e => e.CareLevel.Equals(careLevel)).ToList();
                if (residents.Count > 0) {
                    return residents;
                } else {
                    throw new ArgumentException("Diese Bezeichnung für CareLevel existiert nicht.");
                }
            }
        }

        public List<Resident> FilterResidentByRoomEquipment(string equipment) {

            List<Resident> residents = new List<Resident>();
            // TODO
            return residents;
        }

        public List<Resident> FilterResidentsByAge(int minAge, int maxAge) {
            List<Resident> residents = new List<Resident>();
            // TODO
            return residents;
        }
    }
}
