using System.Data.SqlTypes;

namespace UtilitiesLib
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Compare two nullable dates
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool Equals(this DateTime? date1, DateTime? date2)
        {
            return date1 == null && date2 == null
                   || date1.HasValue && date2.HasValue && date1.Value.Date == date2.Value.Date;
        }

        /// <summary>
        /// Is date in the acceptable range of dates accepted by SQL Server
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsValidSqlDateTime(this DateTime date)
        {
            return date >= SqlDateTime.MinValue.Value && date <= SqlDateTime.MaxValue.Value;
        }

        /// <summary>
        /// Due Date offset logic to calculate the next workday. Offset unit is in workdays.
        /// If the offset is positive, we just skip weekends, for negative offset, we move to next working day
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="numberOfDays"></param>
        /// <param name="usingCalendarDays">Use Calendar Days in-lieu of workdays for calculation</param>
        /// <param name="resetToNextWorkDayForNegativeOffset"></param>
        /// <returns></returns>
        public static DateTime AddWorkdays(this DateTime originalDate, int numberOfDays, bool usingCalendarDays = false, bool resetToNextWorkDayForNegativeOffset = true)
        {
            if (numberOfDays == 0)
                return originalDate;

            var numberOfDaysCopy = numberOfDays;
            DateTime calculatedDate;

            int calculatedNumberOfDays = numberOfDays;
            if (numberOfDays > 0)
            {
                if (!usingCalendarDays)
                {
                    calculatedDate = originalDate;
                    while (numberOfDaysCopy != 0)
                    {
                        calculatedDate = calculatedDate.DayOfWeek switch
                        {
                            DayOfWeek.Saturday => calculatedDate.AddDays(2),
                            //this if block should never be executed but here for bad dates
                            DayOfWeek.Sunday => calculatedDate.AddDays(1),
                            _ => calculatedDate.AddDays(1)
                        };

                        numberOfDaysCopy--;
                    }
                }
                else
                    calculatedDate = originalDate.AddDays(calculatedNumberOfDays);

                return calculatedDate.DayOfWeek switch
                {
                    //Sat --> Mon, Sun --> Tue
                    DayOfWeek.Saturday => calculatedDate.AddDays(2),
                    DayOfWeek.Sunday => calculatedDate.AddDays(2),
                    _ => calculatedDate
                };
            }
            else
            {
                if (!usingCalendarDays)
                {
                    calculatedDate = originalDate;
                    while (numberOfDaysCopy != 0)
                    {
                        calculatedDate = calculatedDate.DayOfWeek switch
                        {
                            DayOfWeek.Sunday => calculatedDate.AddDays(-2),
                            //this if block should never be executed but here for bad dates
                            DayOfWeek.Saturday => calculatedDate.AddDays(-1),
                            _ => calculatedDate.AddDays(-1)
                        };

                        numberOfDaysCopy++;
                    }
                }
                else
                    calculatedDate = originalDate.AddDays(calculatedNumberOfDays);

                if (resetToNextWorkDayForNegativeOffset && calculatedDate <= DateTime.Today)
                    calculatedDate = DateTime.Today;

                return calculatedDate.DayOfWeek switch
                {
                    //Sat --> Mon, Sun --> Mon
                    DayOfWeek.Saturday => calculatedDate.AddDays(2),
                    DayOfWeek.Sunday => calculatedDate.AddDays(1),
                    _ => calculatedDate
                };
            }
        }
    }
}