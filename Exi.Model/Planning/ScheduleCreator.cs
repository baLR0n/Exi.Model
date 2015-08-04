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
            int weekAmount = deadLine.Subtract(startDate).Days/7;
            int dayAmount = (weekAmount*7) - (weekAmount*freeDays.Count());

            return this.CreateScheduleBruteForce(startDate, freeDays, parts, dayAmount);
        }

        /// <summary>
        /// Creates the schedule brute force.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="freeDays">The free days.</param>
        /// <param name="parts">The parts.</param>
        /// <param name="dayAmount">The day amount.</param>
        /// <returns></returns>
        private List<WeekSchedule> CreateScheduleBruteForce(DateTime startDate, IEnumerable<DayOfWeek> freeDays, List<IDivisible> parts, int dayAmount)
        {
            List<WeekSchedule> scheduleList = new List<WeekSchedule>();
            foreach (IDivisible part in parts)
            {
                int remainingBits = part.PartAmount;
                int dailyBits = remainingBits/dayAmount;

                while (remainingBits > 0)
                {
                    WeekSchedule schedule = new WeekSchedule(startDate, freeDays);
                    List<List<Pensum>> pensumList = new List<List<Pensum>>(7);
                    for (int i = 0; i < 6; i++)
                    {
                        if (remainingBits > 0)
                        {
                            pensumList[i] = new List<Pensum>();
                            pensumList[i].Add(new Pensum(part, dailyBits));
                            remainingBits -= dailyBits;
                        }
                        else
                        {
                            pensumList[i] = new List<Pensum>();
                        }
                    }

                    schedule.SetWeek(pensumList);
                    scheduleList.Add(schedule);
                }
            }

            return scheduleList;
        }
    }
}
