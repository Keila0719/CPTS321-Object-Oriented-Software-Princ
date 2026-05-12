// <copyright file="TestSubscriptionPlatformService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using SubscriptionPlatformService;

namespace TestSubscriptionPlatformService
{
    /// <summary>
    /// Tests the methos inside the subscriptionPlatformSercive.
    /// </summary>
    public class TestSubscriptionPlatformService
    {
        /// <summary>
        /// Testing a normal case for register method to check if the new user was able to regester.
        /// </summary>
        [Test]
        public void TestRegister()
        {
            // Register the user
            UserManager userManager = new UserManager();
            string username = "testUser";
            string password = "testPassword";
            string email = "testEmail";
            DateTime dateBirth = new DateTime(1, 1, 1);
            string shippingAddress = "testAddress";
            string paymentMethod = "testPayment";
            string type = "Customer";
            bool result = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Check if the user was registered successfully
            Assert.That(userManager?.GetUser(username)?.UserName, Is.EqualTo(username));
        }

        /// <summary>
        /// Testing a boundary case for register method when trying to register already existing username.
        /// </summary>
        [Test]
        public void TestRegisterDuplicate()
        {
            // Register the user
            UserManager userManager = new UserManager();
            string username = "testUser";
            string password = "testPassword";
            string email = "testEmail";
            DateTime dateBirth = new DateTime(1, 1, 1);
            string shippingAddress = "testAddress";
            string paymentMethod = "testPayment";
            string type = "Customer";
            bool result1 = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Try to register with the same username
            bool result2 = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Check if it denied to register with the duplicate username
            Assert.That(result2, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing a edge case for when trying to add with a null string information.
        /// </summary>
        [Test]
        public void TestRegisterNull()
        {
            // Register the user with null username
            UserManager userManager = new UserManager();
            string? username = null;
            string password = "testPassword";
            string email = "testEmail";
            DateTime dateBirth = new DateTime(1, 1, 1);
            string shippingAddress = "testAddress";
            string paymentMethod = "testPayment";
            string type = "Customer";
            bool result = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Check if it denied to register with null username
            Assert.That(result, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing a normal case for login method to check if the user was able to login.
        /// </summary>
        [Test]
        public void TestLogin()
        {
            // Register the user
            UserManager userManager = new UserManager();
            string username = "testUser";
            string password = "testPassword";
            string email = "testEmail";
            DateTime dateBirth = new DateTime(1, 1, 1);
            string shippingAddress = "testAddress";
            string paymentMethod = "testPayment";
            string type = "Customer";
            bool result = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Try to login with the correct username and password
            bool result2 = userManager.Login(username, password);

            // Check if the user was logged in successfully
            Assert.That(userManager?.CurrentUser?.UserName, Is.EqualTo(username));
        }

        /// <summary>
        /// Testing a boundary case for login with wrong password.
        /// </summary>
        [Test]
        public void TestLoginWrong()
        {
            // Register the user
            UserManager userManager = new UserManager();
            string username = "testUser";
            string password = "testPassword";
            string email = "testEmail";
            DateTime dateBirth = new DateTime(1, 1, 1);
            string shippingAddress = "testAddress";
            string paymentMethod = "testPayment";
            string type = "Customer";
            bool result1 = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Try to login with the wrong password
            bool result2 = userManager.Login(username, "wrongPassword");

            // Check if it denied to login with the wrong password
            Assert.That(result2, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing a edge case for when trying to login using null string.
        /// </summary>
        [Test]
        public void TestLoginNull()
        {
            // Register the user
            UserManager userManager = new UserManager();
            string username = "testUser";
            string password = "testPassword";
            string email = "testEmail";
            DateTime dateBirth = new DateTime(1, 1, 1);
            string shippingAddress = "testAddress";
            string paymentMethod = "testPayment";
            string type = "Customer";
            bool result = userManager.Register(username, password, email, dateBirth, shippingAddress, paymentMethod, type);

            // Try to login with null username
            bool result2 = userManager.Login(null, password);

            // Check if the login was denied with null username
            Assert.That(result2, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing a normal case for trying to add a coffee.
        /// </summary>
        [Test]
        public void TestAddCoffee()
        {
            // Create a coffee and add it to the coffee service
            CoffeeService coffeeService = new CoffeeService();
            string name = "testCoffee";
            string origin = "testOrigin";
            string roast = "testRoast";
            string flavor = "testFlavor";
            List<BagSizes> bagsize = new List<BagSizes>();
            bagsize.Add(new BagSizes(2, 2));
            bool result = coffeeService.AddCoffee(new Coffee(name, origin, roast, flavor, bagsize));

            // Try getting the coffee that was just added
            Coffee? coffee = coffeeService?.GetCoffee(name);

            // Check if the coffee was added correctly
            Assert.That(coffee?.Name, Is.EqualTo(name));
        }

        /// <summary>
        /// Testing a boundry case for trying to add an empty name coffee.
        /// </summary>
        [Test]
        public void TestAddCoffeeMissingInfo()
        {
            // Create a coffee with empty name
            CoffeeService coffeeService = new CoffeeService();
            string name = string.Empty;
            string origin = "testOrigin";
            string roast = "testRoast";
            string flavor = "testFlavor";
            List<BagSizes> bagsize = new List<BagSizes>();
            bagsize.Add(new BagSizes(2, 2));
            bool result = coffeeService.AddCoffee(new Coffee(name, origin, roast, flavor, bagsize));

            // Check if it denied to add a coffee with empty name
            Assert.That(result, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing an edge case for trying to add duplicated name coffee.
        /// </summary>
        [Test]
        public void TestAddCoffeeDuplicate()
        {
            // Create a coffee and add it
            CoffeeService coffeeService = new CoffeeService();
            string name = "testCoffee";
            string origin = "testOrigin";
            string roast = "testRoast";
            string flavor = "testFlavor";
            List<BagSizes> bagsize = new List<BagSizes>();
            bagsize.Add(new BagSizes(2, 2));
            bool result = coffeeService.AddCoffee(new Coffee(name, origin, roast, flavor, bagsize));

            // Try to add the same coffee again
            bool result2 = coffeeService.AddCoffee(new Coffee(name, origin, roast, flavor, bagsize));

            // Check if it denied to add a coffee with duplicated name
            Assert.That(result2, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing a normal case of getting coffee.
        /// </summary>
        [Test]
        public void TestGetCoffee()
        {
            // Create a coffee and add it
            CoffeeService coffeeService = new CoffeeService();
            string name = "testCoffee";
            string origin = "testOrigin";
            string roast = "testRoast";
            string flavor = "testFlavor";
            List<BagSizes> bagsize = new List<BagSizes>();
            bagsize.Add(new BagSizes(2, 2));
            bool result = coffeeService.AddCoffee(new Coffee(name, origin, roast, flavor, bagsize));

            // Try getting the coffee that was just added
            Coffee? coffee = coffeeService?.GetCoffee(name);

            // Check if the coffee was successfully gotten
            Assert.That(coffee?.Name, Is.EqualTo(name));
        }

        /// <summary>
        /// Testing a boundry case for trying to add an empty name coffee.
        /// </summary>
        [Test]
        public void TestGetCoffeeNotExist()
        {
            // Try getting a coffee that does not exist
            CoffeeService coffeeService = new CoffeeService();
            Coffee? coffee = coffeeService?.GetCoffee("testCoffee");

            // Check if it returned null
            Assert.That(coffee, Is.EqualTo(null));
        }

        /// <summary>
        /// Testing an edge case for trying to get coffee with null name.
        /// </summary>
        [Test]
        public void TestGetCoffeeNull()
        {
            // Try getting a coffee with null name
            CoffeeService coffeeService = new CoffeeService();
            Coffee? coffee = coffeeService?.GetCoffee(null);

            // Check if it returned null
            Assert.That(coffee, Is.EqualTo(null));
        }

        /// <summary>
        /// Testing for normal case to see if the customer is able to customize their taste profile.
        /// </summary>
        [Test]
        public void TestCustomizeTasteProfile()
        {
            // Create a customer user
            Customer customer = new Customer("testName", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");

            // Create a taste profile
            bool result = customer.CustomizeTasteProfile("testFlavor", "testRoast", "testStrength");

            // Check if the taste profile was created successfully
            Assert.That(result, Is.EqualTo(true));
        }

        /// <summary>
        /// Testing for boundary case to see if it is able to override the taste profile when it is already set.
        /// </summary>
        [Test]
        public void TestCustomizeTasteProfileOverride()
        {
            // Create a customer user
            Customer customer = new Customer("testName", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");

            // Create a taste profile
            bool result = customer.CustomizeTasteProfile("testFlavor", "testRoast", "testStrength");

            // Try to override the taste profile with new information
            bool result2 = customer.CustomizeTasteProfile("newTestFlavor", "newTestRoast", "newTestStrength");

            // Check if the taste profile was overridden successfully
            Assert.That(customer?.TasteProfile?.Flavor, Is.EqualTo("newTestFlavor"));
        }

        /// <summary>
        /// Testing for edge case to see if it can handle null input.
        /// </summary>
        [Test]
        public void TestCustomizeTasteProfileNull()
        {
            // Create a customer user
            Customer customer = new Customer("testName", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");

            // Create a taste profile with null input
            bool result = customer.CustomizeTasteProfile(null, null, "testStrength");

            // Check if it denied to create a taste profile
            Assert.That(result, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing for normal case for Activity History to see if the customer user is able to view their activity history.
        /// </summary>
        [Test]
        public void TestActivityHistoryCustomer()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            User? user = userManager?.CurrentUser;
            Customer? customer = user as Customer;

            if (customer != null)
            {
                // Get the activity history of that customer
                List<ActivityLog> activityLogs = customer.ViewActivityHistory();

                // Check if the activity history was successfully added
                Assert.That(activityLogs[0].Action, Is.EqualTo("Registered Account"));
            }
        }

        /// <summary>
        /// Testing for boundary case for ActivityHistory to see if it can handle multiple activity logs.
        /// </summary>
        [Test]
        public void TestActivityHistoryCustomerMultiple()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            User? user = userManager?.CurrentUser;
            Customer? customer = user as Customer;

            // Create additional log
            customer?.CustomizeTasteProfile("testFlavor", "testRoast", "testStrength");

            // Get the activity history
            List<ActivityLog>? activityLogs = customer?.ViewActivityHistory();

            if (activityLogs != null)
            {
                // Check if the activity history was successfully added with multiple logs
                Assert.That(activityLogs[1].Action, Is.EqualTo("Taste Profile Update"));
            }
        }

        /// <summary>
        /// Testing for edge case for ActivityHistory to see if it can handle multiple activity logs with null inputs.
        /// </summary>
        [Test]
        public void TestActivityHistoryCustomerFailed()
        {
            // Create a customer user and make a log
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            User? user = userManager?.CurrentUser;
            Customer? customer = user as Customer;
            customer?.CustomizeTasteProfile("testFlavor", "testRoast", "testStrength");

            // Try to create a log with null input
            customer?.CustomizeTasteProfile(null, "testRoast", "testStrength");

            // Get the activity history
            List<ActivityLog>? activityLogs = customer?.ViewActivityHistory();

            // Check if that log was not added to the activity history
            Assert.That(activityLogs?.Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Testing for normal case for Activity History to see if the SystemAdministrator user is able to view their activity history.
        /// </summary>
        [Test]
        public void TestActivityHistorySystemAdministrator()
        {
            // Create a system administrator user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "System Administrator");
            User? user = userManager?.CurrentUser;
            SystemAdministrator? systemAdministrator = user as SystemAdministrator;

            // Get the activity history of that system administrator
            List<ActivityLog>? activityLogs = userManager?.GetActivities();

            // Check if the activity history was successfully added
            Assert.That(activityLogs?[0].Action, Is.EqualTo("Registered Account"));
        }

        /// <summary>
        /// Testing for boundary case for ActivityHistory for SystemAdministrator for when multiple user logs are there.
        /// </summary>
        [Test]
        public void TestActivityHistorySystemAdministratorMultiple()
        {
            UserManager userManager = new UserManager();

            // Create a user to create logs
            userManager.Register("testUser2", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            User? user2 = userManager?.CurrentUser;
            Customer? customer = user2 as Customer;

            // Create additional log
            customer?.CustomizeTasteProfile("testFlavor", "testRoast", "testStrength");

            // Create a system administrator user
            userManager?.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "System Administrator");
            User? user = userManager?.CurrentUser;
            SystemAdministrator? systemAdministrator = user as SystemAdministrator;

            // Get the activity history
            List<ActivityLog>? activityLogs = userManager?.GetActivities();

            // Check if the activity history was successfully added with multiple logs and users
            Assert.That(activityLogs?[1].Action, Is.EqualTo("Taste Profile Update"));
        }

        /// <summary>
        /// Testing for edge case for ActivityHistory for SystemAdministrator for when multiple user logs are there with null inputs.
        /// </summary>
        [Test]
        public void TestActivityHistorySystemAdministratorFailed()
        {
            UserManager userManager = new UserManager();

            // Create a user
            userManager.Register("testUser2", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            User? user2 = userManager.CurrentUser;
            Customer? customer = user2 as Customer;

            // Try to create a log with null input
            customer?.CustomizeTasteProfile(null, "testRoast", "testStrength");

            // Create a system administrator user
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "System Administrator");
            User? user = userManager.CurrentUser;
            SystemAdministrator? systemAdministrator = user as SystemAdministrator;

            // Get the activity history
            List<ActivityLog>? activityLogs = userManager.GetActivities();

            // Check if that log was not added to the activity history
            Assert.That(activityLogs?.Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Testing for normal case for logging out.
        /// </summary>
        [Test]
        public void TestLogout()
        {
            // Create a user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "System Administrator");
            User? user = userManager.CurrentUser;

            // Try to logout
            userManager.Logout();

            // Check if the user was able to logged out successfully
            Assert.That(userManager.CurrentUser, Is.Null);
        }

        /// <summary>
        /// Testinf a normal case of PriceRule Discount to see if the discount is calculated correctly.
        /// </summary>
        [Test]
        public void TestPriceRuleDiscount()
        {
            // Create a subscription manager user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Subscription Manager");
            User? user = userManager.CurrentUser;

            // Create a price discout rule
            BagSizeDiscount priceRule = new BagSizeDiscount("12", 2.00, 10);

            // Apply the discount on the subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(12, 5) });
            double? price = priceRule?.CalculateDiscount(new Subscription("testSubscription", coffee, new BagSizes(12, 5), "weekly", new DateTime(1, 1, 1)), 5.00);

            // Check if the discount was applied correctly
            Assert.That(price, Is.EqualTo(3.00));
        }

        /// <summary>
        /// Testing a boundry case of PriceRuleDiscount to see if it can modify the discount price when there is already a price rule with the same bag size.
        /// </summary>
        [Test]
        public void TestPriceRuleDiscountDuplicate()
        {
            // Create a subscription manager user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Subscription Manager");
            User? user = userManager.CurrentUser;
            SubscriptionManager? subscriptionManager = user as SubscriptionManager;

            // Create a price rule with the same bag size
            BagSizeDiscount priceRule = new BagSizeDiscount("12", 2.00, 10);
            BagSizeDiscount priceRuleDuplicate = new BagSizeDiscount("12", 3.00, 10);
            PriceRuleService priceRuleService = new PriceRuleService();
            priceRuleService.AddPriceRuleDiscount(priceRule);
            priceRuleService.AddPriceRuleDiscount(priceRuleDuplicate);

            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(12, 5) });
            double? price = priceRuleService?.CalculatePrice(new Subscription("testSubscription", coffee, new BagSizes(12, 5), "weekly", new DateTime(1, 1, 1)));

            // Check if the modified price rule is applied
            Assert.That(price, Is.EqualTo(2.00));
        }

        /// <summary>
        /// Testing a edge case for PriceRuleDiscount to see if it can handle negative price discount.
        /// </summary>
        [Test]
        public void TestPriceRuleDiscountNegative()
        {
            // Create a subscription manager user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Subscription Manager");
            User? user = userManager.CurrentUser;
            SubscriptionManager? subscriptionManager = user as SubscriptionManager;

            // Create a price rule with the same bag size
            BagSizeDiscount priceRule = new BagSizeDiscount("12", -2.00, 10);
            PriceRuleService priceRuleService = new PriceRuleService();
            priceRuleService.AddPriceRuleDiscount(priceRule);

            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(12, 5) });
            double? price = priceRuleService?.CalculatePrice(new Subscription("testSubscription", coffee, new BagSizes(12, 5), "weekly", new DateTime(1, 1, 1)));

            // Check if the modified price rule is applied
            Assert.That(price, Is.EqualTo(5.00));
        }

        /// <summary>
        /// Testing a normal case for adding subscription to see if it was successfully added.
        /// </summary>
        [Test]
        public void TestAddSubscription()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;
            SubscriptionService subscriptionService = new SubscriptionService();

            // Create a subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(2, 2) });
            if (customer != null)
            {
                bool result = customer.AddSubscription(new Subscription("testSubscription", coffee, new BagSizes(2, 2), "weekly", new DateTime(1, 1, 1)), subscriptionService);

                // Check if that subscription was added successfully
                Assert.That(result, Is.EqualTo(true));
            }
        }

        /// <summary>
        /// Test a boundary case for checking if it can modify the subscription.
        /// </summary>
        [Test]
        public void TestAddSubscriptionDuplicate()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;
            SubscriptionService subscriptionService = new SubscriptionService();

            // Create a subscription
            BagSizes bagSize = new BagSizes(2, 2);
            List<BagSizes> bagSizesList = new List<BagSizes>() { bagSize };
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", bagSizesList);

            if (customer != null)
            {
                bool result = customer.AddSubscription(new Subscription("testSubscription", coffee, bagSize, "weekly", new DateTime(1, 1, 1)), subscriptionService);

                // Try to create the same subscription again
                bool result2 = customer.AddSubscription(new Subscription("testSubscription", coffee, bagSize, "bi-weekly", new DateTime(1, 1, 1)), subscriptionService);

                // Check if that subscription only added the first one
                Assert.That(customer?.Subscription?.Frequency, Is.EqualTo("bi-weekly"));
            }
        }

        /// <summary>
        /// Testing an edge case for adding subscription to see if it can handle null subscription.
        /// </summary>
        [Test]
        public void TestAddSubscriptionNull()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;
            SubscriptionService subscriptionService = new SubscriptionService();

            if (customer != null)
            {
                // Create a subscription
                bool result = customer.AddSubscription(null, subscriptionService);

                // Check if that subscription was not added
                Assert.That(result, Is.EqualTo(false));
            }
        }

        /// <summary>
        /// Testing an normal case for add order to see if it can add an order.
        /// </summary>
        [Test]
        public void TestAddOrder()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;

            // Create a subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(2, 2) });
            bool result = userManager.AddSubscription(new Subscription("testSubscription", coffee, new BagSizes(2, 2), "weekly", new DateTime(1, 1, 1)));

            if (customer != null)
            {
                // Create a order from that subscription
                bool result2 = userManager.AddOrder(customer.Subscription);

                Assert.That(result2, Is.EqualTo(true));
            }
        }

        /// <summary>
        /// Testing an edge case for adding order to see if it can add a null subscription.
        /// </summary>
        [Test]
        public void TestAddOrderNull()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;

            // Create a subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(2, 2) });
            bool result = userManager.AddSubscription(new Subscription("testSubscription", coffee, new BagSizes(2, 2), "weekly", new DateTime(1, 1, 1)));

            // Create a order from that subscription
            bool result2 = userManager.AddOrder(null);

            Assert.That(result2, Is.EqualTo(false));
        }

        /// <summary>
        /// Testing a normal case for RateOrder method which it's rating the order.
        /// </summary>
        [Test]
        public void TestRateOrder()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;

            // Create a subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(2, 2) });
            bool result = userManager.AddSubscription(new Subscription("testSubscription", coffee, new BagSizes(2, 2), "weekly", new DateTime(1, 1, 1)));

            if (customer != null)
            {
                // Create a order from that subscription
                bool result2 = userManager.AddOrder(customer.Subscription);

                // Rate the coffee
                bool result3 = userManager.RateOrder(customer.Order, 5, "Good coffee");

                Assert.That(customer?.Order?.Rate?.Rate, Is.EqualTo(5));
            }
        }

        /// <summary>
        /// Testing a boundary case for RateOrder method with rating the order out from 1-5.
        /// </summary>
        [Test]
        public void TestRateOrderInvalid()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;

            // Create a subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(2, 2) });
            bool result = userManager.AddSubscription(new Subscription("testSubscription", coffee, new BagSizes(2, 2), "weekly", new DateTime(1, 1, 1)));

            if (customer != null)
            {
                // Create a order from that subscription
                bool result2 = userManager.AddOrder(customer.Subscription);

                // Rate the coffee
                bool result3 = userManager.RateOrder(customer.Order, 7, "Good coffee");

                Assert.That(result3, Is.EqualTo(false));
            }
        }

        /// <summary>
        /// Testing an edge case for RateOrder method with null order.
        /// </summary>
        [Test]
        public void TestRateOrderNull()
        {
            // Create a customer user
            UserManager userManager = new UserManager();
            userManager.Register("testUser", "testPassword", "testEmail", new DateTime(1, 1, 1), "testAddress", "testPayment", "Customer");
            Customer? customer = userManager.CurrentUser as Customer;

            // Create a subscription
            Coffee coffee = new Coffee("testCoffee", "testOrigin", "testRoast", "testFlavor", new List<BagSizes>() { new BagSizes(2, 2) });
            bool result = userManager.AddSubscription(new Subscription("testSubscription", coffee, new BagSizes(2, 2), "weekly", new DateTime(1, 1, 1)));

            if (customer != null)
            {
                // Create a order from that subscription
                bool result2 = userManager.AddOrder(customer.Subscription);

                // Rate the coffee
                bool result3 = userManager.RateOrder(null, 2, "Good coffee");

                Assert.That(result3, Is.EqualTo(false));
            }
        }
    }
}
