namespace Exi.Model.Core
{
    public class Chapter : IDivisible
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Chapter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parts">The amount of parts.</param>
        public Chapter(string name, int parts)
        {
            this.Name = name;
            this.PartAmount = parts;
        }

        /// <summary>
        /// Gets or sets the name of the chapter.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the page amount.
        /// </summary>
        /// <value>
        /// The page amount.
        /// </value>
        public int PartAmount { get; set; }

        /// <summary>
        /// Gets or sets the amount of parts done.
        /// </summary>
        /// <value>
        /// The parts done.
        /// </value>
        public int PartsDone { get; set; }

        /// <summary>
        /// Gets the progress of this chapter.
        /// </summary>
        public int Progress => (this.PartsDone/this.PartAmount)*100;
    }
}
