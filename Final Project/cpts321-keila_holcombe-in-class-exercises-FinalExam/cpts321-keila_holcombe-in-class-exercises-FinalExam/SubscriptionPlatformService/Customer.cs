// <copyright file="Customer.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores information about user type customer and their specific method they can do.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// Initializes the customer object with name, password, email, date, address, payment, and type.
    /// </remarks>
    /// <param name="newName"> The name of this user.</param>
    /// <param name="newPassword"> The password of this user.</param>
    /// <param name="newEmail"> The email of this user.</param>
    /// <param name="newDate"> The date of this user.</param>
    /// <param name="newAddress"> The address of this user.</param>
    /// <param name="newPayment"> The payment of this user.</param>
    /// <param name="newType"> the type of this user.</param>
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
    public class Customer(string newName, string newPassword, string newEmail, DateTime newDate, string newAddress, string newPayment, string newType) : User(newName, newPassword, newEmail, newDate, newAddress, newPayment, newType)
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
    {
        /// <summary>
        /// Stores the current tasteProfile of the customer.
        /// </summary>
        protected TasteProfile? tasteProfile;

        /// <summary>
        /// Stores all the subscription the user is subscribed to.
        /// </summary>
        protected Subscription? subscription;

        /// <summary>
        /// Stores all the activity that this customer did.
        /// </summary>
        protected List<ActivityLog> activityLogs = new List<ActivityLog>();

        /// <summary>
        /// Stores the order that this customer has.
        /// </summary>
        protected Order? order;

        /// <summary>
        /// Stores if the user currently has an order or not.
        /// </summary>
        protected bool orderCame;

        /// <summary>
        /// Stores all the ratings this user made.
        /// </summary>
        protected List<Rating>? ratings;

        /// <summary>
        /// Gets or sets and sets the current user's tasteprofile.
        /// </summary>
        public TasteProfile? TasteProfile
        {
            get => this.tasteProfile;
            set
            {
                this.tasteProfile = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets and sets if the user's order has came or not.
        /// </summary>
        public bool OrderCame
        {
            get => this.orderCame;

            set
            {
                this.orderCame = value;
            }
        }

        /// <summary>
        /// Gets the List of orders from the customer.
        /// </summary>
        public Order? Order
        {
            get => this.order;
        }

        /// <summary>
        /// Gets the subscription.
        /// </summary>
        public Subscription? Subscription
        {
            get => this.subscription;
        }

        /// <summary>
        /// Gets the list of ratings.
        /// </summary>
        public List<Rating>? Ratings
        {
            get => this.ratings;
        }

        /// <summary>
        /// Customize the taste profile of the customer. It can create a new one and also after creating the first one, it will able to update the taste profile.
        /// </summary>
        /// <param name="flavor"> The flavor input of the user.</param>
        /// <param name="roast"> The roast input of the user.</param>
        /// <param name="strength"> The strength input of the user.</param>
        /// <returns> Check if it was able to customize the taste profile.</returns>
        public bool CustomizeTasteProfile(string? flavor, string? roast, string? strength)
        {
            // Check if the input is invalid
            if (string.IsNullOrEmpty(flavor) || string.IsNullOrEmpty(roast) || string.IsNullOrEmpty(strength))
            {
                return false;
            }

            // If not update the TasteProfile with the new one
            this.tasteProfile = new TasteProfile(flavor, roast, strength);
            string description = string.Empty + flavor + "; " + roast + "; " + strength + ";";
            ActivityLog activityLog = new ActivityLog(this, "Taste Profile Update", description);
            this.UIPropertyChanged("Taste Profile");
            this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Taste Profile Updated"));
            return true;
        }

        /// <summary>
        /// Rate the order with the rate value and the feedback.
        /// </summary>
        /// <param name="orderService"> The reference to the object orderService.</param>
        /// <param name="order"> The order that is being rated.</param>
        /// <param name="rate"> The rate of 1-5.</param>
        /// <param name="feedback"> The feedback of the order.</param>
        /// <returns>True or false of if the rate was successfully ordered.</returns>
        public bool RateOrder(OrderService? orderService, Order? order, int? rate, string? feedback)
        {
            // If any information is null or empty, return false
            if (orderService == null || order == null || rate == null || string.IsNullOrEmpty(feedback))
            {
                return false;
            }

            // Rate the order
            bool result = orderService.RateOrder(order, rate, feedback);

            // If the result is true, notify the changes
            if (result)
            {
                string description = string.Empty + rate + "; " + feedback;
                ActivityLog activityLog = new ActivityLog(this, "Rate Order", description);
                this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Rate Order"));
                this.UIPropertyChanged("Rate");
                this.ratings?.Add(new Rating(rate, feedback));
            }

            return result;
        }

        /// <summary>
        /// Returns all the activitylogs in this user.
        /// </summary>
        /// <returns> The list of activity logs.</returns>
        public List<ActivityLog> ViewActivityHistory()
        {
            // Return the activity logs
            return this.activityLogs;
        }

        /// <summary>
        /// Add an activity history log and notify the event that the activity has been added.
        /// </summary>
        /// <param name="activityLog"> The activity log that is added to the list.</param>
        public void AddActivityHistory(ActivityLog activityLog)
        {
            // Add the activity log to the list
            this.activityLogs.Add(activityLog);

            // Notify the event that the activity has been added
            this.UIPropertyChanged("Activity History Customer");
        }

        /// <summary>
        /// Notifies that the recommendation has been created.
        /// </summary>
        public void GenerateRecommendation()
        {
            this.UIPropertyChanged("Generated Recommendation");
        }

        /// <summary>
        /// Add a new subscription and notify the UI that the subscription has been added or modified.
        /// </summary>
        /// <param name="newSubscription"> The subscription that is being added.</param>
        /// <param name="subscriptionService"> The subscriptionService that the new subscription is being added to.</param>
        /// <returns> True or false of if the subscription was added.</returns>
        public bool AddSubscription(Subscription? newSubscription, SubscriptionService? subscriptionService)
        {
            // Check if input is null
            if (newSubscription == null || subscriptionService == null)
            {
                return false;
            }

            // Add the subscription
            bool result = subscriptionService.CheckValidSubscription(newSubscription);

            // Notify the event that the subscription was added only if the result is true
            if (result)
            {
                this.subscription = newSubscription;
                string description = string.Empty + this.subscription.Strategy + "; " + this.subscription?.BagSize?.BagSize + "oz; $" + this.subscription?.BagSize?.Price + " ;" + this.subscription?.Coffee?.Name + "; " + this.subscription?.Frequency + "; " + this.subscription?.StartDate.ToString();
                ActivityLog activityLog = new ActivityLog(this, "Subscription Updated", description);
                this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Subscription Updated"));
                this.UIPropertyChanged("Subscription");
            }

            return result;
        }

        /// <summary>
        /// Creates a new order and add the order to this customer.
        /// </summary>
        /// <param name="subscription"> The subscription that is going to be added.</param>
        /// <param name="price"> The price after the discount.</param>
        /// <returns> True or false of if the order was added.</returns>
        public bool AddOrder(Subscription? subscription, double? price)
        {
            // Check if the current subscription is a null, if it is, return false
            if (subscription == null)
            {
                return false;
            }

            // Check if the price is null, if it is, return false
            if (price == null)
            {
                return false;
            }

            // If it's good, create a new order
            Order newOrder = new Order(subscription, price);
            this.order = newOrder;

            // Notify that the order has been added and return true
            string description = string.Empty + subscription?.Strategy + "; " + subscription?.BagSize?.BagSize + "oz; $" + subscription?.BagSize?.Price + " ;" + subscription?.Coffee?.Name + "; " + subscription?.Frequency + "; " + subscription?.StartDate.ToString();
            ActivityLog activityLog = new ActivityLog(this, "Order Added", description);
            this.UserActivityUpdated(activityLog, new PropertyChangedEventArgs("Order Addedd"));
            this.UIPropertyChanged("Order");

            return true;
        }
    }
}