// <copyright file="CoffeeDiscount.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores information about the coffee discount and the method it can operate.
    /// </summary>
    public class CoffeeDiscount : IPriceRuleDiscount
    {
        /// <summary>
        /// Stores the target coffee that will apply the discount to.
        /// </summary>
        protected string? target;

        /// <summary>
        /// Stores the discount price that will be discounted from the target coffee's price.
        /// </summary>
        protected double? discountPrice;

        /// <summary>
        /// Stores the duration of the current discount.
        /// </summary>
        protected int? duration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoffeeDiscount"/> class.
        /// Initializes the coffee discount with the target coffee and the discount price.
        /// </summary>
        /// <param name="newTargetCoffee"> The coffee that will apply the discount to.</param>
        /// <param name="newDiscountPrice"> The discount price that is applied.</param>
        /// <param name="newDuration"> The duration of this diacount.</param>
        public CoffeeDiscount(string? newTargetCoffee, double? newDiscountPrice, int? newDuration)
        {
            if (newDiscountPrice < 0)
            {
                newDiscountPrice = 0;
            }

            this.target = newTargetCoffee;
            this.discountPrice = newDiscountPrice;
            this.duration = newDuration;
        }

        /// <summary>
        /// Check if the subscription is applicable for the discount.
        /// </summary>
        /// <param name="subscription"> The subscription that is being checked.</param>
        /// <returns> true or false of if the discount is applying to the subscription or not.</returns>
        public bool CheckDiscountApply(Subscription? subscription)
        {
            // Check if the subscription is null
            if (subscription == null)
            {
                return false;
            }

            // Check if the coffee name is the same as target
            if (subscription?.Coffee?.Name == this.target)
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
            if (subscription?.Coffee?.Name == this.target)
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
        /// Gets the target of this discount rule.
        /// </summary>
        /// <returns> Gets the current rule's target.</returns>
        public string? GetTarget()
        {
            return this.target;
        }

        /// <summary>
        /// Gets the discount price of this discount rule.
        /// </summary>
        /// <returns> Gets the current rule's discount price.</returns>
        public double? GetDiscountPrice()
        {
            return this.discountPrice;
        }
    }
}
