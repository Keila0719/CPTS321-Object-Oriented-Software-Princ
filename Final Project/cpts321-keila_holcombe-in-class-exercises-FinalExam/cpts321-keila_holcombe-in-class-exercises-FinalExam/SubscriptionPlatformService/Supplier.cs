// <copyright file="Supplier.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SubscriptionPlatformService
{
    /// <summary>
    /// One of the user type, supplier which contains information and method for supplier.
    /// </summary>
    public class Supplier : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// Initializes the supplier user with the input information.
        /// </summary>
        /// <param name="newName"> The new name of the supplier.</param>
        /// <param name="newPassword">The password for the supplier.</param>
        /// <param name="newEmail">The email address of the supplier.</param>
        /// <param name="newDate">The date of birth of the supplier.</param>
        /// <param name="newAddress">The address of the supplier.</param>
        /// <param name="newPayment">The payment method of the supplier.</param>
        /// <param name="newType"> The type of the supplier.</param>
        public Supplier(string newName, string newPassword, string newEmail, DateTime newDate, string newAddress, string newPayment, string newType)
            : base(newName, newPayment, newEmail, newDate, newAddress, newPayment, newType)
        {
        }

        /// <summary>
        /// Adding a new coffee with the input we have got.
        /// </summary>
        /// <param name="coffeeService"> The coffeeservice where we are storing each coffee.</param>
        /// <param name="coffee"> The new coffee that is being added.</param>
        /// <returns> True or false of if the coffee was added.</returns>
        public bool AddCoffee(CoffeeService coffeeService, Coffee coffee)
        {
            // Add a new coffee
            bool result = coffeeService.AddCoffee(coffee);

            // If result is true, notify the changes to the event
            if (result)
            {
                string description = string.Empty + coffee.Name + "; " + coffee.Origin + "; " + coffee.RoastType + "; " + coffee.FlavorNotes;
                ActivityLog activityLog = new ActivityLog(this, "Add Coffee", description);
                this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Coffee Added"));
                this.UIPropertyChanged("Coffee");
            }

            return result;
        }
    }
}
