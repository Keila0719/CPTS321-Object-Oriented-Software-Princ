// <copyright file="Order.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores information about the order class. FYI, the style cop made re-organized this class to be Order() and include everything inside there.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Order"/> class.
    /// Initialize the Order object with the subscription and the total price.
    /// </remarks>
    /// <param name="newSubscription"> The subscription that this order is based on.</param>
    /// <param name="newPrice"> The total price for this order.</param>
    public class Order(Subscription? newSubscription, double? newPrice)
    {
        /// <summary>
        /// Stores the subscription that this order is based on.
        /// </summary>
        protected Subscription? subscription = newSubscription;

        /// <summary>
        /// Stores the total price after the discount for this order.
        /// </summary>
        protected double? totalPrice = newPrice;

        /// <summary>
        /// Stores the rating of 1-5 for the order.
        /// </summary>
        protected Rating? rate;

        /// <summary>
        /// Gets the subscription that this order stores.
        /// </summary>
        public Subscription? Subscription
        {
            get => this.subscription;
        }

        /// <summary>
        /// Gets the total price this order stores.
        /// </summary>
        public double? TotalPrice
        {
            get => this.totalPrice;
        }

        /// <summary>
        /// Gets or sets and Sets the rate.
        /// </summary>
        public Rating? Rate
        {
            get => this.rate;
            set
            {
                this.rate = value;
            }
        }
    }
}
