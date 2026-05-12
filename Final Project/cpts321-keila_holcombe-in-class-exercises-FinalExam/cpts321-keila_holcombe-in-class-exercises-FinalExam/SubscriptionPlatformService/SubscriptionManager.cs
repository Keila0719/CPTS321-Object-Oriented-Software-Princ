// <copyright file="SubscriptionManager.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SubscriptionPlatformService
{
    /// <summary>
    /// A user type subscriptionManager which stores method that this type of user can do.
    /// </summary>
    public class SubscriptionManager : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionManager"/> class.
        /// Initializes the subscriptionManager user with the inputted informations.
        /// </summary>
        /// <param name="newName"> The name of the user.</param>
        /// <param name="newPassword"> The password of this user.</param>
        /// <param name="newEmail"> The email of this user.</param>
        /// <param name="newDate"> The date of birth of this user.</param>
        /// <param name="newAddress"> The address of this user.</param>
        /// <param name="newPayment"> THe payment of this user.</param>
        /// <param name="newType"> The type of this user.</param>
        public SubscriptionManager(string newName, string newPassword, string newEmail, DateTime newDate, string newAddress, string newPayment, string newType)
            : base(newName, newPayment, newEmail, newDate, newAddress, newPayment, newType)
        {
        }

        /// <summary>
        /// Create the price rule discount based on the information inputted.
        /// </summary>
        /// <param name="priceRuleService"> The class of the priceruleservice.</param>
        /// <param name="apply"> The information of what it will be apply to.</param>
        /// <param name="target"> The target value of the rule.</param>
        /// <param name="discount"> THe discount price of the rule.</param>
        /// <param name="duration"> The duration of the discount rule.</param>
        /// <returns> True or false of if the price rule discount was successfully added.</returns>
        public bool CreatePriceRuleDiscount(PriceRuleService priceRuleService, string apply, string target, double discount, int duration)
        {
            // Create the price rule discount
            bool result = priceRuleService.CreatePriceRuleDiscount(apply, target, discount, duration);

            // If the result is true, notify the changes to the event
            if (result)
            {
                this.UIPropertyChanged("Price Rule");
                string description = string.Empty + apply + "; " + target + "; $" + discount + "; " + duration + "days";
                ActivityLog activityLog = new ActivityLog(this, "Price Rule Discount Added", description);
                this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Price Rule Discount Added"));
            }

            return result;
        }
    }
}
