using FirstEFCoreApplication.Models;
using FirstEFCoreApplication.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFCoreApplication.Tests {

    [TestFixture]
    class QueryServiceTest {

        Random random;
        QueryService queryService;

        [SetUp]
        public void Setup() {
            random = new Random();
            queryService = new QueryService();
        }

        [Test, Description("Test mit den vorgegebenen CareLevels")]
        public void Test_FilterResidentsByCareLevel_existingCareLevel() {

            string[] letters = { "a", "b", "c" };
            string careLevel = random.Next(1, 6) + letters[random.Next(letters.Length)]; // entspricht den erstellten Daten

            List<Resident> residents = queryService.FilterResidentsByCareLevel(careLevel);

            Assert.NotNull(residents);
            Assert.Greater(residents.Count, 0);

            foreach (Resident resident in residents) {
                Assert.AreEqual(careLevel, resident.CareLevel);
            }

        }

        [Test, Description("Tests mit nicht vorhandenem Carelevel")]
        public void Test_FilterResidentsByCareLevel_WrongCareLevel() {


            string careLevel = "dummy"; // Carelevel soll in Datensatz nicht existieren

            var ex = Assert.Throws<ArgumentException>(() => queryService.FilterResidentsByCareLevel(careLevel));
            Assert.That(ex.Message, Is.EqualTo("Keiner der Bewohner hat dieses Care Level."));
        }


        [Test, Description("Test mit richtiger RoomEquipment-Bezeichnung")]
        public void Test_FilterResidentByRoomEquipment() {

            string[] equipment = { "standard", "luxus", "diamant"};
            string equipmentTerm = equipment[random.Next(equipment.Length)];

            List<Resident> residents = queryService.FilterResidentByRoomEquipment(equipmentTerm);

            Assert.That(residents.Count > 0);
            // oder
            Assert.Greater(residents.Count, 0);
        }

        [Test, Description("Nummer der Kategorien ist bekannt")]
        public void Test_CountNumberOfEquipmentCategories() {

            int expectedNumber = 3;

            int number = queryService.CountNumberOfEquipmentCategories();

            Assert.AreEqual(number, expectedNumber);
        }

    }
}
