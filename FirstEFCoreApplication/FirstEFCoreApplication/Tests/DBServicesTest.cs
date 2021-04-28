using NUnit.Framework;
using FirstEFCoreApplication.Services;
using FirstEFCoreApplication.Models;
using System;
using System.Collections.Generic;

namespace FirstEFCoreApplication.Tests {
    [TestFixture]
    class DBServicesTest {

        DBService service;
        Random random;

        [SetUp]
        public void Setup() {
            service = new DBService();
            random = new Random();
        }
        

        [Test, Description("Zur ID muss ein Bewohner vorhanden sein und die IDs der Suche und des Ergebnisses müssen übereinstimmen.")]
        public void Test_FindResidentById() {
            int residentId = 6;
            Resident resident = service.FindResidentById(residentId);

            Assert.NotNull(resident);
            Assert.AreEqual(residentId, resident.ResidentId, "Die Ids müssen übereinstimmen.");
        }


        [Test, Description("Jedem Bewohner muss mindestens ein Pfleger zugeordnet worden sein.")]
        public void Test_GetCaretTakerListForResidentId() {
            random = new Random();
            int residentId = random.Next(10, 20);
           
            List<CareTaker> careTakersPerResident = service.GetCaretTakerListForResidentId(residentId);

            Assert.NotNull(careTakersPerResident);
        }

        [Test, Description("Jedem Pfleger muss mindestens ein Bewohner zugeordnet sein.")]
        public void Test_GetResidentListForCareTakerId() {
            int careTakerId = random.Next(10, 20);

            List<Resident> residentsPerCareTaker = service.GetResidentListForCareTakerId(careTakerId);

            Assert.NotNull(residentsPerCareTaker);
        }

        

        [Test, Description("Der Name eines Bewohners soll geändert werden.")]
        public void Test_UpdateNameResident() {

            int residentId = random.Next(10, 20);

            // Vorher
            Resident resident = service.FindResidentById(residentId);
            string preNameBefore = resident.Prename;
            string lastNameBefore = resident.LastName;

            // neue Namen:
            string[] preNames = { "Luise", "Lisa", "Anneliese", "Irma"};
            string[] lastNames = { "Vogel", "Meyer", "Friedrich", "Siebert" };
            string preName = preNames[random.Next(preNames.Length)];
            string lastName = lastNames[random.Next(lastNames.Length)];

            // Testaufruf
            resident = service.UpdateNameResident(residentId, preName, lastName);

            // Standardtests, die immer wahr sein müssen
            Assert.NotNull(resident);
            Assert.AreEqual(preName, resident.Prename, "Die Vornamen müssen gleich sein.");
            Assert.AreEqual(lastName, resident.LastName, "Die Nachnamen müssen gleich sein.");

            // Test, wenn Vorname sich geändert hat
            if (!preName.Equals(preNameBefore)) {
                Assert.AreNotEqual(preNameBefore, resident.Prename, "Der Vorname muss sich geändert haben");
            }
            // Test, wenn Nachname sich geändert hat
            if (!lastName.Equals(lastNameBefore)) {
                Assert.AreNotEqual(lastNameBefore, resident.LastName, "Der Nachname muss sich geändert haben");
            }
        }

       
        [Ignore("Ignoriert - Das Löschen von Datensätzen sollte einzeln und bewusst gemacht werden.")]
        [Test, Description("Wenn ein Bewohner gelöscht wird, sollen auch seine Besucher gelöscht werden.")]
        public void Test_DeleteResidentWithVisitors() {

            int residentId = 198;
            
            Resident resident = service.FindResidentById(residentId);
            List<Visitor> visitors = service.GetVisitorListForResidentId(residentId);

            // Vor dem Aufruf von Delete
            Assert.NotNull(resident);
            Assert.NotNull(visitors);
            Assert.Greater(visitors.Count, 0);

            if (resident != null && visitors.Count > 0) {

                 service.DeleteResidentWithVisitors(residentId);

                resident = service.FindResidentById(residentId);
                visitors = service.GetVisitorListForResidentId(residentId);

                Assert.IsNull(resident);
                Assert.IsEmpty(visitors);
                Assert.AreEqual(0, visitors.Count);
            }
        }
    }
}
