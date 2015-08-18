using Exi.Model.Core;

namespace Exi.Model.Planning
{
    public class Pensum
    {
        /// <summary>
        /// Gets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        private readonly IDivisible subject;

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get; private set; }

        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        /// <value>
        /// The name of the subject.
        /// </value>
        public string SubjectName => this.subject.Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pensum"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="amount">The amount.</param>
        public Pensum(IDivisible subject, int amount)
        {
            this.subject = subject;
            this.Amount = amount;
        }
    }
}
