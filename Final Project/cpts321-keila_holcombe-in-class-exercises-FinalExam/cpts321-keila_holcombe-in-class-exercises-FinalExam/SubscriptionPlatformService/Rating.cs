// <copyright file="Rating.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores information about the rating.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Stores the rate from 1 - 5 for the order.
        /// </summary>
        protected int? rate;

        /// <summary>
        /// Stores the feedback for the order.
        /// </summary>
        protected string feedback;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rating"/> class.
        /// Initializes the rating object with the rate and feedback.
        /// </summary>
        /// <param name="newRate"> The new rate of this rating.</param>
        /// <param name="newFeedback"> The new feedback of this rating.</param>
        public Rating(int? newRate, string newFeedback)
        {
            this.rate = newRate;
            this.feedback = newFeedback;
        }

        /// <summary>
        /// Gets the current rating's rate.
        /// </summary>
        public int? Rate
        {
            get => this.rate;
        }

        /// <summary>
        /// Gets the current rating's feedback.
        /// </summary>
        public string Feedback
        {
            get => this.feedback;
        }
    }
}
