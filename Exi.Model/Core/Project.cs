using System;
using System.Collections.Generic;
using System.Linq;

namespace Exi.Model.Core
{
    public abstract class Project
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dead line.
        /// </summary>
        /// <value>
        /// The dead line.
        /// </value>
        public DateTime DeadLine { get; set; }

        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public List<IDivisible> Parts { get; set; }

        /// <summary>
        /// Gets the overall progress.
        /// </summary>
        /// <value>
        /// The overall progress.
        /// </value>
        public int OverallProgress => (this.Parts.Sum(x => x.Progress / (this.Parts.Count * 100)));
    }
}
