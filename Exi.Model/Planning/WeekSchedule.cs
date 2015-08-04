using System;
using System.Collections.Generic;
using System.Linq;

namespace Exi.Model.Planning
{
    public class WeekSchedule
    {
        public WeekSchedule(DateTime startDate, IEnumerable<DayOfWeek> freeDays)
        {
            this.FreeDays = freeDays;
            this.StartDate = startDate;
            this.EndDate = startDate.AddDays(7);
        }

        public WeekSchedule(DateTime startDate, DateTime endDate, IEnumerable<DayOfWeek> freeDays)
        {
            this.FreeDays = freeDays;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// Sets the week.
        /// </summary>
        /// <param name="pensums">The pensums.</param>
        public void SetWeek(List<List<Pensum>> pensums)
        {
            if (pensums.Count < 7)
            {
                return;
            }

            this.SetMonday(pensums[0]);
            this.SetTuesday(pensums[1]);
            this.SetWednesday(pensums[2]);
            this.SetThursday(pensums[3]);
            this.SetFriday(pensums[4]);
            this.SetSaturday(pensums[5]);
            this.SetSunday(pensums[6]);
        }

        /// <summary>
        /// Sets the monday.
        /// </summary>
        /// <param name="pensumMonday">The pensum monday.</param>
        public void SetMonday(List<Pensum> pensumMonday)
        {
            this.PensumMonday = pensumMonday;
        }

        /// <summary>
        /// Sets the tuesday.
        /// </summary>
        /// <param name="pensumTuesday">The pensum tuesday.</param>
        public void SetTuesday(List<Pensum> pensumTuesday)
        {
            this.PensumTuesday = pensumTuesday;
        }

        /// <summary>
        /// Sets the wednesday.
        /// </summary>
        /// <param name="pensumWednesday">The pensum wednesday.</param>
        public void SetWednesday(List<Pensum> pensumWednesday)
        {
            this.PensumWednesday = pensumWednesday;
        }

        /// <summary>
        /// Sets the thursday.
        /// </summary>
        /// <param name="pensumThursday">The pensum thursday.</param>
        public void SetThursday(List<Pensum> pensumThursday)
        {
            this.PensumThursday = pensumThursday;
        }

        /// <summary>
        /// Sets the friday.
        /// </summary>
        /// <param name="pensumFriday">The pensum friday.</param>
        public void SetFriday(List<Pensum> pensumFriday)
        {
            this.PensumFriday = pensumFriday;
        }

        /// <summary>
        /// Sets the saturday.
        /// </summary>
        /// <param name="pensumSaturday">The pensum saturday.</param>
        public void SetSaturday(List<Pensum> pensumSaturday)
        {
            this.PensumSaturday = pensumSaturday;
        }

        /// <summary>
        /// Sets the sunday.
        /// </summary>
        /// <param name="pensumSunday">The pensum sunday.</param>
        public void SetSunday(List<Pensum> pensumSunday)
        {
            this.PensumSunday = pensumSunday;
        }


        /// <summary>
        /// Gets the free days.
        /// </summary>
        /// <value>
        /// The free days.
        /// </value>
        public IEnumerable<DayOfWeek> FreeDays { get; private set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; set; }

        public IEnumerable<Pensum> PensumMonday { get; set; }
        public IEnumerable<Pensum> PensumTuesday{ get; set; }
        public IEnumerable<Pensum> PensumWednesday { get; set; }
        public IEnumerable<Pensum> PensumThursday { get; set; }
        public IEnumerable<Pensum> PensumFriday { get; set; }
        public IEnumerable<Pensum> PensumSaturday { get; set; }
        public IEnumerable<Pensum> PensumSunday { get; set; }

        /// <summary>
        /// Gets the amount of scheduled days.
        /// </summary>
        /// <value>
        /// The scheduled days.
        /// </value>
        public int ScheduledDays
        {
            get { return 7 - this.FreeDays.Count(); }
        }

    }
}
