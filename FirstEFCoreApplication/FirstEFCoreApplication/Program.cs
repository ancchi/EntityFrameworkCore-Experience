using FirstEFCoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstEFCoreApplication {
    class Program {
        static void Main(string[] args) {

            //InsertData();
            //UpdateResident();
            DeleteResident();
            ReadResident();
        }

        private static Random random = new Random();

        private static void InsertData() {
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


        private static void UpdateResident() {

            using (var context = new CareContext()) {
                try {
                    Resident res = context.Residents.Find(5);
                    res.Prename = "Anneliese";
                    context.SaveChanges();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                
            }
            return;
        }

        private static void DeleteResident() {

            using (var context = new CareContext()) {
                // kaskadierendes Delete:
                var res = context.Residents.Include(e => e.Visitors).First(x => x.ResidentId == 8);
                context.Remove(res);
                //context.SaveChanges();
            }
        }


        private static void ReadResident() {

            using (var context = new CareContext()) {

                Resident resident = context.Residents.Find(8);
                string residentString = resident.ToString();
                Console.WriteLine(residentString);
            }
        }

        private static List<Visitor> VisitorList() {
            List<Visitor> visitorList = new List<Visitor>();

            for (int i = 1; i < random.Next(1, 6); i++) {
                visitorList.Add(new Visitor { PreName = $"VisPrename{i}", LastName = $"VisLastName{i}" });
            }

            return visitorList;
        }

        private static List<ResidentCareTaker> ResidentCareTakersList() {
            List<ResidentCareTaker> residentCareTakersList = new List<ResidentCareTaker>();

            for (int i = 1; i < random.Next(2, 5); i++) {
                residentCareTakersList.Add(new ResidentCareTaker { 
                CareTaker = new CareTaker { Prename = $"CTakerPreName{i}", LastName = $"CTakerLastName{i}"}
                });
            }

            return residentCareTakersList;
        }
    }
}
