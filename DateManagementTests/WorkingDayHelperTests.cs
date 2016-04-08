using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkingDaysManagementTests.Utils;

namespace WorkingDaysManagement.Tests
{
    [TestClass]
    public class WorkingDayHelperTests
    {
        #region Constructor

        [TestMethod]
        public void WorkingDayHelperDayOfWeekTest()
        {
            var helper = new WorkingDayHelper(new List<DayOfWeek>());

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkingDayHelperHolidayNullTest()
        {
            var helper = new WorkingDayHelper(null, new List<DayOfWeek>());
        }

        [TestMethod]
        public void WorkingDayHelperHolidayTest()
        {
            var helper = new WorkingDayHelper(new List<DateTime>());

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod]
        public void WorkingDayHelperNoArgsTest()
        {
            var helper = new WorkingDayHelper();

            Assert.AreNotEqual(null, helper);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkingDayHelperWeekEndNullTest()
        {
            var helper = new WorkingDayHelper(new List<DateTime>(), null);
        }

        #endregion Constructor

        [TestMethod]
        public void EasterDayTest()
        {
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(new DateTime(2025, 04, 20), managementHelper.EasterDay(2025));
            Assert.AreEqual(new DateTime(1996, 04, 07), managementHelper.EasterDay(1996));
            Assert.AreEqual(new DateTime(2010, 04, 04), managementHelper.EasterDay(2010));
            Assert.AreEqual(new DateTime(2019, 04, 21), managementHelper.EasterDay(2019));
        }

        [TestMethod]
        public void GetLast1Holiday()
        {
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast1Holiday2()
        {
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast1Holiday3()
        {
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast1Holiday4()
        {
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast2Holidays1()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast2Holidays2()
        {
            var dateReference = new DateTime(2016, 01, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast3Holiday()
        {
            var dateReference = new DateTime(2015, 01, 02);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLastNoHoliday()
        {
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-13"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLastNormal()
        {
            var dateReference = new DateTime(2015, 07, 23);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-23"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLastWeekEnd()
        {
            var dateReference = new DateTime(2015, 01, 12);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetSpanDays1YearHoliday()
        {
            var dateReference = new DateTime(2015, 03, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(367.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void GetSpanDays1YearSaturday()
        {
            var dateReference = new DateTime(2014, 11, 21);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(367.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void GetSpanDays1YearSunday()
        {
            var dateReference = new DateTime(2014, 11, 22);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(366.00, managementHelper.GetSpanDays(dateReference, dateReference.AddYears(1) - dateReference));
        }

        [TestMethod]
        public void GetSpanEnd1Holiday()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd1Holiday2()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd1Holiday3()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 19);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd1Holiday4()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-01-05"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd2Holidays1()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2016, 03, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-03-31"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd2Holidays2()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-31"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd3Holiday()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 25);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEndNoHoliday()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-20"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEndNormal()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 04, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-04-13"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEndWeekEnd()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2016, 04, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-04-15"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart1Holiday()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart1Holiday2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart1Holiday3()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart1Holiday4()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-22"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart2Holidays1()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-23"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart2Holidays2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2016, 01, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart3Holiday()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 02);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-26"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStartNoHoliday()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStartNormal()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 07, 23);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-16"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStartWeekEnd()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 12);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetTomorrowTomorrowHolidayPuisWeekend()
        {
            var dateReference = new DateTime(2015, 04, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-05-04"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-04-30")));
        }

        [TestMethod]
        public void GetTomorrowWeek()
        {
            var dateReference = new DateTime(2015, 08, 11);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-08-12"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-08-11")));
        }

        [TestMethod]
        public void GetTomorrowWeekend()
        {
            var dateReference = new DateTime(2015, 08, 11);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-08-17"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-08-14")));
        }

        [TestMethod]
        public void GetTomorrowWeekendThenHoliday()
        {
            var dateReference = new DateTime(2015, 04, 03);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-04-07"), managementHelper.GetTomorrow(Convert.ToDateTime("2015-04-03")));
        }

        [TestMethod]
        public void GetTomorrowWeekHoliday()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.GetTomorrow(Convert.ToDateTime("2014-12-31")));
        }

        [TestMethod]
        public void GetYesterday1Holiday()
        {
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday1Holiday2()
        {
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday1Holiday3()
        {
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday1Holiday4()
        {
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday2Holidays1()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-29"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday2Holidays2()
        {
            var dateReference = new DateTime(2016, 01, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-31"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday3Holiday()
        {
            var dateReference = new DateTime(2015, 01, 02);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterdayNoHoliday()
        {
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterdayNormal()
        {
            var dateReference = new DateTime(2015, 07, 23);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-22"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterdayWeekEnd()
        {
            var dateReference = new DateTime(2015, 01, 12);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-09"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FuturWorkingDaysNegativeValue()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            managementHelper.FuturWorkingDays(dateReference, -5);
        }

        [TestMethod]
        public void FuturWorkingDays1Holiday()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDays1Holiday2()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDays1Holiday3()
        {
            var dateReference = new DateTime(2015, 12, 18);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDays1Holiday4()
        {
            var dateReference = new DateTime(2015, 12, 21);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDays2Holidays1()
        {
            var dateReference = new DateTime(2014, 12, 22);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDays2Holidays2()
        {
            var dateReference = new DateTime(2015, 12, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDays3Holiday()
        {
            var dateReference = new DateTime(2014, 12, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDaysNoHoliday()
        {
            var dateReference = new DateTime(2015, 01, 06);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-13"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDaysNormal()
        {
            var dateReference = new DateTime(2015, 07, 16);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-23"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void FuturWorkingDaysWeekEnd()
        {
            var dateReference = new DateTime(2015, 01, 05);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-12"), managementHelper.FuturWorkingDays(dateReference, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PastWorkingDaysNegativeValue()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            managementHelper.PastWorkingDays(dateReference, -5);
        }

        [TestMethod]
        public void PastWorkingDays1Holiday()
        {
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays1Holiday2()
        {
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays1Holiday3()
        {
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-18"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays1Holiday4()
        {
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays2Holidays1()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-22"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays2Holidays2()
        {
            var dateReference = new DateTime(2016, 01, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays3Holiday()
        {
            var dateReference = new DateTime(2015, 01, 02);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-24"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDaysNoHoliday()
        {
            var dateReference = new DateTime(2015, 01, 13);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDaysNormal()
        {
            var dateReference = new DateTime(2015, 07, 23);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-07-16"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDaysWeekEnd()
        {
            var dateReference = new DateTime(2015, 01, 12);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-05"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod()]
        public void GetSpanDatesNormal()
        {
            var dateReference = new DateTime(2016, 04, 04);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2016-04-11"), result.Max());
        }

        [TestMethod()]
        public void GetSpanDatesWeekEnd()
        {
            var dateReference = new DateTime(2016, 04, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2016-04-15"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates1Holiday()
        {
            var dateReference = new DateTime(2014, 12, 31);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2015-01-08"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates1Holiday2()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2015-01-07"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates1Holiday3()
        {
            var dateReference = new DateTime(2015, 12, 18);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates1Holiday4()
        {
            var dateReference = new DateTime(2015, 12, 21);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates2Holidays1()
        {
            var dateReference = new DateTime(2014, 12, 22);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates2Holidays2()
        {
            var dateReference = new DateTime(2015, 12, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2016-01-04"), result.Max());
        }

        [TestMethod]
        public void GetSpanDates3Holiday()
        {
            var dateReference = new DateTime(2014, 12, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            var result = managementHelper.GetSpanDates(dateReference, 5);

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(Convert.ToDateTime("2015-01-02"), result.Max());
        }
    }
}