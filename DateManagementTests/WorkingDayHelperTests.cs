using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkingDaysManagement;
using WorkingDaysManagementTests.Utils;

namespace WorkingDaysManagementTests
{
    [TestClass]
    public class WorkingDayHelperTests
    {
        [TestMethod]
        public void WorkingDayHelperNoArgsTest()
        {
            var helper = new WorkingDayHelper();

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod]
        public void WorkingDayHelperHolidayTest()
        {
            var helper = new WorkingDayHelper(new List<DateTime>());

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod]
        public void WorkingDayHelperDayOfWeekTest()
        {
            var helper = new WorkingDayHelper(new List<DayOfWeek>());

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkingDayHelperWeekEndNullTest()
        {
            var helper = new WorkingDayHelper(new List<DateTime>(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkingDayHelperHolidayNullTest()
        {
            var helper = new WorkingDayHelper(null, new List<DayOfWeek>());
        }

        [TestMethod]
        public void Date1Holiday()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void Date1HolidayCas2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void Date1HolidayCas3()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2015-12-18"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void Date1HolidayCas4()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-22"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void Date2HolidaysCas1()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-29"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-23"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2014-12-22"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void Date2HolidaysCas2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2016, 01, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-31"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void Date3Holiday()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 02);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2014-12-26"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2014-12-24"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void DateNoHoliday()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-13"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void DateNormal()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 07, 23);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-23"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-07-22"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-07-16"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2015-07-16"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void DateWeekEnd()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 12);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.GetLast(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-09"), managementHelper.GetYesterday(dateReference));
            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), managementHelper.GetSpanStart(dateReference, dureeStock));
            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void TomorrowHolidayPuisWeekend()
        {
            var dateReference = new DateTime(2015, 04, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-05-04"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-04-30")));
        }

        [TestMethod]
        public void TomorrowWeek()
        {
            var dateReference = new DateTime(2015, 08, 11);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-08-12"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-08-11")));
        }

        [TestMethod]
        public void TomorrowWeekHoliday()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetTomorrow(Convert.ToDateTime("2014-12-31")));
        }

        [TestMethod]
        public void TomorrowWeekend()
        {
            var dateReference = new DateTime(2015, 08, 11);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-08-17"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-08-14")));
        }

        [TestMethod]
        public void TomorrowWeekendThenHoliday()
        {
            var dateReference = new DateTime(2015, 04, 03);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-04-07"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-04-03")));
        }

        [TestMethod]
        public void NbDays1YearSunday()
        {
            var dateReference = new DateTime(2014, 11, 22);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(366.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void NbDays1YearHoliday()
        {
            var dateReference = new DateTime(2015, 03, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(367.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void NbDays1YearSaturday()
        {
            var dateReference = new DateTime(2014, 11, 21);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(367.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void EasterDayTest()
        {
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(new DateTime(2025, 04, 20), managementHelper.EasterDay(2025));
            Assert.AreEqual(new DateTime(1996, 04, 07), managementHelper.EasterDay(1996));
            Assert.AreEqual(new DateTime(2010, 04, 04), managementHelper.EasterDay(2010));
            Assert.AreEqual(new DateTime(2019, 04, 21), managementHelper.EasterDay(2019));
        }
    }
}