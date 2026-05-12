// <copyright file="IRecommendation.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// A recommendation service which generates coffee recommendations.
    /// </summary>
    public interface IRecommendation
    {
        /// <summary>
        /// Recommends coffee recommendation based on their taste profile and past rating.
        /// THis method will have the current customer and the list of coffee.
        /// </summary>
        /// <param name="customer"> The current customer.</param>
        /// <param name="coffees"> All the coffee that exist in the system.</param>
        /// <returns> Returns the coffee in the order of top recommend to least recommend.</returns>
        List<Coffee>? GenerateRecommendation(Customer? customer, List<Coffee>? coffees);
    }
}
