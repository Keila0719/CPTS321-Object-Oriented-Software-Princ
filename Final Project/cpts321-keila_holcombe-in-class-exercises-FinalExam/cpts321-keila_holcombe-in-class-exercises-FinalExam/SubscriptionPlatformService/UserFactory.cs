// <copyright file="UserFactory.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Creates the different types of user.
    /// </summary>
    internal class UserFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFactory"/> class.
        /// Initializes the user factory class.
        /// </summary>
        public UserFactory()
        {
        }

        /// <summary>
        /// Create a new user using the information that was inputted. It will use the userType to figure out which type of user it will be created.
        /// </summary>
        /// <param name="userType">The type of user to create.</param>
        /// <param name="newName">The name of the new user.</param>
        /// <param name="newPassword">The password of the new user.</param>
        /// <param name="newEmail">The email of the new user.</param>
        /// <param name="newDate">The date of birth of the new user.</param>
        /// <param name="newAddress">The address of the new user.</param>
        /// <param name="newPayment">The payment method of the new user.</param>
        /// <returns> The new user that was created.</returns>
        public User? CreateUser(string userType, string newName, string newPassword, string newEmail, DateTime newDate, string newAddress, string newPayment)
        {
            if (userType == "Customer")
            {
                return new Customer(newName, newPassword, newEmail, newDate, newAddress, newPayment, userType);
            }
            else if (userType == "Supplier")
            {
                return new Supplier(newName, newPassword, newEmail, newDate, newAddress, newPayment, userType);
            }
            else if (userType == "Subscription Manager")
            {
                return new SubscriptionManager(newName, newPassword, newEmail, newDate, newAddress, newPayment, userType);
            }
            else if (userType == "System Administrator")
            {
                return new SystemAdministrator(newName, newPassword, newEmail, newDate, newAddress, newPayment, userType);
            }
            else
            {
                return null;
            }
        }
    }
}
