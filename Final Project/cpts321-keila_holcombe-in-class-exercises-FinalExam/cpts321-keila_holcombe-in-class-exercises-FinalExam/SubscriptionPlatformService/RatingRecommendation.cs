// <copyright file="RatingRecommendation.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// A recommendation system where it will recommend customer with coffee based on their ratings.
    /// </summary>
    internal class RatingRecommendation : IRecommendation
    {
        /// <summary>
        /// Generate a recommendation of coffees based on the ratings.
        /// Since the assignment is telling to not implement, I have no implementation.
        /// </summary>
        /// <param name="customer"> The current customer who it's recommending to.</param>
        /// <param name="coffees"> The list of coffees.</param>
        /// <returns> All the recommended coffee from top recommend to low.</returns>
        public List<Coffee>? GenerateRecommendation(Customer? customer, List<Coffee>? coffees)
        {
            return null;
        }
    }
}
