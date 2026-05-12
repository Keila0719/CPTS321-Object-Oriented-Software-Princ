// <copyright file="BagSizeDiscount.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores the information about the bagsize discounts and the methods this discount rule can do.
    /// </summary>
    public class BagSizeDiscount : IPriceRuleDiscount
    {
        /// <summary>
        /// Stores the target bagsize that discount will be applyed to.
        /// </summary>
        protected string? target;

        /// <summary>
        /// The price that will be discounted from.
        /// </summary>
        protected double? discountPrice;

        /// <summary>
        /// Stores the duration of the discount.
        /// </summary>
        protected int? duration;

        /// <summary>
        /// Initializes a new instance of the <see cref="BagSizeDiscount"/> class.
        /// Initializes the BagSizeDiscount object with new TargetBagSize and DiscountPrice.
        /// </summary>
        /// <param name="newTarget"> The target value of the discount it will apply to.</param>
        /// <param name="newDiscountPrice"> The discount price of the discount rule.</param>
        /// <param name="newDuration"> The duration of the discount.</param>
        public BagSizeDiscount(string? newTarget, double? newDiscountPrice, int? newDuration)
        {
            if (newDiscountPrice < 0)
            {
                newDiscountPrice = 0;
            }

            this.target = newTarget;
            this.discountPrice = newDiscountPrice;
            this.duration = newDuration;
        }

        /// <summary>
        /// Checks if this discount will apply to the current subscription.
        /// </summary>
        /// <param name="subscription"> The subscription that is being checked.</param>
        /// <returns> True or false of if this discount applies.</returns>
        public bool CheckDiscountApply(Subscription? subscription)
        {
            // Check if the subscription is null
            if (subscription == null)
            {
                return false;
            }

            // Check if the bagsize is the same as the target.
            if (subscription?.BagSize?.BagSize.ToString() == this.target)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculating the discounted price if the subscription is applicable. If yes, discount the price.
        /// </summary>
        /// <param name="subscription"> The subscription that the discount is going to be applyed to.</param>
        /// <param name="price"> The price that is being discounted on.</param>
        /// <returns> The price after the discount is applyed to.</returns>
        public double? CalculateDiscount(Subscription? subscription, double? price)
        {
            double? afterPrice = price;

            // Try changing the targetBag as an int
            if (int.TryParse(this.target?.ToString(), out int targetBagSize))
            {
                // Check if the current subscription is applicable for the discount, if yes, apply the discount
                if (subscription?.BagSize?.BagSize == targetBagSize)
                {
                    afterPrice -= this.discountPrice;
                }
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
        /// <returns> The target of this discount rule.</returns>
        public string? GetTarget()
        {
            return this.target;
        }

        /// <summary>
        /// Gets the discount price of this discount rule.
        /// </summary>
        /// <returns> The discount price of this rule.</returns>
        public double? GetDiscountPrice()
        {
            return this.discountPrice;
        }
    }
}
