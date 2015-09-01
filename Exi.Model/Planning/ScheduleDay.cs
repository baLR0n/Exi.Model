using System;
using System.Collections.Generic;

namespace Exi.Model.Planning
{
    public class ScheduleDay
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the pensum.
        /// </summary>
        /// <value>
        /// The pensum.
        /// </value>
        public List<Pensum> Pensum { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is free day.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is free day; otherwise, <c>false</c>.
        /// </value>
        public bool IsFreeDay { get; set; }

        /// <summary>
        /// The day of week
        /// </summary>
        public DayOfWeek DayOfWeek => this.Date.DayOfWeek;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleDay" /> class.
        /// </summary>
        /// <param name="date">The date.</param>
        public ScheduleDay(DateTime date)
        {
            this.Date = date;
            this.Pensum = new List<Pensum>();
        }
    }
}
