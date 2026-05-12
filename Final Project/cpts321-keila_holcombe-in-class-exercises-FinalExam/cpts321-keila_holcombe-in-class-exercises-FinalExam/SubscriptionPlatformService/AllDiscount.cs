// <copyright file="AllDiscount.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores the information about the alldiscount object and the methods.
    /// </summary>
    internal class AllDiscount : IPriceRuleDiscount
    {
        /// <summary>
        /// Stores the discounted price that will be discounted from the original price.
        /// </summary>
        protected double discountPrice;

        /// <summary>
        /// Stores the duration of the discount rule.
        /// </summary>
        protected int duration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllDiscount"/> class.
        /// Initialize the new discount price for the AllDiscount object.
        /// </summary>
        /// <param name="newDiscountPrice"> The discount price of the rule.</param>
        /// <param name="newDuration"> The duration of the rule.</param>
        public AllDiscount(double newDiscountPrice, int newDuration)
        {
            if (newDiscountPrice < 0)
            {
                newDiscountPrice = 0;
            }

            this.discountPrice = newDiscountPrice;
            this.duration = newDuration;
        }

        /// <summary>
        /// All discount will apply if the subscription is not null.
        /// </summary>
        /// <param name="subscription"> The subscription that is being checked.</param>
        /// <returns> True or false about if the discount will apply or not.</returns>
        public bool CheckDiscountApply(Subscription? subscription)
        {
            // If subscriptio is null, return false, otherwise return true
            if (subscription == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Apply the discount to the price and return the discounted price. And this is applied to all subscription.
        /// </summary>
        /// <param name="subscription"> The subscription that the discount is applying to.</param>
        /// <param name="price"> The price that will be discounted.</param>
        /// <returns> The discounted price.</returns>
        public double? CalculateDiscount(Subscription? subscription, double? price)
        {
            // Apply the discount
            double? afterPrice = price - this.discountPrice;

            // If the discounted price is negative, make it 0
            if (afterPrice < 0)
            {
                afterPrice = 0;
            }

            return afterPrice;
        }

        /// <summary>
        /// Gets the target but since this class doesn't store a target, it will return null.
        /// </summary>
        /// <returns> Will return null since this discount doesn't have any target.</returns>
        public string? GetTarget()
        {
            return null;
        }

        /// <summary>
        /// Gets the discount price that is stored.
        /// </summary>
        /// <returns> The current discount price.</returns>
        public double? GetDiscountPrice()
        {
            return this.discountPrice;
        }
    }
}
