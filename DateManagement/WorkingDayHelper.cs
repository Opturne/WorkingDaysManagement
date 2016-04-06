using System;
using System.Collections.Generic;
using System.Linq;

namespace DateManagement
{
    /// <summary>
    /// Helper into managing Working Days
    /// </summary>
    public class WorkingDayHelper
    {
        public readonly List<DateTime> ListHolidays;

        public WorkingDayHelper()
        {
            ListHolidays = new List<DateTime>();
        }

        public WorkingDayHelper(IEnumerable<DateTime> listHolidays)
        {
            if (listHolidays == null)
                throw new ArgumentNullException(nameof(listHolidays));
            ListHolidays = listHolidays.ToList();
        }

        /// <summary>
        /// Return the last working day closest to dateReference
        /// </summary>
        public DateTime GetLast(DateTime dateReference)
        {
            var lastWorkingDay = dateReference;

            while (!IsWorkingDay(lastWorkingDay))
            {
                lastWorkingDay = lastWorkingDay.AddDays(-1);
            }

            return lastWorkingDay;
        }

        /// <summary>
        /// Return the next working day closest to dateReference
        /// </summary>
        public DateTime GetNext(DateTime dateReference)
        {
            var nextWorkingDay = dateReference;

            while (!IsWorkingDay(nextWorkingDay))
            {
                nextWorkingDay = nextWorkingDay.AddDays(1);
            }

            return nextWorkingDay;
        }

        /// <summary>
        /// Return the DateTime list of the working days during the span
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetSpanDates(DateTime dateReference, TimeSpan span)
        {
            var listDate = new List<DateTime>();

            for (var date = GetSpanStart(dateReference, span); date <= GetYesterday(dateReference); date = date.AddDays(1))
            {
                if (IsWorkingDay(date))
                    listDate.Add(date);
            }
            return listDate;
        }

        /// <summary>
        /// Return the number of days between the dateReference and the next max working day of the span
        /// </summary>
        /// <returns></returns>
        public double GetSpanDays(DateTime dateReference, TimeSpan span)
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
            DateTime maxDate;
            DateTime minDate;
            if (dateReference.Add(span) > dateReference)
            {
                maxDate = dateReference.Add(span);
                minDate = dateReference;
            }
            else
            {
                maxDate = dateReference;
                minDate = dateReference.Add(span);
            }

            return GetNext(maxDate);
        }

        /// <summary>
        /// Return the first working day of the interval
        /// </summary>
        /// <returns></returns>
        public DateTime GetSpanStart(DateTime dateReference, TimeSpan span)
        {
            DateTime maxDate;
            DateTime minDate;
            if (dateReference.Add(span) > dateReference)
            {
                maxDate = dateReference.Add(span);
                minDate = dateReference;
            }
            else
            {
                maxDate = dateReference;
                minDate = dateReference.Add(span);
            }

            return GetLast(minDate);
        }

        public DateTime PastWorkingDays(DateTime dateReference, int days)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException(nameof(days));

            var dayResult = dateReference;

            for (var i = 0; i < days; i++)
            {
                dayResult = GetYesterday(dayResult);
            }

            return dayResult;
        }

        public DateTime FuturWorkingDays(DateTime dateReference, int days)
        {
            if (days < 0)
                throw new ArgumentOutOfRangeException(nameof(days));

            var dayResult = dateReference;

            for (var i = 0; i < days; i++)
            {
                dayResult = GetTomorrow(dayResult);
            }

            return dayResult;
        }

        /// <summary>
        /// Return the next working day after dateReference
        /// </summary>
        /// <param name="dateReference"></param>
        /// <returns></returns>
        public DateTime GetTomorrow(DateTime dateReference)
        {
            var tomorrow = dateReference.DayOfWeek == DayOfWeek.Friday
                ? dateReference.AddDays(3)
                : dateReference.AddDays(1);

            return GetNext(tomorrow);
        }

        /// <summary>
        /// Return the last working day before dateReference
        /// </summary>
        /// <returns></returns>
        public DateTime GetYesterday(DateTime dateReference)
        {
            var previousDay = dateReference.DayOfWeek == DayOfWeek.Monday
                    ? dateReference.AddDays(-3)
                    : dateReference.AddDays(-1);

            return GetLast(previousDay);
        }

        /// <summary>
        /// Is dateReference a holiday.
        /// </summary>
        /// <param name="dateReference"></param>
        /// <returns></returns>
        public bool IsWorkingDay(DateTime dateReference)
        {
            return ListHolidays.All(row => row != dateReference)
                && dateReference.DayOfWeek != DayOfWeek.Saturday
                && dateReference.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}