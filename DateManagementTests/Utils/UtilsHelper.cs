using DateManagement;
using System;
using System.Collections.Generic;

namespace DateManagementTests.Utils
{
    public static class UtilsHelper
    {
        public static List<DateTime> listJourFeries = new List<DateTime>
        {
            new DateTime(2014,12,25),
            new DateTime(2015,01,01),
            new DateTime(2015,04,03),
            new DateTime(2015,04,06),
            new DateTime(2015,05,01),
            new DateTime(2015,12,25),
            new DateTime(2016,01,01),
            new DateTime(2016,03,25),
            new DateTime(2016,03,28),
            new DateTime(2016,12,26)
        };

        public static WorkingDayHelper CreateDateManagementHelper()
        {
            return new WorkingDayHelper(listJourFeries);
        }
    }
}