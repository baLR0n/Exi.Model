using System;
using System.Collections.Generic;
using System.Linq;
using Exi.Model.Core;

namespace Exi.Model.Planning
{
    public class ScheduleCreator
    {
        /// <summary>
        /// Creates the schedule list.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="deadLine">The dead line.</param>
        /// <param name="freeDays">The free days.</param>
        /// <param name="parts">The parts.</param>
        /// <returns></returns>
        public List<WeekSchedule> CreateScheduleList(DateTime startDate, DateTime deadLine, IEnumerable<DayOfWeek> freeDays, List<IDivisible> parts)
        {
            // Get dates and numbers
            return this.CreateScheduleBruteForce(startDate, deadLine, freeDays, parts);
        }

        /// <summary>
        /// Creates the schedule brute force.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="freeDays">The free days.</param>
        /// <param name="parts">The parts.</param>
        /// <param name="dayAmount">The day amount.</param>
        /// <returns></returns>
        private List<WeekSchedule> CreateScheduleBruteForce(DateTime startDate, DateTime deadLine, IEnumerable<DayOfWeek> freeDays, List<IDivisible> parts)
        {
            List<WeekSchedule> scheduleList = new List<WeekSchedule>();
            DateTime currentDate = startDate;
            WeekSchedule weekSchedule = new WeekSchedule(currentDate, freeDays);

            int partIndex = 0;

            int remainingBits = parts.Sum(x => x.PartAmount);
            int weeks = (deadLine.Subtract(startDate).Days/7);
            int weekRest = 7 - deadLine.Subtract(startDate.AddDays(weeks*7)).Days;

            int dayAmount = deadLine.Subtract(startDate).Days - (freeDays.Count()*weeks) + weekRest;
            int dailyBits = remainingBits/dayAmount;

            if (dailyBits == 0)
            {
                dailyBits = 1;
            }

            int pensumRest = remainingBits%dayAmount;

            do // Fill a pensum week for week until we´re finished.
            {
                List<Pensum> todaysPensum = new List<Pensum>();

                // Free day? Next day!
                if (freeDays.Contains(currentDate.DayOfWeek))
                {
                    currentDate = currentDate.AddDays(1);
                }
                // Less then daily bits? just the rest.
                if (remainingBits < dailyBits)
                {
                    dailyBits = remainingBits;
                }

                if (pensumRest > 0)
                {
                    todaysPensum.Add(new Pensum(parts[partIndex], dailyBits + 1));
                    remainingBits -= (dailyBits + 1);
                    pensumRest--;
                }
                else
                {
                    todaysPensum.Add(new Pensum(parts[partIndex], dailyBits));
                    remainingBits -= dailyBits;
                }

                // Add this day to the weekly pensum.
                weekSchedule.SetDay(todaysPensum, currentDate.DayOfWeek);

                // Check if this week is over or if the chapter was completely planned.
                if (currentDate.DayOfWeek.Equals(this.getLastWorkDay(freeDays)) && partIndex < parts.Count -1)
                {
                    // Get ready for next week. Add 1 day to sunday´s date and add the week to the schedule-list.
                    scheduleList.Add(weekSchedule);
                    currentDate = currentDate.AddDays(1);
                    weekSchedule = new WeekSchedule(currentDate, freeDays);
                }
                if (remainingBits <= 0)
                {
                    // Start next part or finish the planning if no part is left.
                    if (partIndex >= parts.Count - 1)
                    {
                        scheduleList.Add(weekSchedule);
                        break;
                    }

                    partIndex++;
                    remainingBits = parts[partIndex].PartAmount;
                }

                // Next day!
                currentDate = currentDate.AddDays(1);
                dayAmount--;
            } while (dayAmount > 0);

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
