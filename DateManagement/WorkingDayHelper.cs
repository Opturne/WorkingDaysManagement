using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingDaysManagement
{
    /// <summary>
    /// Helper into managing working days
    /// </summary>
    public class WorkingDayHelper
    {
        private static List<DateTime> _defaultHolidays = new List<DateTime>();

        private static List<DayOfWeek> _defaultWeekEnd = new List<DayOfWeek>
        {
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };

        public readonly List<DateTime> ListHolidays;

        public readonly List<DayOfWeek> ListWeekEnd;

        public WorkingDayHelper()
            : this(_defaultHolidays, _defaultWeekEnd)
        {
        }

        public WorkingDayHelper(IEnumerable<DateTime> listHolidays)
            : this(listHolidays, _defaultWeekEnd)
        {
        }

        public WorkingDayHelper(IEnumerable<DayOfWeek> listWeekEnd)
            : this(_defaultHolidays, listWeekEnd)
        {
        }

        public WorkingDayHelper(IEnumerable<DateTime> listHolidays, IEnumerable<DayOfWeek> listWeekEnd)
        {
            if (listHolidays == null)
                throw new ArgumentNullException(nameof(listHolidays));

            if (listWeekEnd == null)
                throw new ArgumentNullException(nameof(listWeekEnd));

            ListHolidays = listHolidays.ToList();
            ListWeekEnd = listWeekEnd.ToList();
        }

        /// <summary>
        /// Return the last working day closest to dateReference (including it)
        /// </summary>
        public DateTime GetLast(DateTime dateReference)
        {
            var dateResult = dateReference;

            while (!IsWorkingDay(dateResult))
            {
                dateResult = dateResult.AddDays(-1);
            }

            return dateResult;
        }

        /// <summary>
        /// Return the next working day closest to dateReference (including it)
        /// </summary>
        public DateTime GetNext(DateTime dateReference)
        {
            var dateResult = dateReference;

            while (!IsWorkingDay(dateResult))
            {
                dateResult = dateResult.AddDays(1);
            }

            return dateResult;
        }

        /// <summary>
        /// Return a list of working days to the dateReference. If days is negative, then it's the
        /// days before.
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetSpanDates(DateTime dateReference, int days)
        {
            var listDate = new List<DateTime>();

            var dayTemp = dateReference;
            listDate.Add(dayTemp);

            if (days > 0)
            {
                for (var i = 0; i < days; i++)
                {
                    dayTemp = GetTomorrow(dayTemp);
                    listDate.Add(dayTemp);
                }
            }
            else
            {
                for (var i = 0; i < -days; i++)
                {
                    dayTemp = GetYesterday(dayTemp);
                    listDate.Add(dayTemp);
                }
            }

            return listDate;
        }

        /// <summary>
        /// Return the number of days between the dateReference and the next max working day of the span
        /// </summary>
        /// <returns></returns>
        public int GetSpanDays(DateTime dateReference, TimeSpan span)
        {
            var newDay = dateReference.Add(span);

            return (GetNext(newDay) - dateReference).Days;
        }

        /// <summary>
        /// Return the last working day of the interval
        /// </summary>
        /// <returns></returns>
        public DateTime GetSpanEnd(DateTime dateReference, TimeSpan span)
        {
            DateTime dateResult;
            if (dateReference.Add(span) > dateReference)
            {
                dateResult = dateReference.Add(span);
            }
            else
            {
                dateResult = dateReference;
            }

            return GetNext(dateResult);
        }

        /// <summary>
        /// Return the first working day of the interval
        /// </summary>
        /// <returns></returns>
        public DateTime GetSpanStart(DateTime dateReference, TimeSpan span)
        {
            DateTime dateResult;
            if (dateReference.Add(span) > dateReference)
            {
                dateResult = dateReference;
            }
            else
            {
                dateResult = dateReference.Add(span);
            }

            return GetLast(dateResult);
        }

        /// <summary>
        /// Get the date x working days in the past
        /// </summary>
        /// <param name="dateReference"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public DateTime PastWorkingDays(DateTime dateReference, int days)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException(nameof(days));

            var dateResult = dateReference;

            for (var i = 0; i < days; i++)
            {
                dateResult = GetYesterday(dateResult);
            }

            return dateResult;
        }

        /// <summary>
        /// Get the date x working days in the futur
        /// </summary>
        /// <param name="dateReference"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public DateTime FuturWorkingDays(DateTime dateReference, int days)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException(nameof(days));

            var dateResult = dateReference;

            for (var i = 0; i < days; i++)
            {
                dateResult = GetTomorrow(dateResult);
            }

            return dateResult;
        }

        /// <summary>
        /// Return the next working day after dateReference
        /// </summary>
        /// <param name="dateReference"></param>
        /// <returns></returns>
        public DateTime GetTomorrow(DateTime dateReference)
        {
            var tomorrow = dateReference.AddDays(1);

            return GetNext(tomorrow);
        }

        /// <summary>
        /// Return the last working day before dateReference
        /// </summary>
        /// <returns></returns>
        public DateTime GetYesterday(DateTime dateReference)
        {
            var previousDay = dateReference.AddDays(-1);

            return GetLast(previousDay);
        }

        /// <summary>
        /// Is dateReference a working day?
        /// </summary>
        /// <param name="dateReference"></param>
        /// <returns></returns>
        public bool IsWorkingDay(DateTime dateReference)
        {
            return ListHolidays.All(row => row != dateReference)
                && ListWeekEnd.All(row => row != dateReference.DayOfWeek);
        }

        /// <summary>
        /// Return Easter Day for the year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime EasterDay(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));

            int day = i - (year + year / 4 + i + 2 - c + c / 4) % 7 + 28;
            int month = 3;
            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }
    }
}