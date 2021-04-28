using FirstEFCoreApplication.Models;
using System.Collections.Generic;
using System.Linq;


namespace FirstEFCoreApplication.Services {
    class DBService {

        public Resident ReadResidentById(int residentId) {

            using (var context = new CareContext()) {

                Resident resident = context.Residents.Find(residentId);

                return resident;
            }
        }

        public List<CareTaker> GetCaretTakerListForResidentId(int residentId) {
            List<CareTaker> careTakers = new List<CareTaker>();

            using (var context = new CareContext()) {

                List<ResidentCareTaker> residentCareTakers = context.ResidentCareTakers
                    .Where(e => e.ResidentId == residentId).ToList();
                foreach (ResidentCareTaker resCareTaker in residentCareTakers) {

                    CareTaker careTaker = context.CareTakers.Find(resCareTaker.CareTakerId);
                    careTakers.Add(careTaker);
                }

                return careTakers;
            }
        }

       /* private Random random = new Random();

        public void InsertData() {
            using (var context = new CareContext()) {

                for (int i = 2; i <= 1000; i++) {


                    string[] letters = { "a", "b", "c" };
                    string[] equipmentVariants = { "standard", "luxus", "diamant" };

                    var resident = new Resident() {
                        Prename = "ResVorname" + i,
                        LastName = "ResNachname" + i,
                        Age = random.Next(71, 110), // zwischen 0 und 109
                        CareLevel = (random.Next(1, 6) + letters[random.Next(letters.Length)]), // 1 - 5 + a - c
                        Room = new Room {
                            Floor = random.Next(1, 4),
                            Equipment = equipmentVariants[random.Next(equipmentVariants.Length)]
                        },
                        Visitors = VisitorList(),
                        ResidentCareTakers = ResidentCareTakersList()
                    };

                    context.Residents.Add(resident);
                }
                context.SaveChanges();
            }
        }


        public List<Visitor> VisitorList() {
            List<Visitor> visitorList = new List<Visitor>();

            for (int i = 1; i < random.Next(1, 6); i++) {
                visitorList.Add(new Visitor { PreName = $"VisPrename{i}", LastName = $"VisLastName{i}" });
            }

            return visitorList;
        }

        public List<ResidentCareTaker> ResidentCareTakersList() {
            List<ResidentCareTaker> residentCareTakersList = new List<ResidentCareTaker>();

            for (int i = 1; i < random.Next(2, 5); i++) {
                residentCareTakersList.Add(new ResidentCareTaker {
                    CareTaker = new CareTaker { Prename = $"CTakerPreName{i}", LastName = $"CTakerLastName{i}" }
                });
            }

            return residentCareTakersList;
        }*/
    }
}
