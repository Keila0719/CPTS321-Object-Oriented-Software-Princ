// <copyright file="Form1.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

using System.ComponentModel;
using System.Text;
using SubscriptionPlatformService;

namespace SubscriptionGUI
{
    /// <summary>
    /// Manages all the UI actions.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Create a new object og userManager.
        /// </summary>
        private readonly UserManager userManager = new UserManager();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Initializes the UI by calling the initialize component and application.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeApplication();
        }

        /// <summary>
        /// Initialize the application for the UI.
        /// </summary>
        public void InitializeApplication()
        {
            this.WindowState = FormWindowState.Maximized;

            // Initialize the application for the Guest user
            this.OnUserPropertyChanged(null, new PropertyChangedEventArgs("Guest"));
            this.userManager.UserStateChanged += (sender, e) => this.OnUserPropertyChanged(sender, e);
            this.userManager.UIPropertyChanged += this.OnUIPropertyChanged;

            // coffeeService.UIPropertyChanged += OnUIPropertyChanged;
        }

        /// <summary>
        /// When it gets notify that a UI property has changed, based on the e, it will do the designated operations.
        /// Referenced the following to learn how to not overwrite the text when adding information:
        /// https://stackoverflow.com/questions/11108411/appendline-is-not-inserting-new-line.
        /// </summary>
        /// <param name="sender"> Object being changed.</param>
        /// <param name="e"> The change in property.</param>
        private void OnUIPropertyChanged(object? sender, PropertyChangedEventArgs? e)
        {
            // Check which property has been changed
            if (e?.PropertyName == "Coffee")
            {
                List<Coffee> coffees = this.userManager.GetCoffeeList();
                StringBuilder text = new StringBuilder();

                text.AppendLine("Browse Coffees");
                text.AppendLine();

                // Print the name, origin, roast, flavor, and bag sizes of each coffee
                foreach (Coffee coffee in coffees)
                {
                    text.AppendLine("Coffee Name: " + coffee.Name);
                    text.AppendLine("- Origin: " + coffee.Origin);
                    text.AppendLine("- Roast Type: " + coffee.RoastType);
                    text.AppendLine("- Flavor Notes: " + coffee.FlavorNotes);
                    text.AppendLine("- Bag Sizes: ");

                    // Print info about each bag and their price
                    foreach (BagSizes bagSize in coffee.BagSizes)
                    {
                        text.AppendLine("\t - " + bagSize.BagSize.ToString() + " oz;     $" + bagSize.Price.ToString());
                    }

                    text.AppendLine();
                }

                // Print the information to the UI
                this.BrowseCoffeeText.Text = text.ToString();
            }
            else if (e?.PropertyName == "Subscription")
            {
                this.UpdateOrderDescription();
            }
            else if (e?.PropertyName == "Taste Profile")
            {
                this.UpdateTasteProfileDescription();
                this.TasteProfileFalvor.Text = string.Empty;
                this.TasteProfileRoast.SelectedIndex = -1;
                this.TasteProfileStrength.SelectedIndex = -1;
            }
            else if (e?.PropertyName == "Order")
            {
                if (this.userManager.CurrentUser is Customer customer)
                {
                    this.RatePanel.Visible = true;
                    this.RatePanel.BringToFront();
                    customer.OrderCame = true;
                }
            }
            else if (e?.PropertyName == "Rate")
            {
                if (this.userManager.CurrentUser is Customer customer)
                {
                    this.RatePanel.Visible = false;
                    this.OrderPanel.Visible = true;
                    this.OrderPanel.BringToFront();
                    customer.OrderCame = false;
                    this.UpdateOrderDescription();
                }
            }
            else if (e?.PropertyName == "Activity History")
            {
                User? user = this.userManager.CurrentUser;
                if (user is SystemAdministrator systemAdministrator)
                {
                    StringBuilder text = new StringBuilder();
                    text.AppendLine("Your Activity History:");
                    List<ActivityLog>? logs = this.userManager?.GetActivities();
                    if (logs != null)
                    {
                        foreach (ActivityLog? log in logs)
                        {
                            text.AppendLine("- User: " + log.User.UserName);
                            text.AppendLine("- Action: " + log.Action);
                            text.AppendLine("- Time: " + log.Time.ToString());
                            text.AppendLine("- Description: " + log.Description);
                            text.AppendLine();
                        }

                        this.ActivityHistoryDisplay.Text = text.ToString();
                    }
                }
            }
            else if (e?.PropertyName == "Activity History Customer")
            {
                User? user = this.userManager.CurrentUser;
                if (user is Customer customer)
                {
                    StringBuilder text = new StringBuilder();
                    text.AppendLine("Your Activity History:");
                    foreach (ActivityLog log in customer.ViewActivityHistory())
                    {
                        text.AppendLine("- User: " + log.User.UserName);
                        text.AppendLine("- Action: " + log.Action);
                        text.AppendLine("- Time: " + log.Time.ToString());
                        text.AppendLine("- Description: " + log.Description);
                        text.AppendLine();
                    }

                    this.ActivityHistoryDisplay.Text = text.ToString();
                }
            }
            else if (e?.PropertyName == "Price Rule")
            {
                this.RuleApply.SelectedIndex = -1;
                this.RuleDiscount.Text = string.Empty;
                this.RuleValue.Text = string.Empty;
                this.RuleDuration.Text = string.Empty;
            }
        }

        /// <summary>
        /// This is fired when the user's property has been changed.
        /// </summary>
        /// <param name="sender"> The current user who's making the change.</param>
        /// <param name="e"> The state of user that it changed to.</param>
        private void OnUserPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Initialize the board for the users
            this.TasteProfilePanel.Visible = false;
            this.SubscriptionPanel.Visible = false;
            this.HistoryPanel.Visible = false;
            this.OrderPanel.Visible = false;
            this.CoffeePanel.Visible = false;
            this.PricingPanel.Visible = false;
            this.LogoutPanel.Visible = false;
            this.LoginPanel.Visible = true;
            this.RegisterPanel.Visible = true;
            this.RecommendationPanel.Visible = false;

            // Update the UI based on the current user state, show only the things they can control
            if (e.PropertyName != "Guest")
            {
                this.LogoutPanel.BringToFront();
                this.LoginPanel.BringToFront();
                this.LogoutPanel.Visible = true;
                this.LoginPanel.Visible = false;
                this.RegisterPanel.Visible = false;
                this.RecommendationPanel.Visible = true;
                this.RecommendationPanel.Visible = false;
            }

            if (e.PropertyName == "Customer")
            {
                this.RegisterPanel.Visible = true;
                this.TasteProfilePanel.Visible = true;
                this.SubscriptionPanel.Visible = true;
                this.HistoryPanel.Visible = true;
                this.SubscriptionBag.Visible = false;
                this.SubscriptionBagTitle.Visible = false;
                this.SubscriptionButton.Visible = false;
                this.SubscriptionDelivery.Visible = false;
                this.SubscriptionDeleveryTitle.Visible = false;
                this.SubscriptionStartDate.Visible = false;
                this.SubscriptionStartDateTitle.Visible = false;
                this.SubscriptionCoffee.Visible = false;
                this.SubscriptionCoffeeTitle.Visible = false;
                this.UpdateOrderDescription();
                this.UpdateTasteProfileDescription();
                this.RecommendationPanel.BringToFront();
                this.RecommendationPanel.Visible = true;
                this.SubscriptionAssume.Visible = false;

                if (this.userManager.CurrentUser is Customer customer)
                {
                    if (customer.OrderCame)
                    {
                        this.OrderPanel.Visible = false;
                        this.RatePanel.Visible = true;
                        this.RatePanel.BringToFront();
                        customer.OrderCame = true;
                    }
                    else
                    {
                        this.RatePanel.Visible = false;
                        this.OrderPanel.Visible = true;
                        this.OrderPanel.BringToFront();
                        customer.OrderCame = false;
                    }
                }
            }
            else if (e.PropertyName == "Supplier")
            {
                this.CoffeePanel.Visible = true;
            }
            else if (e.PropertyName == "Subscription Manager")
            {
                this.PricingPanel.Visible = true;
                this.RuleValue.Visible = false;
                this.RuleValueTitle.Visible = false;
            }
            else if (e.PropertyName == "System Administrator")
            {
                this.HistoryPanel.Visible = true;
            }
        }

        /// <summary>
        /// When the subscription is created, it will update the subscription description on the OrderDescription
        /// text thing on the UI.
        /// </summary>
        private void UpdateOrderDescription()
        {
            // Get the subscription information from the customer
            User? user = this.userManager.CurrentUser;
            Customer? customer = user as Customer;
            Subscription? subscriptions = customer?.Subscription;

            // Show the information on the orderDescription UI item
            StringBuilder text = new StringBuilder();

            // If subscription if null, return to end
            if (subscriptions == null)
            {
                text.AppendLine("Chosen Subscription:");
                text.AppendLine("- Coffee: ");
                text.AppendLine("- Bag Size: ");
                text.AppendLine("- Price:");
                text.AppendLine("- Price after discount if applicable:");
            }
            else
            {
                text.AppendLine("Chosen Subscription:");
                text.AppendLine("- Coffee: " + subscriptions?.Coffee?.Name);
                text.AppendLine("- Bag Size: " + subscriptions?.BagSize?.BagSize.ToString());
                text.AppendLine("- Price: $" + subscriptions?.BagSize?.Price.ToString());
                double? price = this.userManager.CalculatePrice(subscriptions);
                text.AppendLine("- Price after discount if applicable: $" + price);
            }

            this.OrderDescription.Text = text.ToString();
        }

        /// <summary>
        /// Updates the profile description with information.
        /// </summary>
        private void UpdateTasteProfileDescription()
        {
            if (this.userManager.CurrentUser is Customer customer)
            {
                StringBuilder text = new StringBuilder();
                if (customer.TasteProfile != null)
                {
                    text.AppendLine("Your Current TasteProfile:");
                    text.AppendLine("- Flavor Notes: " + customer.TasteProfile.Flavor);
                    text.AppendLine("- Roast: " + customer.TasteProfile.Roast);
                    text.AppendLine("- Strength: " + customer.TasteProfile.Strength);
                }
                else
                {
                    text.AppendLine("Your Current TasteProfile:");
                    text.AppendLine("- Flavor Notes: ");
                    text.AppendLine("- Roast: ");
                    text.AppendLine("- Strength: ");
                }

                this.TasteProfileDisplay.Text = text.ToString();
            }
        }

        /// <summary>
        /// Executes when the user press the login button. This is used to get the information from username and password
        /// and checks if it is one of the user and if the info match.
        /// </summary>
        /// <param name="sender"> Object that has been clicked.</param>
        /// <param name="e"> The event data of button clicked.</param>
        private void Login_Click(object sender, EventArgs e)
        {
            // Initializes the label
            this.LoginUsernameTitle.ForeColor = Color.White;
            this.LoginPasswordTitle.ForeColor = Color.White;
            this.LoginUsernameTitle.Text = "Username:";
            this.LoginPasswordTitle.Text = "Password:";

            // Get the information from the userinput
            string name = this.LoginUsername.Text.Trim();
            string password = this.LoginPassword.Text.Trim();

            // If the information is empty, let the user know username or password may be incorrect
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                this.LoginUsernameTitle.ForeColor = Color.Red;
                this.LoginPasswordTitle.ForeColor = Color.Red;
                this.LoginUsernameTitle.Text = "Username: Username or password may be wrong";
                this.LoginPasswordTitle.Text = "Password: Username or password may be wrong";
            }

            // Try to log in with the name and password info
            bool result = this.userManager.Login(name, password);

            // If the user was not able to login, let them know
            if (!result)
            {
                this.LoginUsernameTitle.ForeColor = Color.Red;
                this.LoginPasswordTitle.ForeColor = Color.Red;
                this.LoginUsernameTitle.Text = "Username: Username or password may be wrong";
                this.LoginPasswordTitle.Text = "Password: Username or password may be wrong";
                return;
            }

            // If successfully logged in, reset the text box
            this.LoginUsername.Text = string.Empty;
            this.LoginPassword.Text = string.Empty;
        }

        /// <summary>
        /// Executes when the user press the Register button. This is used to get the information from each text catefory and
        /// create a user.
        /// Referenced this link to learn how to use the DateTime:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datetimepicker?view=windowsdesktop-10.0
        /// https://www.geeksforgeeks.org/c-sharp/c-sharp-datetimepicker-class/.
        /// </summary>
        /// <param name="sender"> The object that has been clicked.</param>
        /// <param name="e"> The event data.</param>
        private void Register_Click(object sender, EventArgs e)
        {
            // Initialize each text box as white and the RegisterAs text color
            this.RegisterNameText.BackColor = Color.White;
            this.RegisterEmailText.BackColor = Color.White;
            this.RegisterPasswordText.BackColor = Color.White;
            this.RegisterAddressText.BackColor = Color.White;
            this.RegisterPaymentText.BackColor = Color.White;
            this.RegisterAs.ForeColor = Color.White;
            this.NameTitle.ForeColor = Color.White;

            // Get each information from the UI
            string name = this.RegisterNameText.Text.Trim();
            DateTime date = this.RegisterDate.Value;
            string email = this.RegisterEmailText.Text.Trim();
            string password = this.RegisterPasswordText.Text.Trim();
            string address = this.RegisterAddressText.Text.Trim();
            string payment = this.RegisterPaymentText.Text.Trim();
            string? type = this.RegisterType.SelectedItem?.ToString();
            bool check = false;

            // Check if the name is null or empty, if it is make the textbox red to let the user know
            if (string.IsNullOrEmpty(name))
            {
                this.RegisterNameText.BackColor = Color.Red;
                check = true;
            }

            // Check if the email is null or empty, if it is make the textbox red to let the user know
            if (string.IsNullOrEmpty(email))
            {
                this.RegisterEmailText.BackColor = Color.Red;
                check = true;
            }

            // Check if the password is null or empty, if it is make the textbox red to let the user know
            if (string.IsNullOrEmpty(password))
            {
                this.RegisterPasswordText.BackColor = Color.Red;
                check = true;
            }

            // Check if the address is null or empty, if it is make the textbox red to let the user know
            if (string.IsNullOrEmpty(address))
            {
                this.RegisterAddressText.BackColor = Color.Red;
                check = true;
            }

            // Check if the payment is null or empty, if it is make the textbox red to let the user know
            if (string.IsNullOrEmpty(payment))
            {
                this.RegisterPaymentText.BackColor = Color.Red;
                check = true;
            }

            // Check if the type is null or empty, if it is make the textbox red to let the user know
            if (string.IsNullOrEmpty(type))
            {
                this.RegisterAs.ForeColor = Color.Red;
                check = true;
            }

            // Check for duplicated username, if there is, let the user know
            if (this.userManager.IsDuplicate(name))
            {
                this.NameTitle.ForeColor = Color.Red;
            }

            // Check if the check true or not, true would mean there was informaiton missing
            if (check)
            {
                return;
            }
            else
            {
                // Register the account and empty all information user inputted on the UI
                bool result = this.userManager.Register(name, password, email, date, address, payment, type);
                this.RegisterNameText.Text = string.Empty;
                this.RegisterEmailText.Text = string.Empty;
                this.RegisterPasswordText.Text = string.Empty;
                this.RegisterAddressText.Text = string.Empty;
                this.RegisterPaymentText.Text = string.Empty;
                this.RegisterType.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// When the create button is pressed for tasteProfile button, the information for the tasteprofile will be updated.
        /// </summary>
        /// <param name="sender"> object that is changed.</param>
        /// <param name="e"> The event data that has been changed.</param>
        private void TasteProfileButton_Click(object sender, EventArgs e)
        {
            // Initialize the back color of the text box to white
            this.TasteProfileFalvor.BackColor = Color.White;
            this.TasteProfileRoast.BackColor = Color.White;
            this.TasteProfileStrength.BackColor = Color.White;

            // Get the information from UI
            string flavor = this.TasteProfileFalvor.Text.Trim();
            string roast = this.TasteProfileRoast.Text.Trim();
            string strength = this.TasteProfileStrength.Text.Trim();
            bool infoMissing = false;

            // If any information is missing, let them know by making the text red
            if (string.IsNullOrEmpty(flavor))
            {
                this.TasteProfileFalvor.BackColor = Color.Red;
                infoMissing = true;
            }

            if (string.IsNullOrEmpty(roast))
            {
                this.TasteProfileRoast.BackColor = Color.Red;
                infoMissing = true;
            }

            if (string.IsNullOrEmpty(strength))
            {
                this.TasteProfileStrength.BackColor = Color.Red;
                infoMissing = true;
            }

            if (infoMissing)
            {
                return;
            }

            // Get the current user
            User? currentUser = this.userManager.CurrentUser;

            // Cast the currentUser as a customer
            if (this.userManager.CurrentUser is Customer customer)
            {
                // If there is no invalid input, add the coffee
                customer.CustomizeTasteProfile(flavor, roast, strength);
            }
        }

        /// <summary>
        /// When the subscription button is pressed, it will create a subscription object.
        /// </summary>
        /// <param name="sender"> The object that is being changed.</param>
        /// <param name="e"> The event data that change happened.</param>
        private void SubscriptionButton_Click(object sender, EventArgs e)
        {
            // Get the information from the UI
            string type = this.SubscriptionStrategy.Text.Trim();
            string coffeeName = this.SubscriptionCoffee.Text.Trim();
            string bagInfo = this.SubscriptionBag.Text.Trim();
            DateTime date = this.SubscriptionStartDate.Value;
            string frequency = this.SubscriptionDelivery.Text;
            bool infoMissing = false;

            double bagSizeNum = 0;
            double price = 0;

            // Check if baginfo text is null or empty
            if (string.IsNullOrEmpty(bagInfo))
            {
                this.SubscriptionBag.BackColor = Color.Red;
                infoMissing = true;
            }
            else
            {
                string[] info = bagInfo.Split(';');
                string bagSize = info[0].Trim();
                string priceText = info[1].Trim();

                // Check if bagsize can be converted to double
                if (!double.TryParse(bagSize.Replace("oz", string.Empty), out bagSizeNum))
                {
                    this.SubscriptionBag.BackColor = Color.Red;
                    infoMissing = true;
                }

                // Check if price can be converted to double
                if (!double.TryParse(priceText.Replace("$", string.Empty), out price))
                {
                    this.SubscriptionBag.BackColor = Color.Red;
                    infoMissing = true;
                }
            }

            // Check if type is null or empty
            if (string.IsNullOrEmpty(type))
            {
                this.SubscriptionStrategy.BackColor = Color.Red;
                infoMissing = true;
            }

            // Check if coffeeName is null or empty
            if (string.IsNullOrEmpty(coffeeName))
            {
                this.SubscriptionCoffee.BackColor = Color.Red;
                infoMissing = true;
            }

            // Check if frequency is null or empty
            if (string.IsNullOrEmpty(frequency))
            {
                this.SubscriptionDelivery.BackColor = Color.Red;
                infoMissing = true;
            }

            // If any information is missing, return
            if (infoMissing)
            {
                return;
            }

            // If the current user is a customer, add the subscription
            User? user = this.userManager.CurrentUser;
            if (this.userManager.CurrentUser is Customer customer)
            {
                // Get the coffee object using the name to search
                Coffee? coffee = this.userManager.GetCoffee(coffeeName);

                if (coffee != null)
                {
                    // Add the coffee
                    this.userManager.AddSubscription(new Subscription(type, coffee, new BagSizes(bagSizeNum, price), frequency, date));
                }
            }
        }

        /// <summary>
        /// Put each of the bag size from the coffee that the customer selected.
        /// </summary>
        /// <param name="sender"> The object that has changed.</param>
        /// <param name="e"> Event data that changed.</param>
        private void SubscriptionCoffee_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the coffee name information from UI
            string coffeeName = this.SubscriptionCoffee.Text.ToString();

            // If the coffeeName isn't null or empty, get the coffee and show each of the bag size and their price
            if (!string.IsNullOrEmpty(coffeeName))
            {
                // Get the coffee
                Coffee? coffee = this.userManager.GetCoffee(coffeeName);

                // If that coffee isn't null, print each bag size and price
                if (coffee != null)
                {
                    List<BagSizes> bag = coffee.BagSizes;
                    this.SubscriptionBag.Items.Clear();

                    foreach (BagSizes bagSize in bag)
                    {
                        this.SubscriptionBag.Items.Add(bagSize.BagSize.ToString() + "oz; $" + bagSize.Price.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// When the subscription strategy button is pressed, it will change the UI based on which subscription strategy they chose.
        /// </summary>
        /// <param name="sender"> The object that has changed.</param>
        /// <param name="e"> The event data that has been changed.</param>
        private void SubscriptionStrategyButton_Click(object sender, EventArgs e)
        {
            // Initialize the UI of each text
            this.SubscriptionStrategy.BackColor = Color.White;
            this.SubscriptionBag.Visible = false;
            this.SubscriptionBagTitle.Visible = false;
            this.SubscriptionButton.Visible = false;
            this.SubscriptionDelivery.Visible = false;
            this.SubscriptionDeleveryTitle.Visible = false;
            this.SubscriptionStartDate.Visible = false;
            this.SubscriptionStartDateTitle.Visible = false;
            this.SubscriptionCoffee.Visible = false;
            this.SubscriptionCoffeeTitle.Visible = false;
            this.SubscriptionAssume.Visible = false;

            // Get the strategy information
            string strategy = this.SubscriptionStrategy.Text;

            // If the strategy is red, make the background color red
            if (string.IsNullOrEmpty(strategy))
            {
                this.SubscriptionStrategy.BackColor = Color.Red;
            }

            // When they choose manual selection, show information about what they can choose
            if (strategy == "Manual Selection")
            {
                // show the extra UI object to show up
                this.SubscriptionBag.Visible = true;
                this.SubscriptionBagTitle.Visible = true;
                this.SubscriptionButton.Visible = true;
                this.SubscriptionDelivery.Visible = true;
                this.SubscriptionDeleveryTitle.Visible = true;
                this.SubscriptionStartDate.Visible = true;
                this.SubscriptionStartDateTitle.Visible = true;
                this.SubscriptionCoffee.Visible = true;
                this.SubscriptionCoffeeTitle.Visible = true;

                // show each of the coffee in the subscriptionCoffee object
                List<Coffee> coffees = this.userManager.GetCoffeeList();
                this.SubscriptionCoffee.Items.Clear();
                foreach (Coffee coffee in coffees)
                {
                    if (coffee != null && coffee.Name != null)
                    {
                        this.SubscriptionCoffee?.Items?.Add(coffee.Name.ToString());
                    }
                }
            }
            else if (strategy == "Recommendation-based selection")
            {
                // show the extra UI object to show up
                this.SubscriptionBag.Visible = true;
                this.SubscriptionBagTitle.Visible = true;
                this.SubscriptionButton.Visible = true;
                this.SubscriptionDelivery.Visible = true;
                this.SubscriptionDeleveryTitle.Visible = true;
                this.SubscriptionStartDate.Visible = true;
                this.SubscriptionStartDateTitle.Visible = true;
                this.SubscriptionCoffee.Visible = true;
                this.SubscriptionCoffeeTitle.Visible = true;
                this.SubscriptionAssume.Visible = true;

                // show top 1 of the coffee that was recommended
                List<Coffee>? coffees = this.userManager.GenerateRecommendation();
                this.SubscriptionCoffee.Items.Clear();
                if (coffees != null)
                {
                    int count = coffees.Count();
                    int index = 0;
                    while (index < 1 && index < count)
                    {
                        if (coffees != null && coffees[index].Name != null)
                        {
                            string? name = coffees[index]?.Name?.ToString();
                            if (!string.IsNullOrEmpty(name))
                            {
                                this.SubscriptionCoffee?.Items?.Add(name);
                            }
                        }
                    }
                }
            }
            else if (strategy == "Mix of the two")
            {
                // show the extra UI object to show up
                this.SubscriptionBag.Visible = true;
                this.SubscriptionBagTitle.Visible = true;
                this.SubscriptionButton.Visible = true;
                this.SubscriptionDelivery.Visible = true;
                this.SubscriptionDeleveryTitle.Visible = true;
                this.SubscriptionStartDate.Visible = true;
                this.SubscriptionStartDateTitle.Visible = true;
                this.SubscriptionCoffee.Visible = true;
                this.SubscriptionCoffeeTitle.Visible = true;
                this.SubscriptionAssume.Visible = true;

                // show top 3 of the coffee that was recommended
                List<Coffee>? coffees = this.userManager.GenerateRecommendation();
                this.SubscriptionCoffee.Items.Clear();
                if (coffees != null)
                {
                    int count = coffees.Count();
                    int index = 0;
                    while (index < 3 && index < count)
                    {
                        if (coffees != null && coffees[index].Name != null)
                        {
                            string? name = coffees[index]?.Name?.ToString();
                            if (!string.IsNullOrEmpty(name))
                            {
                                this.SubscriptionCoffee?.Items?.Add(name);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// When the order button is pressed, create the order iff the user is a customer.
        /// </summary>
        /// <param name="sender"> The object that was changed.</param>
        /// <param name="e"> The event data that was changed.</param>
        private void OrderButton_Click(object sender, EventArgs e)
        {
            // If the current user is a customer
            if (this.userManager.CurrentUser is Customer customer)
            {
                // Get the subscription from the customer
                Subscription? subscription = customer?.Subscription;

                // If there exist a subscripton, add the order
                if (subscription != null)
                {
                    this.userManager.AddOrder(subscription);
                }
            }
        }

        /// <summary>
        /// When the creating coffee button is pressed, get the information that user enter and create a coffee object.
        /// </summary>
        /// <param name="sender">The object that was changed.</param>
        /// <param name="e"> The event data that was changed.</param>
        private void CoffeeButton_Click(object sender, EventArgs e)
        {
            // Initialize each text box as white
            this.CoffeeName.BackColor = Color.White;
            this.CoffeeOrigin.BackColor = Color.White;
            this.CoffeeRoast.BackColor = Color.White;
            this.CoffeeFlavor.BackColor = Color.White;
            this.CoffeeData.DefaultCellStyle.BackColor = Color.White;
            this.CoffeeWarning.ForeColor = Color.White;

            // Get each of the text from the text box
            string name = this.CoffeeName.Text.Trim();
            string origin = this.CoffeeOrigin.Text.Trim();
            string roast = this.CoffeeRoast.Text.Trim();
            string flavor = this.CoffeeFlavor.Text.Trim();
            List<BagSizes> bagSizes = new List<BagSizes>();

            // For each row that the user decided to add, get the bag size and price to create the bag size object
            foreach (DataGridViewRow row in this.CoffeeData.Rows)
            {
                // Get the bag size from the
                string? bagSizeText = row.Cells["BagSize"].Value?.ToString()?.Trim();
                string? priceText = row.Cells["Price"].Value?.ToString()?.Trim();

                // Check if the information is empty or null
                if (string.IsNullOrEmpty(bagSizeText) || string.IsNullOrEmpty(priceText))
                {
                    continue;
                }

                // Check if the information is in double
                if (!double.TryParse(bagSizeText, out double bagSizeValue) || !double.TryParse(priceText, out double priceValue))
                {
                    continue;
                }

                // For each of the bag in bagsizes, check if it's the same as bagsizevalue
                foreach (BagSizes bag in bagSizes)
                {
                    if (bag.BagSize == bagSizeValue)
                    {
                        this.CoffeeWarning.ForeColor = Color.Red;
                        return;
                    }
                }

                // Create the gagsize object and add it to the bagsizes list
                BagSizes bagSize = new BagSizes(bagSizeValue, priceValue);
                bagSizes.Add(bagSize);
            }

            bool infoMissing = false;

            // If any information is missing, let them know by making the text box red
            if (string.IsNullOrWhiteSpace(name))
            {
                this.CoffeeName.BackColor = Color.Red;
                infoMissing = true;
            }

            if (string.IsNullOrEmpty(origin))
            {
                this.CoffeeOrigin.BackColor = Color.Red;
                infoMissing = true;
            }

            if (string.IsNullOrEmpty(roast))
            {
                this.CoffeeRoast.BackColor = Color.Red;
                infoMissing = true;
            }

            if (string.IsNullOrEmpty(flavor))
            {
                this.CoffeeFlavor.BackColor = Color.Red;
                infoMissing = true;
            }

            if (bagSizes.Count == 0)
            {
                this.CoffeeData.DefaultCellStyle.BackColor = Color.Red;
                infoMissing = true;
            }

            // Get the current user
            User? currentUser = this.userManager.CurrentUser;

            // If there is any missing information, return
            if (infoMissing)
            {
                return;
            }

            // Cast the currentUser to supplier
            if (this.userManager.CurrentUser is Supplier supplier)
            {
                // If there is no invalid input, add the coffee
                bool result = this.userManager.AddCoffee(new Coffee(name, origin, roast, flavor, bagSizes));

                if (result)
                {
                    this.CoffeeName.Text = string.Empty;
                    this.CoffeeOrigin.Text = string.Empty;
                    this.CoffeeRoast.SelectedIndex = -1;
                    this.CoffeeFlavor.Text = string.Empty;
                    this.CoffeeData.Rows.Clear();
                }
            }
        }

        /// <summary>
        /// Create a price discount rule when the button is pressed.
        /// </summary>
        /// <param name="sender">The object that was changed.</param>
        /// <param name="e"> The event data that was changed.</param>
        private void RuleButton_Click(object sender, EventArgs e)
        {
            // Initialize the text box background as white
            this.RuleApply.BackColor = Color.White;
            this.RuleDiscount.BackColor = Color.White;
            this.RuleDuration.BackColor = Color.White;
            this.RuleApply.BackColor = Color.White;

            // Get the information from the UI
            string apply = this.RuleApply.Text.Trim();
            string discount = this.RuleDiscount.Text.Trim();
            string duration = this.RuleDuration.Text.Trim();
            bool infoMissing = false;

            // Check if any information is null or empty, if it is make th ebackground red to notify
            if (string.IsNullOrEmpty(apply))
            {
                this.RuleApply.BackColor = Color.Red;
                infoMissing = true;
            }

            if (!double.TryParse(discount, out double discountValue) || string.IsNullOrEmpty(discount))
            {
                this.RuleDiscount.BackColor = Color.Red;
                infoMissing = true;
            }

            if (!int.TryParse(duration, out int durationValue) || string.IsNullOrEmpty(duration))
            {
                this.RuleDuration.BackColor = Color.Red;
                infoMissing = true;
            }

            // If the applying is a bagsize, coffee, or over specific price, show the value box to get the value.
            string target = this.RuleValue.Text.Trim();
            if (apply == "BagSize" || apply == "Coffee" || apply == "Over Specific Price")
            {
                if (string.IsNullOrEmpty(target))
                {
                    this.RuleValue.BackColor = Color.Red;
                    infoMissing = true;
                }

                if ((apply == "BagSize" && !double.TryParse(target, out double temp)) || (apply == "Over Specific Price" && !double.TryParse(target, out double temp2)))
                {
                    this.RuleValue.BackColor = Color.Red;
                    infoMissing = true;
                }
            }

            // If there are information missing return
            if (infoMissing)
            {
                return;
            }

            // Check if the current user is a subscriptionManager
            if (this.userManager.CurrentUser is SubscriptionManager subscriptionManager)
            {
                // Create the price rule discount
                bool result = this.userManager.CreatePriceRuleDiscount(apply, target, discountValue, durationValue);

                // If the information was added, refresh the UI
                if (result)
                {
                    this.RuleValueTitle.Visible = false;
                    this.RuleValue.Visible = false;
                    this.RuleApply.SelectedIndex = -1;
                    this.RuleDiscount.Text = string.Empty;
                    this.RuleDuration.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Log the user out so other user can register or login.
        /// </summary>
        /// <param name="sender"> The object that was changed.</param>
        /// <param name="e"> The event data of the object.</param>
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // Logout the user and make them to guest user
            this.userManager.Logout();
        }

        /// <summary>
        /// When the selected index changes, show the rule value drop down if it's bagsize, coffee, or over specific price.
        /// </summary>
        /// <param name="sender"> The object that was changed.</param>
        /// <param name="e"> The event data of the object.</param>
        private void RuleApply_SelectedIndexChanged(object sender, EventArgs e)
        {
            string apply = this.RuleApply.Text.Trim();
            if (apply == "BagSize" || apply == "Coffee" || apply == "Over Specific Price")
            {
                this.RuleValueTitle.Visible = true;
                this.RuleValue.Visible = true;
            }
            else
            {
                this.RuleValueTitle.Visible = false;
                this.RuleValue.Visible = false;
            }
        }

        /// <summary>
        /// Once the order is completed, rate the order in the scale of 1 - 5 with any feedback.
        /// </summary>
        /// <param name="sender"> The object that was changed.</param>
        /// <param name="e"> The event data that was changed.</param>
        private void RateButton_Click(object sender, EventArgs e)
        {
            // Initialize the text box as white

            // Get the information from the text
            string rate = this.RateRate.Text.Trim();
            string feedback = this.RateFeedback.Text.Trim();
            int rateValue = 0;

            // Check if rate is empty
            if (string.IsNullOrEmpty(rate) || !int.TryParse(rate, out rateValue))
            {
                this.RateRate.BackColor = Color.Red;
                return;
            }

            // Check if the rateValue is in the range of 1-5
            if (rateValue < 1 || rateValue > 5)
            {
                this.RateRate.BackColor = Color.Red;
                return;
            }

            // Feedback is optional, if there is no input, make the string
            if (string.IsNullOrEmpty(feedback))
            {
                feedback = string.Empty;
            }

            // If the current user is a customer, create an rate for this order
            if (this.userManager.CurrentUser is Customer customer)
            {
                Order? order = customer?.Order;
                this.userManager.RateOrder(order, rateValue, feedback);
            }
        }

        /// <summary>
        /// When the recommendation button is pressed, it will generate a recommendation by calling the method from userManager.
        /// </summary>
        /// <param name="sender"> The changed object.</param>
        /// <param name="e"> The event data of the changed object.</param>
        private void RecommendationButton_Click(object sender, EventArgs e)
        {
            // Check if the current user is customer
            if (this.userManager.CurrentUser is Customer customer)
            {
                // Get teh recommendation coffees
                List<Coffee>? coffees = this.userManager?.GenerateRecommendation();

                if (coffees != null)
                {
                    int count = coffees.Count;
                    int index = 0;
                    StringBuilder text = new StringBuilder();

                    // Show the top 3 coffee recommendation
                    while (index < 3 && index < count)
                    {
                        text.AppendLine("Coffee Name: " + coffees[index].Name);
                        text.AppendLine("- Origin: " + coffees[index].Origin);
                        text.AppendLine("- Roast Type: " + coffees[index].RoastType);
                        text.AppendLine("- Flavor Notes: " + coffees[index].FlavorNotes);
                        text.AppendLine("- Bag Sizes: ");
                        index++;
                    }

                    // Print the top three info into the description
                    this.RecommendationDescription.Text = text.ToString();
                }
            }
        }
    }
}