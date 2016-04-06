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

            while (IsHoliday(lastWorkingDay) || lastWorkingDay.DayOfWeek == DayOfWeek.Saturday || lastWorkingDay.DayOfWeek == DayOfWeek.Sunday)
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

            while (IsHoliday(nextWorkingDay) || nextWorkingDay.DayOfWeek == DayOfWeek.Saturday || nextWorkingDay.DayOfWeek == DayOfWeek.Sunday)
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
                if (!IsHoliday(date) && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
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

            return GetLast(maxDate);
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

            return GetYesterday(minDate);
        }

        /// <summary>
        /// Return the next working day after dateReference
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetTomorrow(DateTime date)
        {
            var tomorrow = date.DayOfWeek == DayOfWeek.Friday
                ? date.AddDays(3)
                : date.AddDays(1);

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
        public bool IsHoliday(DateTime dateReference)
        {
            return ListHolidays.Any(row => row == dateReference);
        }
    }
}