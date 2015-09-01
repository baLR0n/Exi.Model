using System;
using System.Collections.Generic;
using System.Linq;
using Exi.Model.Core;

namespace Exi.Model.Planning
{
    public class ScheduleCreator
    {
        /// <summary>
        /// Creates the default schedule list.
        /// Subjects are planned on after the other. Every day has a pensum.
        /// The pensum rest is added to the first day(s).
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="deadLine">The dead line.</param>
        /// <param name="freeDays">The free days.</param>
        /// <param name="parts">The parts.</param>
        /// <returns></returns>
        public List<ScheduleDay> CreateDefaultScheduleList(DateTime startDate, DateTime deadLine, IEnumerable<DayOfWeek> freeDays, List<IDivisible> parts)
        {
            // Get dates and numbers
            int totalParts = parts.Sum(x => x.PartAmount);
            int weeks = (deadLine.Subtract(startDate).Days / 7);
            int weekRest = 7 - deadLine.Subtract(startDate.AddDays(weeks * 7)).Days;
            int dayAmount = deadLine.Subtract(startDate).Days - (freeDays.Count() * weeks) + weekRest;

            int[] partsPerSubject = new int[parts.Count];
            for (int i = 0; i < parts.Count; i++)
            {
                partsPerSubject[i] = parts[i].PartAmount;
            }

            int dailyPensum = totalParts / dayAmount;
            int pensumRest = totalParts % dayAmount;

            List<ScheduleDay> scheduleList = new List<ScheduleDay>();
            DateTime currentDate = startDate;

            int currentPartIndex = 0;
            int currentPartProgress = partsPerSubject[0];

            while (deadLine >= currentDate)
            {
                ScheduleDay day = new ScheduleDay(currentDate);

                if (currentPartProgress - dailyPensum >= 0)
                {
                    day.Pensum.Add(new Pensum(parts[currentPartIndex], dailyPensum));
                    currentPartProgress -= dailyPensum;
                }
                else
                {
                    // * -1 because the rest value will be negative.
                    day.Pensum.Add(new Pensum(parts[currentPartIndex], currentPartProgress));
                    currentPartIndex++;
                    if (currentPartIndex.Equals(parts.Count))
                    {
                        scheduleList.Add(day);
                        break;
                    }

                    // Next subject to keep up dailypensum
                    day.Pensum.Add(new Pensum(parts[currentPartIndex], dailyPensum - currentPartProgress));
                    currentPartProgress = partsPerSubject[currentPartIndex] - (dailyPensum - currentPartProgress);
                }

                // Add pensum at the start.
                if (pensumRest > 0)
                {
                    day.Pensum.Last().Amount += pensumRest;
                    currentPartProgress -= pensumRest;
                    pensumRest = 0;
                }

                scheduleList.Add(day);
                currentDate = currentDate.AddDays(1);
            }

            return scheduleList;
        }

        /// <summary>
        /// Gets the last work day of a week.
        /// </summary>
        /// <param name="freeDays">The free days in a week.</param>
        /// <returns></returns>
        private DayOfWeek getLastWorkDay(IEnumerable<DayOfWeek> freeDays)
        {
            if (!freeDays.Contains(DayOfWeek.Sunday))
            {
                return DayOfWeek.Sunday;
            }
            if (!freeDays.Contains(DayOfWeek.Saturday))
            {
                return DayOfWeek.Saturday;
            }
            if (!freeDays.Contains(DayOfWeek.Friday))
            {
                return DayOfWeek.Friday;
            }
            if (!freeDays.Contains(DayOfWeek.Thursday))
            {
                return DayOfWeek.Thursday;
            }
            if (!freeDays.Contains(DayOfWeek.Wednesday))
            {
                return DayOfWeek.Wednesday;
            }
            if (!freeDays.Contains(DayOfWeek.Tuesday))
            {
                return DayOfWeek.Tuesday;
            }

            return DayOfWeek.Monday;
        }
    }
}
