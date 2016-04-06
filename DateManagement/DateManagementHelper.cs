using System;
using System.Collections.Generic;
using System.Linq;

namespace DateManagement
{
    public class DateManagementHelper
    {
        public readonly List<DateTime> ListHolidays;

        public DateManagementHelper(List<DateTime> listHolidays)
        {
            ListHolidays = listHolidays;
        }

        /// <summary>
        /// Return the last working day of the interval
        /// </summary>
        /// <returns></returns>
        public DateTime GetEndInterval(DateTime dateReference, TimeSpan span)
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

            return GetLastWorkingDay(maxDate);
        }

        /// <summary>
        /// Return the last working day closest to dateReference
        /// </summary>
        public DateTime GetLastWorkingDay(DateTime dateReference)
        {
            var lastWorkingDay = dateReference;

            while (IsHoliday(lastWorkingDay) || lastWorkingDay.DayOfWeek == DayOfWeek.Saturday || lastWorkingDay.DayOfWeek == DayOfWeek.Sunday)
            {
                lastWorkingDay = lastWorkingDay.AddDays(-1);
            }

            return lastWorkingDay;
        }

        /// <summary>
        /// Retourne la liste des dates du stock (hors férié et week-end)
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetListDatesStock(DateTime dateReference, TimeSpan span)
        {
            var listDate = new List<DateTime>();

            for (var date = GetStartInterval(dateReference, span); date <= GetYesterdayWorkingDay(dateReference); date = date.AddDays(1))
            {
                if (!IsHoliday(date) && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    listDate.Add(date);
            }
            return listDate;
        }

        /// <summary>
        /// Return the next working day closest to dateReference
        /// </summary>
        public DateTime GetNextWorkingDay(DateTime dateReference)
        {
            var nextWorkingDay = dateReference;

            while (IsHoliday(nextWorkingDay) || nextWorkingDay.DayOfWeek == DayOfWeek.Saturday || nextWorkingDay.DayOfWeek == DayOfWeek.Sunday)
            {
                nextWorkingDay = nextWorkingDay.AddDays(1);
            }

            return nextWorkingDay;
        }

        /// <summary>
        /// Return the number of days before the next working day in exactly one year
        /// </summary>
        /// <returns></returns>
        public double GetNextWorkingDayInOneYear(DateTime dateReference)
        {
            var dayAndOneYear = dateReference.AddYears(1);

            while (IsHoliday(dayAndOneYear) || dayAndOneYear.DayOfWeek == DayOfWeek.Saturday || dayAndOneYear.DayOfWeek == DayOfWeek.Sunday)
            {
                dayAndOneYear = GetNextWorkingDay(dayAndOneYear);
            }

            return (dayAndOneYear - dateReference).TotalDays;
        }

        /// <summary>
        /// Return the first working day of the interval
        /// </summary>
        /// <returns></returns>
        public DateTime GetStartInterval(DateTime dateReference, TimeSpan span)
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

            return GetYesterdayWorkingDay(minDate);
        }

        /// <summary>
        /// Retourne le prochain jour travaillé suivant le jour passé en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetTomorrowWorkingDay(DateTime date)
        {
            var tomorrow = date.DayOfWeek == DayOfWeek.Friday
                ? date.AddDays(3)
                : date.AddDays(1);

            return GetNextWorkingDay(tomorrow);
        }

        /// <summary>
        /// Retourne le dernier jour travaillé précédent le jour passé en parametre
        /// </summary>
        /// <returns></returns>
        public DateTime GetYesterdayWorkingDay(DateTime date)
        {
            var previousDay = date.DayOfWeek == DayOfWeek.Monday
                    ? date.AddDays(-3)
                    : date.AddDays(-1);

            return GetLastWorkingDay(previousDay);
        }

        /// <summary>
        /// Retourne True si le jour est férié
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsHoliday(DateTime date)
        {
            return ListHolidays.Any(row => row == date);
        }
    }
}