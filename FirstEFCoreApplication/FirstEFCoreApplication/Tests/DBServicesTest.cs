using NUnit.Framework;
using FirstEFCoreApplication.Services;
using FirstEFCoreApplication.Models;
using System;
using System.Collections.Generic;

namespace FirstEFCoreApplication.Tests {
    [TestFixture]
    class DBServicesTest {

        [SetUp]
        public void Setup() {
            
        }
        

        [Test, Description("Zur ID muss ein Bewohner vorhanden sein und die IDs der Suche und des Ergebnisses müssen übereinstimmen.")]
        public void ReadResidentById_Test() {
            int residentId = 6;
            var service = new DBService();
            Resident resident = service.ReadResidentById(residentId);

            Assert.NotNull(resident);
            Assert.AreEqual(residentId, resident.ResidentId, "Die Ids müssen übereinstimmen.");
        }


        [Test, Description("Jedem Bewohner muss mindestens ein Pfleger zugeordnet worden sein.")]
        public void Test_GetCaretTakerListForResidentId() {
            Random random = new Random();
            int residentId = random.Next(10, 20);
            var service = new DBService();

            List<CareTaker> careTakers = service.GetCaretTakerListForResidentId(residentId);

            Assert.NotNull(careTakers);
        }
    }
}
