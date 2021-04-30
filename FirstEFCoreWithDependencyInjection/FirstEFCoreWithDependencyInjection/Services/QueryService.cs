using FirstEFCoreWithDependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstEFCoreWithDependencyInjection.Services {
    public class QueryService : IQueryService {

        public List<Resident> FilterResidentsByCareLevel(string careLevel) {

            List<Resident> residents = new List<Resident>();

            using (var context = new CareContext()) {

                /*residents = context.Residents.Where(e => e.CareLevel.Equals(careLevel)).ToList();
                if (residents.Count > 0) {
                    return residents;
                } else {
                    throw new ArgumentException("Keiner der Bewohner hat dieses Care Level.");
                }
                
                 oder:

                 */

                IQueryable<Resident> residentsQueryList = from resident in context.Residents
                                                  where resident.CareLevel == careLevel
                                                  select resident;

                foreach (Resident res in residentsQueryList) {
                    residents.Add(res);
                }

                return residents;
            }
        }

        public List<Resident> FilterResidentByRoomEquipment(string equipment) {

            List<Resident> residents = new List<Resident>();

            using (var context = new CareContext()) {

                /*residents = context.Residents.Where(p => p.Room.Equipment.Equals(equipment)).ToList();
                if (residents.Count == 0) {
                    throw new ArgumentException($"Keiner dieser Bewohner hat die Ausstattungskategorie {equipment}");
                }
                
                 oder
                 */

                IQueryable<Resident> residentList = from resident in context.Residents
                                                    where resident.Room.Equipment == equipment
                                                    select resident;

                foreach (Resident res in residentList) {
                    residents.Add(res);
                }
            }
            return residents;
        }

        public int CountNumberOfEquipmentCategories() {

            int numberOfCats = 0;

            using (var context = new CareContext()) {

                var residents = context.Rooms.ToList(); // zuerst die Liste holen

                var query = residents
                    .GroupBy(e => e.Equipment).Select(b => b).ToList(); // dann kann GroupBy darauf ausgeführt werden

                numberOfCats = query.Count;
            }
            return numberOfCats;
        }

        public List<Resident> FilterResidentsByAge(int minAge, int maxAge) {
            List<Resident> residents = new List<Resident>();
            
            using (var context = new CareContext()) {

                residents = context.Residents.Where(a => a.Age >= minAge && a.Age <= maxAge).ToList();
            }

            return residents;
        }
    }
}
