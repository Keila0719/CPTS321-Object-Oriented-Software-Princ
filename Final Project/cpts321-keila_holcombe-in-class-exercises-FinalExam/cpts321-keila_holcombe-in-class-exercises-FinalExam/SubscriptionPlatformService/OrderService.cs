// <copyright file="OrderService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages all the orders and has method to manage them.
    /// </summary>
    public class OrderService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// Initializes the order class.
        /// </summary>
        public OrderService()
        {
        }

        /// <summary>
        /// Rate the current order with the information inputted.
        /// </summary>
        /// <param name="order"> The order that is being rated.</param>
        /// <param name="rate"> The rate of 1-5.</param>
        /// <param name="feedback">The feedback of the order.</param>
        /// <returns> True or false of if it was able to rate the order.</returns>
        public bool RateOrder(Order order, int? rate, string feedback)
        {
            // If any of the input is null or empty, return false;
            if (rate == null || string.IsNullOrEmpty(feedback) || order == null)
            {
                return false;
            }

            // Check if the rate is within 1-5.
            if (rate > 5 || rate < 1)
            {
                return false;
            }

            // Create a rate and add to the order
            Rating rating = new Rating(rate, feedback);
            order.Rate = rating;
            return true;
        }
    }
}
