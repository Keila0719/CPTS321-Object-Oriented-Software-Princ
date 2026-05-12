// <copyright file="SubscriptionService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages the subscription and has method specific for subscriptions.
    /// </summary>
    public class SubscriptionService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionService"/> class.
        /// Initializes the subscriptionService.
        /// </summary>
        public SubscriptionService()
        {
        }

        /// <summary>
        /// Add a subscription to the list of subscriptions.
        /// </summary>
        /// <param name="subscription"> The subscription that is checking if it's valid.</param>
        /// <returns> True or false of if the subscription is valid.</returns>
        public bool CheckValidSubscription(Subscription subscription)
        {
            // Check if subscription is null
            if (subscription == null)
            {
                return false;
            }

            // Check if any information in subscription is null, in that case return false
            if (this.CheckNullSubscription(subscription))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checking if the subscription include any null information.
        /// </summary>
        /// <param name="subscription"> The subscription that is being checked.</param>
        /// <returns> True or false of if the subscription include null information.</returns>
        public bool CheckNullSubscription(Subscription subscription)
        {
            // Check if coffee information is null
            if (subscription.Coffee == null)
            {
                return true;
            }

            // Check if the bagsize is null
            if (subscription.BagSize == null)
            {
                return true;
            }

            // Check if the subscription frequency is null
            if (string.IsNullOrEmpty(subscription.Frequency))
            {
                return true;
            }

            // If it's all valid, return false
            return false;
        }
    }
}
