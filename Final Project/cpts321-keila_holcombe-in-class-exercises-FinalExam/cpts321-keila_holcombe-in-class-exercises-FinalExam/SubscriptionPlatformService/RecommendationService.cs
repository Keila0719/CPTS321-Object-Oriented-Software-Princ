// <copyright file="RecommendationService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages the recommendations and generate recommendation by calling the method in recommendation.
    /// </summary>
    public class RecommendationService
    {
        /// <summary>
        /// Stores the recommendation type it will operate.
        /// </summary>
        protected IRecommendation? recommendation;

        /// <summary>
        /// Generates the recommendation of coffees based on the recommendation type it has.
        /// </summary>
        /// <param name="customer"> The current customer it's being recommended to.</param>
        /// <param name="coffees"> The list of coffees.</param>
        /// <returns> Coffee recommendation from top recommend to lowest.</returns>
        public List<Coffee>? GenerateRecommendation(Customer customer, List<Coffee> coffees)
        {
            // Cehck for any null
            if (customer != null || coffees != null)
            {
                return null;
            }

            // Use the method in recommendation to find the list of coffee recommendation
            return this.recommendation?.GenerateRecommendation(customer, coffees);
        }
    }
}
