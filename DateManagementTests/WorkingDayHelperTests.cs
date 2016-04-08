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
        public void GetLast1HolidayCas3()
        {
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast1HolidayCas4()
        {
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-29"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast2HolidaysCas1()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.GetLast(dateReference));
        }

        [TestMethod]
        public void GetLast2HolidaysCas2()
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
        public void GetSpanEnd1HolidayCas2()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd1HolidayCas3()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 19);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd1HolidayCas4()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-01-05"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd2HolidaysCas1()
        {
            var dureeStock = new TimeSpan(7, 0, 0, 0);
            var dateReference = new DateTime(2016, 03, 24);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2016-03-31"), managementHelper.GetSpanEnd(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanEnd2HolidaysCas2()
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
        public void GetSpanStart1HolidayCas2()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart1HolidayCas3()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart1HolidayCas4()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-22"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart2HolidaysCas1()
        {
            var dureeStock = new TimeSpan(-7, 0, 0, 0);
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-23"), managementHelper.GetSpanStart(dateReference, dureeStock));
        }

        [TestMethod]
        public void GetSpanStart2HolidaysCas2()
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
        public void GetYesterday1HolidayCas2()
        {
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-01-06"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday1HolidayCas3()
        {
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-24"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday1HolidayCas4()
        {
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-28"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday2HolidaysCas1()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-29"), managementHelper.GetYesterday(dateReference));
        }

        [TestMethod]
        public void GetYesterday2HolidaysCas2()
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
        public void PastWorkingDays1Holiday()
        {
            var dateReference = new DateTime(2015, 01, 08);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-31"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays1HolidayCas2()
        {
            var dateReference = new DateTime(2015, 01, 07);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-30"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays1HolidayCas3()
        {
            var dateReference = new DateTime(2015, 12, 28);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-18"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays1HolidayCas4()
        {
            var dateReference = new DateTime(2015, 12, 29);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2015-12-21"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays2HolidaysCas1()
        {
            var dateReference = new DateTime(2014, 12, 30);
            var managementHelper = UtilsHelper.CreateDateManagementHelper();

            Assert.AreEqual(Convert.ToDateTime("2014-12-22"), managementHelper.PastWorkingDays(dateReference, 5));
        }

        [TestMethod]
        public void PastWorkingDays2HolidaysCas2()
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
    }
}