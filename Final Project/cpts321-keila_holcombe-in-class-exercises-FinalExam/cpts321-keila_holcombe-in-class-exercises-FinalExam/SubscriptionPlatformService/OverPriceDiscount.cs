// <copyright file="OverPriceDiscount.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// A rule that applies when the subscription is over a specific price.
    /// </summary>
    public class OverPriceDiscount : IPriceRuleDiscount
    {
        /// <summary>
        /// Stores the discounted price.
        /// </summary>
        protected double? discountPrice;

        /// <summary>
        /// Store the target price that is going to be discounted to.
        /// </summary>
        protected string? target;

        /// <summary>
        /// Stores the duration of the discount.
        /// </summary>
        protected int? duration;

        /// <summary>
        /// Initializes a new instance of the <see cref="OverPriceDiscount"/> class.
        /// Initialize the OverPriceDiscount object with the new discountprice and targetprice.
        /// </summary>
        /// <param name="newDiscountPrice"> The new discount price.</param>
        /// <param name="newTargetPrice"> The new target price.</param>
        /// <param name="newDuration"> The new duration of price.</param>
        public OverPriceDiscount(string? newTargetPrice, double? newDiscountPrice, int? newDuration)
        {
            if (newDiscountPrice < 0)
            {
                newDiscountPrice = 0;
            }

            this.discountPrice = newDiscountPrice;
            this.target = newTargetPrice;
            this.duration = newDuration;
        }

        /// <summary>
        /// Check if this subscription applies to the current discount.
        /// </summary>
        /// <param name="subscription"> The subscription that is being checked.</param>
        /// <returns> True or false of if the subscription will apply to the discount.</returns>
        public bool CheckDiscountApply(Subscription? subscription)
        {
            // Check if the subscription is null
            if (subscription == null)
            {
                return false;
            }

            // Check if it matches the target.
            if (subscription?.BagSize?.Price.ToString() == this.target)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculate if the subscription is eligible for the discount, if yes, apply the discount to the price.
        /// This discount is applied to all subscription that is over the target price.
        /// </summary>
        /// <param name="subscription"> The subscription that is getting the discount.</param>
        /// <param name="price"> The price it is discounting.</param>
        /// <returns> The discounted price, or if not applicable, the original price.</returns>
        public double? CalculateDiscount(Subscription? subscription, double? price)
        {
            double? afterPrice = price;

            // Check if the current subscription is applicable for the discount, if yes, apply the discount
            if (subscription?.BagSize?.Price.ToString() == this.target)
            {
                afterPrice -= this.discountPrice;
            }

            // If the discounted price is negative, make it 0
            if (afterPrice < 0)
            {
                afterPrice = 0;
            }

            return afterPrice;
        }

        /// <summary>
        /// Gets the current target of this discount rule.
        /// </summary>
        /// <returns> The target value of this rule.</returns>
        public string? GetTarget()
        {
            return this.target;
        }

        /// <summary>
        /// Gets the current discount price of this discount rule.
        /// </summary>
        /// <returns> The discount price of this rule.</returns>
        public double? GetDiscountPrice()
        {
            return this.discountPrice;
        }
    }
}
