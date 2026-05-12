// <copyright file="User.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Abstract class of user which all other specific user is inheriting from. It will store the guest user's method and also the information all user stores.
    /// </summary>
    public abstract class User
    {
        /// <summary>
        /// Stores the user name of the user.
        /// </summary>
        protected string userName;

        /// <summary>
        /// Stores the user's password.
        /// </summary>
        protected string password;

        /// <summary>
        /// Stores the user's email.
        /// </summary>
        protected string email;

        /// <summary>
        /// Stores the user's date of birth.
        /// </summary>
        protected DateTime dateBirth;

        /// <summary>
        /// Stores the user's shipping address.
        /// </summary>
        protected string shippingAddress;

        /// <summary>
        /// Stores the user's payment method.
        /// </summary>
        protected string paymentMethod;

        /// <summary>
        /// Stores the user's type of user info.
        /// </summary>
        protected string type;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// Initialize the user with the name, password, email, date birth, address, payment, and type.
        /// </summary>
        /// <param name="newName"> The user's username.</param>
        /// <param name="newPassword"> The user's password.</param>
        /// <param name="newEmail"> The user's email.</param>
        /// <param name="newDate"> the user's date of birth.</param>
        /// <param name="newAddress"> The user's address.</param>
        /// <param name="newPayment"> the user's payment method.</param>
        /// <param name="newType"> the user's type.</param>
        protected User(string newName, string newPassword, string newEmail, DateTime newDate, string newAddress, string newPayment, string newType)
        {
            this.userName = newName;
            this.password = newPassword;
            this.email = newEmail;
            this.dateBirth = newDate;
            this.shippingAddress = newAddress;
            this.paymentMethod = newPayment;
            this.type = newType;
        }

        /// <summary>
        /// The event that will happened when the user's changes.
        /// </summary>
        public event PropertyChangedEventHandler? OnUserStateChanged;

        /// <summary>
        /// The event that will happen when the ui's property changes.
        /// </summary>
        public event PropertyChangedEventHandler? OnUIPropertyChanged;

        /// <summary>
        /// The event that will happen when the user's activity is updated.
        /// </summary>
        public event PropertyChangedEventHandler? OnUserActivityUpdated;

        /// <summary>
        /// Gets or sets and sets the user name of the user.
        /// </summary>
        public string UserName
        {
            get => this.userName;
            set
            {
                this.userName = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the user's password.
        /// </summary>
        public string Password
        {
            get => this.password;
            set
            {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the user's email.
        /// </summary>
        public string Email
        {
            get => this.email;
            set
            {
                this.email = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the user's date of birth.
        /// </summary>
        public DateTime DateBirth
        {
            get => this.dateBirth;
            set
            {
                this.dateBirth = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the user's shipping address.
        /// </summary>
        public string ShippingAddress
        {
            get => this.shippingAddress;
            set
            {
                this.shippingAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the user's payment method.
        /// </summary>
        public string PaymentMethod
        {
            get => this.paymentMethod;
            set
            {
                this.paymentMethod = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the user's type.
        /// </summary>
        public string Type
        {
            get => this.type;
            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// Notify that the ui property has been changed.
        /// </summary>
        /// <param name="state"> The state that has been changed.</param>
        public void UIPropertyChanged(string state)
        {
            this.OnUIPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(state));
        }

        /// <summary>
        /// Notify that the user's activity has been changed.
        /// </summary>
        /// <param name="activityLog"> The activity log that was been updated.</param>
        /// <param name="e"> The state of change.</param>
        public void UserActivityUpdated(ActivityLog activityLog, PropertyChangedEventArgs e)
        {
            this.OnUserActivityUpdated?.Invoke(activityLog, e);
        }

        /// <summary>
        /// Register the user and notify that the user has been registered.
        /// </summary>
        public void Register()
        {
            this.UserStateChanged("Register");
            string action = string.Empty + this.UserName + "; " + this.Email + "; " + this.DateBirth + "; " + this.ShippingAddress + "; " + this.PaymentMethod + "; " + this.Type + ";";
            ActivityLog activityLog = new ActivityLog(this, "Registered Account", action);
            this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Registered Account"));
        }

        /// <summary>
        /// Login the user and notify that the user has been logged in.
        /// </summary>
        public void Login()
        {
            this.UserStateChanged("Login");
            string action = string.Empty + this.UserName + "; " + this.Email + "; " + this.DateBirth + "; " + this.ShippingAddress + "; " + this.PaymentMethod + "; " + this.Type + ";";
            ActivityLog activityLog = new ActivityLog(this, "Login", action);
            this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Login"));
        }

        /// <summary>
        /// Notify the event that the user has been logged out.
        /// </summary>
        public void Logout()
        {
            this.UserStateChanged("Logout");
            string action = string.Empty + this.UserName + "; " + this.Email + "; " + this.DateBirth + "; " + this.ShippingAddress + "; " + this.PaymentMethod + "; " + this.Type + ";";
            ActivityLog activityLog = new ActivityLog(this, "Logout", action);
            this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Logout"));
        }

        /// <summary>
        /// Notify that the user's state has been changed.
        /// </summary>
        /// <param name="state"> The type of state that has been changed.</param>
        private void UserStateChanged(string state)
        {
            this.OnUserStateChanged?.Invoke(this, new PropertyChangedEventArgs(state));
        }
    }
}
