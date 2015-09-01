using System;
using System.Collections.Generic;
using System.Linq;
using Exi.Model.Core;

namespace Exi.Model.Planning
{
    public class Plan
    {
        /// <summary>
        /// The schedule creator
        /// </summary>
        private readonly ScheduleCreator scheduleCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Plan"/> class.
        /// </summary>
        /// <param name="project">The project.</param>
        public Plan(Project project)
        {
            this.Project = project;
            this.scheduleCreator = new ScheduleCreator();

            this.Schedule = new List<ScheduleDay>();
        }

        /// <summary>
        /// Creates a new schedule list.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="deadLine">The dead line.</param>
        /// <param name="freeDays">The days per week which should be free.</param>
        public void CreateScheduleList(DateTime startDate, DateTime deadLine, IEnumerable<DayOfWeek> freeDays)
        {
            this.StartDate = startDate;
            if (deadLine <= startDate)
            {
                return;
            }

            this.DeadLine = deadLine;
            this.Schedule = this.scheduleCreator.CreateDefaultScheduleList(startDate, deadLine, freeDays, this.Project.Parts);
        }


        /// <summary>
        /// Replaces the schedule at the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="newSchedule">The new schedule.</param>
        public void ReplaceSchedule(DateTime date, ScheduleDay newSchedule)
        {
            if (this.Schedule.Any(x => x.Date.Equals(date)))
            {
                // Replace schedule day.
                this.Schedule[this.Schedule.IndexOf(this.Schedule.FirstOrDefault(x => x.Date.Equals(date)))] = newSchedule;
            }
        }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        public Project Project{get; private set; }

        /// <summary>
        /// Gets the dead line.
        /// </summary>
        /// <value>
        /// The dead line.
        /// </value>
        public DateTime DeadLine { get; private set; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Gets the schedule.
        /// </summary>
        /// <value>
        /// The schedule.
        /// </value>
        public List<ScheduleDay> Schedule { get; private set; }
    }
}
