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
        public IDivisible Subject { get; private set; }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pensum"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="amount">The amount.</param>
        public Pensum(IDivisible subject, int amount)
        {
            this.Subject = subject;
            this.Amount = amount;
        }
    }
}
