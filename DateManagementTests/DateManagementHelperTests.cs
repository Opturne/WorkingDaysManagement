using DateManagementTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DateManagement.Tests
{
    [TestClass()]
    public class DateManagementHelperTests
    {
        [TestMethod]
        public void TestCalculDate1JourFerie()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-01-08")));

            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDate1JourFerieCas2()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-01-07")));

            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2014-12-29"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDate1JourFerieCas3()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-12-28")));

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-12-17"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDate1JourFerieCas4()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-12-29")));

            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-12-18"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDate2JoursFeriesCas1()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2014-12-30")));

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2014-12-29"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2014-12-22"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDate2JoursFeriesCas2()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2016-01-04")));

            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-12-31"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-12-23"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDate3JourFerie()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-01-02")));

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2014-12-24"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDateAucunJourFerie()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-01-13")));

            Assert.AreEqual(Convert.ToDateTime("2015-01-13"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-13"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDateNormal()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-07-23")));

            Assert.AreEqual(Convert.ToDateTime("2015-07-23"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-07-23"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-07-22"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-07-15"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculDateWeekEnd()
        {
            var dureeStock = 7;
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-01-12")));

            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), checkCoeur.GetJourFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), checkCoeur.GetJourStock());
            Assert.AreEqual(Convert.ToDateTime("2015-01-09"), checkCoeur.GetVeilleFlux());
            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), checkCoeur.GetVeilleStock(dureeStock));
        }

        [TestMethod]
        public void TestCalculLendemainJourFeriePuisWeekend()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-04-30")));

            Assert.AreEqual(Convert.ToDateTime("2015-05-04"), checkCoeur.GetLendemain(Convert.ToDateTime("2015-04-30")));
        }

        [TestMethod]
        public void TestCalculLendemainSemaine()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-08-11")));

            Assert.AreEqual(Convert.ToDateTime("2015-08-12"), checkCoeur.GetLendemain(Convert.ToDateTime("2015-08-11")));
        }

        [TestMethod]
        public void TestCalculLendemainSemaineJourFerie()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2014-12-31")));

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), checkCoeur.GetLendemain(Convert.ToDateTime("2014-12-31")));
        }

        [TestMethod]
        public void TestCalculLendemainWeekend()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-08-11")));

            Assert.AreEqual(Convert.ToDateTime("2015-08-17"), checkCoeur.GetLendemain(Convert.ToDateTime("2015-08-14")));
        }

        [TestMethod]
        public void TestCalculLendemainWeekendPuisJourFerie()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-04-03")));

            Assert.AreEqual(Convert.ToDateTime("2015-04-07"), checkCoeur.GetLendemain(Convert.ToDateTime("2015-04-03")));
        }

        [TestMethod]
        public void TestCalculNbJoursUnAnDimanche()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2014-11-22")));

            // Le 22-11-15 est un dimanche donc 365+1
            Assert.AreEqual(366.00, checkCoeur.GetNbJoursAvantOuvreUnAn());
        }

        [TestMethod]
        public void TestCalculNbJoursUnAnFerie()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2015-03-28")));

            // Le 28-03-2016 est ferié donc 366+1
            Assert.AreEqual(367.00, checkCoeur.GetNbJoursAvantOuvreUnAn());
        }

        [TestMethod]
        public void TestCalculNbJoursUnAnSamedi()
        {
            var checkCoeur = Utilitaires.CreateDateManagementBLL(Convert.ToDateTime(Convert.ToDateTime("2014-11-21")));

            // Le 21-11-15 est un samedi donc 365+2
            Assert.AreEqual(367.00, checkCoeur.GetNbJoursAvantOuvreUnAn());
        }
    }
}