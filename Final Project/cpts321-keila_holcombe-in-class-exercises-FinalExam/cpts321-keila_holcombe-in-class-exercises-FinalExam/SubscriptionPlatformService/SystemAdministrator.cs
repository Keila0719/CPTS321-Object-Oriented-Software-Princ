// <copyright file="SystemAdministrator.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// SystemAdministrator class that has all the action that system administrator can do.
    /// </summary>
    public class SystemAdministrator : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemAdministrator"/> class.
        /// Initializes the system administrator user with the input information.
        /// </summary>
        /// <param name="newName">The new name of the system administrator.</param>
        /// <param name="newPassword">The password for the system administrator.</param>
        /// <param name="newEmail">The email address of the system administrator.</param>
        /// <param name="newDate">The date of birth of the system administrator.</param>
        /// <param name="newAddress">The address of the system administrator.</param>
        /// <param name="newPayment">The payment method of the system administrator.</param>
        /// <param name="newType">The type of the system administrator.</param>
        public SystemAdministrator(string newName, string newPassword, string newEmail, DateTime newDate, string newAddress, string newPayment, string newType)
            : base(newName, newPayment, newEmail, newDate, newAddress, newPayment, newType)
        {
        }

        /// <summary>
        /// Add the activity history based on the activity log that is given.
        /// </summary>
        /// <param name="activityLog"> The change that happened.</param>
        public void AddActivityHistory(ActivityLog activityLog)
        {
            this.UIPropertyChanged("Activity History Customer");
        }
    }
}
