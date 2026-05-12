// <copyright file="UserManager.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages all the users by storing the list of users and has method specific to the users.
    /// </summary>
    public class UserManager
    {
        /// <summary>
        /// Stores all the users in this application.
        /// </summary>
        protected List<User>? users;

        /// <summary>
        /// Stores the current user who is using this application.
        /// </summary>
        protected User? currentUser;

        /// <summary>
        /// The new object of the activityLogSercice.
        /// </summary>
        protected ActivityLogService activityLogService = new ActivityLogService();

        /// <summary>
        /// The new object of the CoffeeService.
        /// </summary>
        protected CoffeeService coffeeService = new CoffeeService();

        /// <summary>
        /// The new object of the priceRuleService.
        /// </summary>
        protected PriceRuleService priceRuleService = new PriceRuleService();

        /// <summary>
        /// The new object of SubscriptionService.
        /// </summary>
        protected SubscriptionService subscriptionService = new SubscriptionService();

        /// <summary>
        /// The new object of OrderService.
        /// </summary>
        protected OrderService orderService = new OrderService();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// Initializes the users list and the currentUser who is logged into this application.
        /// </summary>
        public UserManager()
        {
            this.users = new List<User>();
            this.currentUser = null;
            this.activityLogService.OnUIPropertyChanged += (sender, e) => this.OnUIPropertyChanged(sender, e);
        }

        /// <summary>
        /// The event that will notify the UI property has been changed.
        /// </summary>
        public event PropertyChangedEventHandler? UIPropertyChanged;

        /// <summary>
        /// The event that will notify that user's state changed.
        /// </summary>
        public event PropertyChangedEventHandler? UserStateChanged;

        /// <summary>
        /// Gets or Sets the currentUser which will hold the current logined user.
        /// </summary>
        public User? CurrentUser
        {
            get => this.currentUser;
            set
            {
                this.currentUser = value;

                if (value != null)
                {
                    // Subscribe the user to the events
                    value.OnUserStateChanged += this.OnUserStateChanged;
                    value.OnUIPropertyChanged += this.OnUIPropertyChanged;
                    value.OnUserActivityUpdated += this.OnUserActivityUpdated;
                }
            }
        }

        /// <summary>
        /// Sets the inputted user to the users list.
        /// </summary>
        /// <param name="user"> The user that is being set to list.</param>
        public void SetUsers(User? user)
        {
            if (user != null && this.users != null)
            {
                this.users.Add(user);
            }
        }

        /// <summary>
        /// Register a new user with the appropriate type and add it to users.
        /// </summary>
        /// <param name="username"> The username input that user typed.</param>
        /// <param name="password"> The password input that user typed.</param>
        /// <param name="email"> The email input that user typed.</param>
        /// <param name="dateBirth"> The dateBirth input that user typed.</param>
        /// <param name="shippingAddress"> The shippingAddress input that user typed.</param>
        /// <param name="paymentMethod"> The paymentMethod input that user typed.</param>
        /// <param name="type"> The type of account the user decided to create an account for.</param>
        /// <returns> Returns if the user was able to register their account or not.</returns>
        public bool Register(string? username, string? password, string? email, DateTime dateBirth, string? shippingAddress, string? paymentMethod, string? type)
        {
            // Check if any input is null or empty, if it is, return false
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(shippingAddress) || string.IsNullOrEmpty(paymentMethod) || string.IsNullOrEmpty(type))
            {
                return false;
            }

            // Check for duplicated username
            if (this.IsDuplicate(username))
            {
                return false;
            }

            // Create a new user account
            UserFactory userFactory = new UserFactory();

            if (type == null)
            {
                return false;
            }

            User? user = userFactory.CreateUser(type, username, password, email, dateBirth, shippingAddress, paymentMethod);

            // Add this user to the user lists
            this.SetUsers(user);

            // Set the user as the current account
            this.CurrentUser = user;

            user?.Register();
            return true;
        }

        /// <summary>
        /// Login the user by checking their username and password.
        /// </summary>
        /// <param name="username"> The username input that user typed.</param>
        /// <param name="password"> The password input that user typed.</param>
        /// <returns> Returns if the user was able to login to the account or not.</returns>
        public bool Login(string? username, string? password)
        {
            // Check if username is null or empty
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            // Check if password is null or empty
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // TODO: be able to change the login by using the third-party
            User? user = this.GetUser(username);

            // Check if there such user with that username
            if (user == null)
            {
                // There was no such user with that username
                return false;
            }

            // Check if the password matches to that user account
            if (this.IsPasswordCorrect(user, password))
            {
                // Make that user to be the currentUser
                this.currentUser = user;
                user.Login();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Allows the user to logout from their account.
        /// </summary>
        public void Logout()
        {
            this.currentUser?.Logout();
            this.currentUser = null;
        }

        /// <summary>
        /// Gets the user from the users list with the appropriate username.
        /// </summary>
        /// <param name="userName"> username that it's getting from the users list.</param>
        /// <returns> Returns the user that is associated with userName.</returns>
        public User? GetUser(string userName)
        {
            if (this.users == null)
            {
                return null;
            }

            // For each user in the users list, check if there exist an account with such user name
            foreach (User user in this.users)
            {
                // If the user name matches, return the user
                if (user.UserName == userName)
                {
                    return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Check if the password matches the user's password.
        /// </summary>
        /// <param name="user"> The current User.</param>
        /// <param name="password"> The password that the user inputted for user.</param>
        /// <returns> If the password is correct or not.</returns>
        public bool IsPasswordCorrect(User user, string password)
        {
            // Check if the current user and password match
            if (user.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if there are already that username user exist or not.
        /// </summary>
        /// <param name="username"> The username that it's checking for.</param>
        /// <returns> If there is a duplicated username or nor.</returns>
        public bool IsDuplicate(string username)
        {
            if (this.users == null)
            {
                return false;
            }

            foreach (User user in this.users)
            {
                if (user.UserName == username)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get the list of all the activities that the user has done in this application.
        /// </summary>
        /// <returns> A list of all the activities that the user has done.</returns>
        public List<ActivityLog>? GetActivities()
        {
            // If the current user is a systme administrator, return the activities
            if (this.currentUser is SystemAdministrator systemAdministrator)
            {
                return this.activityLogService.Activities;
            }

            return null;
        }

        /// <summary>
        /// Add the coffee by calling the supplier Add coffee method.
        /// </summary>
        /// <param name="coffee"> The coffee that is being added.</param>
        /// <returns> True or false of if the coffee was added.</returns>
        public bool AddCoffee(Coffee? coffee)
        {
            // Check if the current coffee is null
            if (coffee == null)
            {
                return false;
            }

            // If the current user is a suppleir, add the coffee
            if (this.currentUser is Supplier supplier)
            {
                return supplier.AddCoffee(this.coffeeService, coffee);
            }

            return false;
        }

        /// <summary>
        /// Add the new subscription to the subscriptionService only if the current user is a customer.
        /// </summary>
        /// <param name="subscription"> The subscription that is being added. </param>
        /// <returns> True or false of if the subscription was added or not.</returns>
        public bool AddSubscription(Subscription? subscription)
        {
            // Check if subscription is null
            if (subscription == null)
            {
                return false;
            }

            // Check if the current user is a customer
            if (this.currentUser is Customer customer)
            {
                return customer.AddSubscription(subscription, this.subscriptionService);
            }

            return false;
        }

        /// <summary>
        /// Add a new order based on the subscription that was selected.
        /// </summary>
        /// <param name="subscription"> The subscription that was used.</param>
        /// <returns> True or false of if the order was added or not.</returns>
        public bool AddOrder(Subscription? subscription)
        {
            // Check if the subscription is null
            if (subscription == null)
            {
                return false;
            }

            // If the current user is a customer, calculate the discounted price and add the order
            if (this.currentUser is Customer customer)
            {
                double? price = this.CalculatePrice(subscription);
                return customer.AddOrder(subscription, price);
            }

            return false;
        }

        /// <summary>
        /// Calculate the price using the priceRuleSercice CalculatePrice method.
        /// </summary>
        /// <param name="subscription"> The subscription that is being checked for discount.</param>
        /// <returns>The discounted price.</returns>
        public double? CalculatePrice(Subscription? subscription)
        {
            return this.priceRuleService?.CalculatePrice(subscription);
        }

        /// <summary>
        /// Gets the coffee designated with the coffeeName using the coffeeSercice getCoffee mehtod.
        /// </summary>
        /// <param name="coffeeName"> The name of the coffee that is being searched.</param>
        /// <returns> The coffee that has the name coffeeName.</returns>
        public Coffee? GetCoffee(string coffeeName)
        {
            if (string.IsNullOrEmpty(coffeeName))
            {
                return null;
            }

            return this.coffeeService.GetCoffee(coffeeName);
        }

        /// <summary>
        /// Gets the coffee list from the coffeeService.
        /// </summary>
        /// <returns> The list of coffees.</returns>
        public List<Coffee> GetCoffeeList()
        {
            return this.coffeeService.Coffees;
        }

        /// <summary>
        /// Create a priceRuleDiscount if the current user is a subscriptionManager using the method in that user.
        /// </summary>
        /// <param name="apply"> The information about what it applys to.</param>
        /// <param name="target"> The target value for this discount.</param>
        /// <param name="discount"> The discount price.</param>
        /// <param name="duration"> How long this discount will be for.</param>
        /// <returns> True or false of if the rule was successfully created.</returns>
        public bool CreatePriceRuleDiscount(string apply, string target, double discount, int duration)
        {
            // Check if the currentUser is a subscriptionManager, if it is allow to create priceRuleDisocunt
            if (this.currentUser is SubscriptionManager subscriptionManager)
            {
                return subscriptionManager.CreatePriceRuleDiscount(this.priceRuleService, apply, target, discount, duration);
            }

            return false;
        }

        /// <summary>
        /// Rate the order with the rate and the feedback by using the method in customer.
        /// </summary>
        /// <param name="order"> The order that is being rate.</param>
        /// <param name="rate"> The rating value of the range 1-5.</param>
        /// <param name="feedback"> The fji0eedback of the rating.</param>
        /// <returns> True of false of if the order was rated.</returns>
        public bool RateOrder(Order? order, int? rate, string? feedback)
        {
            // IF the current user is a customer, rate the order
            if (this.currentUser is Customer customer)
            {
                return customer.RateOrder(this.orderService, order, rate, feedback);
            }

            return false;
        }

        /// <summary>
        /// Generate a recommendation to the customer.
        /// </summary>
        /// <returns> List of coffee recommendation.</returns>
        public List<Coffee>? GenerateRecommendation()
        {
            // Check if the current User is customer and is not null
            if (this.currentUser is Customer customer && this.currentUser != null)
            {
                RecommendationService recommendationService = new RecommendationService();
                customer.GenerateRecommendation();
                return recommendationService.GenerateRecommendation(customer, this.GetCoffeeList());
            }

            return null;
        }

        /// <summary>
        /// Notify the UI when the user state changes between login and logout.
        /// </summary>
        /// <param name="sender"> The current user.</param>
        /// <param name="e"> The current state of the user.</param>
        private void OnUserStateChanged(object? sender, PropertyChangedEventArgs e)
        {
            User? user = sender as User;

            // Check if the user has login or registere their account, if yes notify
            if (e.PropertyName == "Login" || e.PropertyName == "Register")
            {
                this.UserStateChanged?.Invoke(user, new PropertyChangedEventArgs(user?.Type));
            }

            // Or decided to logout, if yes notify
            else if (e.PropertyName == "Logout")
            {
                this.UserStateChanged?.Invoke(user, new PropertyChangedEventArgs("Guest"));
            }
        }

        /// <summary>
        /// Notify the UI when the user updates the information.
        /// </summary>
        /// <param name="sender"> The current user.</param>
        /// <param name="e"> The property that was updated.</param>
        private void OnUIPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // When the UI property has been changed, forward the notification
            this.UIPropertyChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Notify that the user's activity has been updated.
        /// </summary>
        /// <param name="sender"> The activity that has been created.</param>
        /// <param name="e"> The type of change that happened.</param>
        private void OnUserActivityUpdated(object? sender, PropertyChangedEventArgs e)
        {
            ActivityLog? activity = sender as ActivityLog;

            // Check if activity is null
            if (activity == null)
            {
                return;
            }

            // If the current user is a customer, add it to their activity history
            if (this.currentUser is Customer customer)
            {
                customer.AddActivityHistory(activity);
            }

            // Also add it to the global activity history as well
            this.activityLogService.AddActivities(activity);
        }
    }
}
