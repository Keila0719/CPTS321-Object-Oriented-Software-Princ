// <copyright file="Subscription.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores information about the subscription.
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Stores the strategy they used to generate this subscription.
        /// </summary>
        protected string? strategy;

        /// <summary>
        /// Stores the bag size per delivery of the current subscription.
        /// </summary>
        protected BagSizes? bagSize;

        /// <summary>
        /// Stores the coffee of the current subscription.
        /// </summary>
        protected Coffee? coffee;

        /// <summary>
        /// Stores the delivery frequency of the current subscription.
        /// </summary>
        protected string? frequency;

        /// <summary>
        /// Stores the start date of the current subscription.
        /// </summary>
        protected DateTime startDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// Initialize the subscription using the information of the current subscription's bag size per delivery, type of coffee delivery frequency, and start date.
        /// </summary>
        /// <param name="newStrategy"> The new subscription strategy.</param>
        /// <param name="newCoffee"> The new subscription's coffee.</param>
        /// /// <param name="newBagSize"> The new subscription delivery bag size.</param>
        /// <param name="newFrequency"> The new subscription delivery frequency.</param>
        /// <param name="newStartDate"> The new subscription start date.</param>
        public Subscription(string? newStrategy, Coffee? newCoffee, BagSizes? newBagSize, string? newFrequency, DateTime newStartDate)
        {
            this.strategy = newStrategy;
            this.bagSize = newBagSize;
            this.coffee = newCoffee;
            this.frequency = newFrequency;
            this.startDate = newStartDate;
        }

        /// <summary>
        /// Gets or sets the strategy that was used to select this subscription.
        /// </summary>
        public string? Strategy
        {
            get => this.strategy;
            set
            {
                this.strategy = value;
            }
        }

        /// <summary>
        /// Gets or sets the bag size per delivery of the current subscription.
        /// </summary>
        public BagSizes? BagSize
        {
            get => this.bagSize;
            set
            {
                this.bagSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of coffee of the current subscription.
        /// </summary>
        public Coffee? Coffee
        {
            get => this.coffee;
            set
            {
                this.coffee = value;
            }
        }

        /// <summary>
        /// Gets or sets the delivery frequency of the current subscription.
        /// </summary>
        public string? Frequency
        {
            get => this.frequency;
            set
            {
                this.frequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the start date of the current subscription.
        /// </summary>
        public DateTime StartDate
        {
            get => this.startDate;
            set
            {
                this.startDate = value;
            }
        }
    }
}
