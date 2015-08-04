using System.Collections.Generic;
using Exi.Model.Core;

namespace Exi.Model.Projects
{
    public class Exam : Project
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exam"/> class.
        /// </summary>
        /// <param name="chapters">The chapters.</param>
        public Exam(List<IDivisible> chapters = null)
        {
            this.Parts = chapters;
        }
    }
}
