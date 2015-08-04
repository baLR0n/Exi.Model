namespace Exi.Model.Core
{
    public interface IDivisible
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the part amount.
        /// </summary>
        /// <value>
        /// The part amount.
        /// </value>
        int PartAmount { get; set; }

        /// <summary>
        /// Gets or sets the parts done.
        /// </summary>
        /// <value>
        /// The parts done.
        /// </value>
        int PartsDone { get; set; }

        /// <summary>
        /// Gets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        int Progress { get; }
    }
}
