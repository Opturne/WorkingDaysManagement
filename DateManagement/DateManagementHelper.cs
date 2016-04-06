using System;
using System.Collections.Generic;
using System.Linq;

namespace DateManagement
{
    public class DateManagementHelper
    {
        private readonly DateTime _dateExecution;

        public readonly List<DateTime> ListJourFeries;

        public DateManagementHelper(List<DateTime> listJourFeries, DateTime dateExecution)
        {
            _dateExecution = dateExecution;
            ListJourFeries = listJourFeries;
        }

        /// <summary>
        /// Retourne le nombre de jours avant le prochain jour ouvré en J + 1 an
        /// </summary>
        /// <returns></returns>
        public double GetNbJoursAvantOuvreUnAn()
        {
            var jourPlusUnAn = _dateExecution.AddYears(1);

            if (IsFerie(jourPlusUnAn) || jourPlusUnAn.DayOfWeek == DayOfWeek.Saturday || jourPlusUnAn.DayOfWeek == DayOfWeek.Sunday)
            {
                jourPlusUnAn = GetLendemain(jourPlusUnAn);
            }

            return (jourPlusUnAn - _dateExecution).TotalDays;
        }

        /// <summary>
        /// Retourne la date la plus éloigné du stock
        /// </summary>
        /// <returns></returns>
        public DateTime GetDebutStock(int dureeStock)
        {
            var jourStock = GetJourStock();

            var nbrJourFerierDurantStock = ListJourFeries.Count(jf => jf.Date >= _dateExecution.AddDays(-dureeStock).Date && jf.Date <= _dateExecution.Date
                                            && jf.DayOfWeek != DayOfWeek.Saturday && jf.DayOfWeek != DayOfWeek.Sunday);

            var nbrJourWeekEnd = Enumerable
                .Range(0, nbrJourFerierDurantStock)
                .Select(x => _dateExecution.AddDays(-x))
                .Count(x => x.DayOfWeek == DayOfWeek.Saturday && x.DayOfWeek == DayOfWeek.Sunday);

            return GetDateMinJourTravaille(jourStock.AddDays(-dureeStock - nbrJourFerierDurantStock - nbrJourWeekEnd),
                jourStock.AddDays(-dureeStock - nbrJourFerierDurantStock - nbrJourWeekEnd));
        }

        /// <summary>
        /// Retourne la date du jour
        /// </summary>
        /// <returns></returns>
        public DateTime GetJourFlux()
        {
            return _dateExecution;
        }

        /// <summary>
        /// Retourne la date de début du stock
        /// </summary>
        public DateTime GetJourStock()
        {
            return GetDateMinJourTravaille(_dateExecution, _dateExecution);
        }

        /// <summary>
        /// Retourne la liste des dates du stock (hors férié et week-end)
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetListDatesStock(int dureeStock)
        {
            var listDate = new List<DateTime>();

            for (var date = GetDebutStock(dureeStock); date <= GetVeilleFlux(); date = date.AddDays(1))
            {
                if (!IsFerie(date) && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    listDate.Add(date);
            }
            return listDate;
        }

        /// <summary>
        /// Retourne le prochain jour travaillé suivant le jour passé en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetLendemain(DateTime date)
        {
            var lendemain = date.DayOfWeek == DayOfWeek.Friday
                ? date.AddDays(3)
                : date.AddDays(1);

            while (ListJourFeries.Any(jf => jf.Date == lendemain) || lendemain.DayOfWeek == DayOfWeek.Saturday || lendemain.DayOfWeek == DayOfWeek.Sunday)
            {
                lendemain = lendemain.AddDays(1);
            }

            return lendemain;
        }

        /// <summary>
        /// Retourne le dernier jour travaillé précédent le jour passé en parametre
        /// </summary>
        /// <returns></returns>
        public DateTime GetVeille(DateTime date)
        {
            var veilleFlux = date.DayOfWeek == DayOfWeek.Monday
                    ? date.AddDays(-3)
                    : date.AddDays(-1);

            return GetDateMinJourTravaille(veilleFlux, date);
        }

        public DateTime GetVeilleFlux()
        {
            return GetVeille(_dateExecution);
        }

        /// <summary>
        /// Retourne le dernier jour travaillé précédent le dernier jour du stock
        /// </summary>
        /// <returns></returns>
        public DateTime GetVeilleStock(int dureeStock)
        {
            return GetVeille(GetDebutStock(dureeStock));
        }

        public bool IsExecutionDateFerie()
        {
            return IsFerie(GetJourFlux());
        }

        /// <summary>
        /// Retourne True si le jour est férié
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsFerie(DateTime date)
        {
            return ListJourFeries.Any(row => row == date);
        }

        /// <summary>
        /// Retourne la derniere date travaillé (non weekend ni férié) au plus proche de la DateMin
        /// </summary>
        /// <param name="dateMin">Interval bas de date</param>
        /// <param name="dateMax">Interval haut de date</param>
        /// <returns></returns>
        private DateTime GetDateMinJourTravaille(DateTime dateMin, DateTime dateMax)
        {
            var nbrJourChaume = ListJourFeries.Count(jf => jf.Date >= dateMin.Date && jf.Date <= dateMax.Date
                                                            && jf.DayOfWeek != DayOfWeek.Saturday && jf.DayOfWeek != DayOfWeek.Sunday);

            if (nbrJourChaume > 1) nbrJourChaume++; //Si plus d'un jour férié, alors le décompte de la veille disparait

            var resultat = dateMin.AddDays(-nbrJourChaume);

            if (resultat.DayOfWeek == DayOfWeek.Saturday || resultat.DayOfWeek == DayOfWeek.Sunday || ListJourFeries.Any(jf => jf.Date == resultat.Date))
                resultat = GetDateMinJourTravaille(resultat.AddDays(-1), resultat.AddDays(-1));

            return resultat;
        }
    }
}