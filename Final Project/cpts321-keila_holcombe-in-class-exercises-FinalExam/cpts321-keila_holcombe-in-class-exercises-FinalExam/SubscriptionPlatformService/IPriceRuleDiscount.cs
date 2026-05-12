// <copyright file="IPriceRuleDiscount.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Interface of where all the rule of discounts is inheriting from and has all the method that each rule should contain.
    /// </summary>
    public interface IPriceRuleDiscount
    {
        /// <summary>
        /// Calculates the priec after the discount based on what discount rule applies to the subscription.
        /// </summary>
        /// <param name="subscription"> The subscription that will be checked for discount.</param>
        /// <param name="price"> The original price that is being calculated for discount.</param>
        /// <returns> The price after the discount.</returns>
        double? CalculateDiscount(Subscription? subscription, double? price);

        /// <summary>
        /// Check if the current subscription applies for a discount.
        /// </summary>
        /// <param name="subscription"> The subscription that it's checking.</param>
        /// <returns> true or false of if the discount applies.</returns>
        bool CheckDiscountApply(Subscription? subscription);

        /// <summary>
        /// Gets the target of what this discount will apply to.
        /// </summary>
        /// <returns> The target of the discount.</returns>
        string? GetTarget();

        /// <summary>
        /// Gets the discount price of this discount.
        /// </summary>
        /// <returns> The discount value.</returns>
        double? GetDiscountPrice();
    }
}
