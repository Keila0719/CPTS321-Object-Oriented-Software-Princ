namespace SubscriptionGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel3 = new Panel();
            LogoutPanel = new Panel();
            label8 = new Label();
            LogoutButton = new Button();
            HistoryPanel = new Panel();
            ActivityHistoryDisplay = new TextBox();
            label13 = new Label();
            CoffeePanel = new Panel();
            CoffeeWarning = new Label();
            CoffeeRoast = new ComboBox();
            CoffeeButton = new Button();
            CoffeeData = new DataGridView();
            BagSize = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            label22 = new Label();
            CoffeeFlavor = new TextBox();
            label21 = new Label();
            label20 = new Label();
            CoffeeOrigin = new TextBox();
            label19 = new Label();
            CoffeeName = new TextBox();
            label18 = new Label();
            label12 = new Label();
            PricingPanel = new Panel();
            RuleValueTitle = new Label();
            RuleValue = new TextBox();
            RuleButton = new Button();
            RuleDuration = new TextBox();
            label32 = new Label();
            RuleApply = new ComboBox();
            RuleDiscount = new TextBox();
            label31 = new Label();
            label30 = new Label();
            label9 = new Label();
            OrderPanel = new Panel();
            RatePanel = new Panel();
            RateButton = new Button();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            RateFeedback = new TextBox();
            RateRate = new TextBox();
            label2 = new Label();
            label17 = new Label();
            OrderDescription = new TextBox();
            OrderButton = new Button();
            label3 = new Label();
            SubscriptionPanel = new Panel();
            SubscriptionAssume = new Label();
            SubscriptionCoffee = new ComboBox();
            SubscriptionCoffeeTitle = new Label();
            SubscriptionStrategyButton = new Button();
            SubscriptionButton = new Button();
            SubscriptionStartDate = new DateTimePicker();
            SubscriptionDelivery = new ComboBox();
            SubscriptionStartDateTitle = new Label();
            SubscriptionDeleveryTitle = new Label();
            SubscriptionBag = new ComboBox();
            SubscriptionBagTitle = new Label();
            SubscriptionStrategy = new ComboBox();
            SubscriptionStrategyTitle = new Label();
            label1 = new Label();
            TasteProfilePanel = new Panel();
            TasteProfileDisplay = new TextBox();
            TasteProfileFalvor = new TextBox();
            TasteProfileButton = new Button();
            TasteProfileStrength = new ComboBox();
            TasteProfileStrengthTitle = new Label();
            TasteProfileRoast = new ComboBox();
            TasteProfileRoastTitle = new Label();
            TasteProfileFlavorTitle = new Label();
            TasteProfileTitle = new Label();
            LoginPanel = new Panel();
            LoginPassword = new TextBox();
            Login = new Button();
            LoginPanelTitle = new Label();
            LoginUsername = new TextBox();
            LoginPasswordTitle = new Label();
            LoginUsernameTitle = new Label();
            RegisterPanel = new Panel();
            RecommendationPanel = new Panel();
            label14 = new Label();
            RecommendationDescription = new TextBox();
            RecommendationButton = new Button();
            label16 = new Label();
            RegisterType = new ComboBox();
            RegisterDate = new DateTimePicker();
            RegisterPasswordText = new TextBox();
            RegisterEmailText = new TextBox();
            RegisterNameText = new TextBox();
            RegisterPaymentText = new TextBox();
            Register = new Button();
            label11 = new Label();
            RegisterAs = new Label();
            RegisterAddressText = new TextBox();
            NameTitle = new Label();
            label4 = new Label();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel5 = new Panel();
            label15 = new Label();
            BrowseCoffeeText = new TextBox();
            label10 = new Label();
            panel3.SuspendLayout();
            LogoutPanel.SuspendLayout();
            HistoryPanel.SuspendLayout();
            CoffeePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CoffeeData).BeginInit();
            PricingPanel.SuspendLayout();
            OrderPanel.SuspendLayout();
            RatePanel.SuspendLayout();
            SubscriptionPanel.SuspendLayout();
            TasteProfilePanel.SuspendLayout();
            LoginPanel.SuspendLayout();
            RegisterPanel.SuspendLayout();
            RecommendationPanel.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSteelBlue;
            panel3.Controls.Add(LogoutPanel);
            panel3.Controls.Add(HistoryPanel);
            panel3.Controls.Add(CoffeePanel);
            panel3.Controls.Add(PricingPanel);
            panel3.Controls.Add(OrderPanel);
            panel3.Controls.Add(SubscriptionPanel);
            panel3.Controls.Add(TasteProfilePanel);
            panel3.Controls.Add(LoginPanel);
            panel3.Controls.Add(RegisterPanel);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1916, 1175);
            panel3.TabIndex = 1;
            // 
            // LogoutPanel
            // 
            LogoutPanel.BackColor = Color.CadetBlue;
            LogoutPanel.Controls.Add(label8);
            LogoutPanel.Controls.Add(LogoutButton);
            LogoutPanel.Location = new Point(720, 6);
            LogoutPanel.Name = "LogoutPanel";
            LogoutPanel.Size = new Size(491, 248);
            LogoutPanel.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 17F);
            label8.Location = new Point(0, 3);
            label8.Name = "label8";
            label8.Size = new Size(114, 40);
            label8.TabIndex = 24;
            label8.Text = "Logout:";
            // 
            // LogoutButton
            // 
            LogoutButton.ForeColor = SystemColors.ActiveCaptionText;
            LogoutButton.Location = new Point(113, 97);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(250, 50);
            LogoutButton.TabIndex = 23;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // HistoryPanel
            // 
            HistoryPanel.BackColor = Color.CadetBlue;
            HistoryPanel.Controls.Add(ActivityHistoryDisplay);
            HistoryPanel.Controls.Add(label13);
            HistoryPanel.Location = new Point(1228, 6);
            HistoryPanel.Name = "HistoryPanel";
            HistoryPanel.Size = new Size(652, 355);
            HistoryPanel.TabIndex = 29;
            // 
            // ActivityHistoryDisplay
            // 
            ActivityHistoryDisplay.Location = new Point(47, 49);
            ActivityHistoryDisplay.Multiline = true;
            ActivityHistoryDisplay.Name = "ActivityHistoryDisplay";
            ActivityHistoryDisplay.ReadOnly = true;
            ActivityHistoryDisplay.ScrollBars = ScrollBars.Vertical;
            ActivityHistoryDisplay.Size = new Size(593, 284);
            ActivityHistoryDisplay.TabIndex = 19;
            ActivityHistoryDisplay.Text = "Your Activity History:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 17F);
            label13.ForeColor = SystemColors.Control;
            label13.Location = new Point(0, 0);
            label13.Name = "label13";
            label13.Size = new Size(210, 40);
            label13.TabIndex = 28;
            label13.Text = "Activity History";
            // 
            // CoffeePanel
            // 
            CoffeePanel.BackColor = Color.CadetBlue;
            CoffeePanel.Controls.Add(CoffeeWarning);
            CoffeePanel.Controls.Add(CoffeeRoast);
            CoffeePanel.Controls.Add(CoffeeButton);
            CoffeePanel.Controls.Add(CoffeeData);
            CoffeePanel.Controls.Add(label22);
            CoffeePanel.Controls.Add(CoffeeFlavor);
            CoffeePanel.Controls.Add(label21);
            CoffeePanel.Controls.Add(label20);
            CoffeePanel.Controls.Add(CoffeeOrigin);
            CoffeePanel.Controls.Add(label19);
            CoffeePanel.Controls.Add(CoffeeName);
            CoffeePanel.Controls.Add(label18);
            CoffeePanel.Controls.Add(label12);
            CoffeePanel.ForeColor = SystemColors.Control;
            CoffeePanel.Location = new Point(1228, 380);
            CoffeePanel.Name = "CoffeePanel";
            CoffeePanel.Size = new Size(676, 355);
            CoffeePanel.TabIndex = 29;
            // 
            // CoffeeWarning
            // 
            CoffeeWarning.AutoSize = true;
            CoffeeWarning.Font = new Font("Segoe UI", 8F);
            CoffeeWarning.Location = new Point(361, 2);
            CoffeeWarning.Name = "CoffeeWarning";
            CoffeeWarning.Size = new Size(273, 38);
            CoffeeWarning.TabIndex = 46;
            CoffeeWarning.Text = "You cannot have the same bag size for the \r\nsame coffee";
            // 
            // CoffeeRoast
            // 
            CoffeeRoast.BackColor = SystemColors.Window;
            CoffeeRoast.DropDownStyle = ComboBoxStyle.DropDownList;
            CoffeeRoast.FormattingEnabled = true;
            CoffeeRoast.Items.AddRange(new object[] { "Light Roast", "Medium Roast", "Dark Roast" });
            CoffeeRoast.Location = new Point(47, 193);
            CoffeeRoast.Name = "CoffeeRoast";
            CoffeeRoast.Size = new Size(308, 28);
            CoffeeRoast.TabIndex = 45;
            // 
            // CoffeeButton
            // 
            CoffeeButton.ForeColor = SystemColors.ActiveCaptionText;
            CoffeeButton.Location = new Point(212, 295);
            CoffeeButton.Name = "CoffeeButton";
            CoffeeButton.Size = new Size(250, 50);
            CoffeeButton.TabIndex = 23;
            CoffeeButton.Text = "Create";
            CoffeeButton.UseVisualStyleBackColor = true;
            CoffeeButton.Click += CoffeeButton_Click;
            // 
            // CoffeeData
            // 
            CoffeeData.BackgroundColor = SystemColors.ControlLight;
            CoffeeData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CoffeeData.Columns.AddRange(new DataGridViewColumn[] { BagSize, Price });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            CoffeeData.DefaultCellStyle = dataGridViewCellStyle1;
            CoffeeData.Location = new Point(361, 71);
            CoffeeData.Name = "CoffeeData";
            CoffeeData.RowHeadersWidth = 51;
            CoffeeData.Size = new Size(303, 210);
            CoffeeData.TabIndex = 39;
            // 
            // BagSize
            // 
            BagSize.HeaderText = "BagSize (oz)";
            BagSize.MinimumWidth = 6;
            BagSize.Name = "BagSize";
            BagSize.Width = 125;
            // 
            // Price
            // 
            Price.HeaderText = "Price ($)";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.Width = 125;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F);
            label22.Location = new Point(361, 40);
            label22.Name = "label22";
            label22.Size = new Size(174, 28);
            label22.TabIndex = 37;
            label22.Text = "Bag Size and Price:";
            // 
            // CoffeeFlavor
            // 
            CoffeeFlavor.Location = new Point(47, 254);
            CoffeeFlavor.Name = "CoffeeFlavor";
            CoffeeFlavor.Size = new Size(308, 27);
            CoffeeFlavor.TabIndex = 36;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F);
            label21.Location = new Point(17, 223);
            label21.Name = "label21";
            label21.Size = new Size(127, 28);
            label21.TabIndex = 35;
            label21.Text = "Flavor Notes:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F);
            label20.Location = new Point(17, 162);
            label20.Name = "label20";
            label20.Size = new Size(110, 28);
            label20.TabIndex = 33;
            label20.Text = "Roast Type:";
            // 
            // CoffeeOrigin
            // 
            CoffeeOrigin.Location = new Point(47, 132);
            CoffeeOrigin.Name = "CoffeeOrigin";
            CoffeeOrigin.Size = new Size(308, 27);
            CoffeeOrigin.TabIndex = 32;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F);
            label19.Location = new Point(17, 101);
            label19.Name = "label19";
            label19.Size = new Size(71, 28);
            label19.TabIndex = 31;
            label19.Text = "Origin:";
            // 
            // CoffeeName
            // 
            CoffeeName.Location = new Point(47, 71);
            CoffeeName.Name = "CoffeeName";
            CoffeeName.Size = new Size(308, 27);
            CoffeeName.TabIndex = 30;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F);
            label18.Location = new Point(17, 40);
            label18.Name = "label18";
            label18.Size = new Size(68, 28);
            label18.TabIndex = 29;
            label18.Text = "Name:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 17F);
            label12.ForeColor = SystemColors.Control;
            label12.Location = new Point(0, 0);
            label12.Name = "label12";
            label12.Size = new Size(233, 40);
            label12.TabIndex = 28;
            label12.Text = "New Coffee Type";
            // 
            // PricingPanel
            // 
            PricingPanel.BackColor = Color.CadetBlue;
            PricingPanel.Controls.Add(RuleValueTitle);
            PricingPanel.Controls.Add(RuleValue);
            PricingPanel.Controls.Add(RuleButton);
            PricingPanel.Controls.Add(RuleDuration);
            PricingPanel.Controls.Add(label32);
            PricingPanel.Controls.Add(RuleApply);
            PricingPanel.Controls.Add(RuleDiscount);
            PricingPanel.Controls.Add(label31);
            PricingPanel.Controls.Add(label30);
            PricingPanel.Controls.Add(label9);
            PricingPanel.Location = new Point(1228, 754);
            PricingPanel.Name = "PricingPanel";
            PricingPanel.Size = new Size(652, 355);
            PricingPanel.TabIndex = 29;
            // 
            // RuleValueTitle
            // 
            RuleValueTitle.AutoSize = true;
            RuleValueTitle.Font = new Font("Segoe UI", 12F);
            RuleValueTitle.Location = new Point(340, 36);
            RuleValueTitle.Name = "RuleValueTitle";
            RuleValueTitle.Size = new Size(68, 28);
            RuleValueTitle.TabIndex = 48;
            RuleValueTitle.Text = "Value?";
            // 
            // RuleValue
            // 
            RuleValue.Location = new Point(361, 66);
            RuleValue.Name = "RuleValue";
            RuleValue.Size = new Size(240, 27);
            RuleValue.TabIndex = 47;
            // 
            // RuleButton
            // 
            RuleButton.ForeColor = SystemColors.ActiveCaptionText;
            RuleButton.Location = new Point(212, 285);
            RuleButton.Name = "RuleButton";
            RuleButton.Size = new Size(250, 50);
            RuleButton.TabIndex = 40;
            RuleButton.Text = "Create";
            RuleButton.UseVisualStyleBackColor = true;
            RuleButton.Click += RuleButton_Click;
            // 
            // RuleDuration
            // 
            RuleDuration.Location = new Point(47, 189);
            RuleDuration.Name = "RuleDuration";
            RuleDuration.Size = new Size(554, 27);
            RuleDuration.TabIndex = 46;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI", 12F);
            label32.Location = new Point(17, 158);
            label32.Name = "label32";
            label32.Size = new Size(397, 28);
            label32.TabIndex = 45;
            label32.Text = "Duration (Days): Only type the number in int";
            // 
            // RuleApply
            // 
            RuleApply.BackColor = SystemColors.Window;
            RuleApply.DropDownStyle = ComboBoxStyle.DropDownList;
            RuleApply.FormattingEnabled = true;
            RuleApply.Items.AddRange(new object[] { "Apply to All Order", "BagSize", "Coffee", "Over Specific Price" });
            RuleApply.Location = new Point(47, 66);
            RuleApply.Name = "RuleApply";
            RuleApply.Size = new Size(240, 28);
            RuleApply.TabIndex = 44;
            RuleApply.SelectedIndexChanged += RuleApply_SelectedIndexChanged;
            // 
            // RuleDiscount
            // 
            RuleDiscount.Location = new Point(47, 128);
            RuleDiscount.Name = "RuleDiscount";
            RuleDiscount.Size = new Size(554, 27);
            RuleDiscount.TabIndex = 43;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 12F);
            label31.Location = new Point(17, 97);
            label31.Name = "label31";
            label31.Size = new Size(481, 28);
            label31.TabIndex = 42;
            label31.Text = "Discount Amount ($): Only type the number in double";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 12F);
            label30.Location = new Point(17, 40);
            label30.Name = "label30";
            label30.Size = new Size(144, 28);
            label30.TabIndex = 40;
            label30.Text = "Apply to what?";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 17F);
            label9.ForeColor = SystemColors.Control;
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(166, 40);
            label9.TabIndex = 28;
            label9.Text = "Pricing Rule";
            // 
            // OrderPanel
            // 
            OrderPanel.BackColor = Color.CadetBlue;
            OrderPanel.Controls.Add(RatePanel);
            OrderPanel.Controls.Add(label17);
            OrderPanel.Controls.Add(OrderDescription);
            OrderPanel.Controls.Add(OrderButton);
            OrderPanel.Controls.Add(label3);
            OrderPanel.Location = new Point(14, 754);
            OrderPanel.Name = "OrderPanel";
            OrderPanel.Size = new Size(686, 355);
            OrderPanel.TabIndex = 29;
            // 
            // RatePanel
            // 
            RatePanel.BackColor = Color.CadetBlue;
            RatePanel.Controls.Add(RateButton);
            RatePanel.Controls.Add(label25);
            RatePanel.Controls.Add(label24);
            RatePanel.Controls.Add(label23);
            RatePanel.Controls.Add(RateFeedback);
            RatePanel.Controls.Add(RateRate);
            RatePanel.Controls.Add(label2);
            RatePanel.Location = new Point(0, 0);
            RatePanel.Name = "RatePanel";
            RatePanel.Size = new Size(686, 358);
            RatePanel.TabIndex = 46;
            // 
            // RateButton
            // 
            RateButton.ForeColor = SystemColors.ActiveCaptionText;
            RateButton.Location = new Point(222, 247);
            RateButton.Name = "RateButton";
            RateButton.Size = new Size(250, 50);
            RateButton.TabIndex = 42;
            RateButton.Text = "Rate:";
            RateButton.UseVisualStyleBackColor = true;
            RateButton.Click += RateButton_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F);
            label25.ForeColor = SystemColors.Control;
            label25.Location = new Point(32, 165);
            label25.Name = "label25";
            label25.Size = new Size(181, 28);
            label25.TabIndex = 35;
            label25.Text = "Feedback: Optional";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F);
            label24.ForeColor = SystemColors.Control;
            label24.Location = new Point(32, 100);
            label24.Name = "label24";
            label24.Size = new Size(112, 28);
            label24.TabIndex = 34;
            label24.Text = "Rate (1 - 5):";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 12F);
            label23.ForeColor = Color.Brown;
            label23.Location = new Point(32, 43);
            label23.Name = "label23";
            label23.Size = new Size(385, 28);
            label23.TabIndex = 33;
            label23.Text = "*Assume that the order has been delivered.";
            // 
            // RateFeedback
            // 
            RateFeedback.Location = new Point(55, 196);
            RateFeedback.Name = "RateFeedback";
            RateFeedback.Size = new Size(574, 27);
            RateFeedback.TabIndex = 31;
            // 
            // RateRate
            // 
            RateRate.Location = new Point(55, 135);
            RateRate.Name = "RateRate";
            RateRate.Size = new Size(574, 27);
            RateRate.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 17F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(211, 40);
            label2.TabIndex = 29;
            label2.Text = "Rate the Order:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F);
            label17.ForeColor = SystemColors.Control;
            label17.Location = new Point(21, 51);
            label17.Name = "label17";
            label17.Size = new Size(196, 28);
            label17.TabIndex = 45;
            label17.Text = "Current Subscription:";
            // 
            // OrderDescription
            // 
            OrderDescription.Location = new Point(55, 82);
            OrderDescription.Multiline = true;
            OrderDescription.Name = "OrderDescription";
            OrderDescription.ReadOnly = true;
            OrderDescription.ScrollBars = ScrollBars.Vertical;
            OrderDescription.Size = new Size(579, 141);
            OrderDescription.TabIndex = 19;
            OrderDescription.Text = "Chosen Subscription:\r\n- Coffee:\r\n- Bag Size:\r\n- Price:\r\n- Price after discount if applicable:";
            // 
            // OrderButton
            // 
            OrderButton.ForeColor = SystemColors.ActiveCaptionText;
            OrderButton.Location = new Point(222, 285);
            OrderButton.Name = "OrderButton";
            OrderButton.Size = new Size(250, 50);
            OrderButton.TabIndex = 41;
            OrderButton.Text = "Order";
            OrderButton.UseVisualStyleBackColor = true;
            OrderButton.Click += OrderButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 17F);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 40);
            label3.TabIndex = 28;
            label3.Text = "Order:";
            // 
            // SubscriptionPanel
            // 
            SubscriptionPanel.BackColor = Color.CadetBlue;
            SubscriptionPanel.Controls.Add(SubscriptionAssume);
            SubscriptionPanel.Controls.Add(SubscriptionCoffee);
            SubscriptionPanel.Controls.Add(SubscriptionCoffeeTitle);
            SubscriptionPanel.Controls.Add(SubscriptionStrategyButton);
            SubscriptionPanel.Controls.Add(SubscriptionButton);
            SubscriptionPanel.Controls.Add(SubscriptionStartDate);
            SubscriptionPanel.Controls.Add(SubscriptionDelivery);
            SubscriptionPanel.Controls.Add(SubscriptionStartDateTitle);
            SubscriptionPanel.Controls.Add(SubscriptionDeleveryTitle);
            SubscriptionPanel.Controls.Add(SubscriptionBag);
            SubscriptionPanel.Controls.Add(SubscriptionBagTitle);
            SubscriptionPanel.Controls.Add(SubscriptionStrategy);
            SubscriptionPanel.Controls.Add(SubscriptionStrategyTitle);
            SubscriptionPanel.Controls.Add(label1);
            SubscriptionPanel.Location = new Point(14, 380);
            SubscriptionPanel.Name = "SubscriptionPanel";
            SubscriptionPanel.Size = new Size(686, 355);
            SubscriptionPanel.TabIndex = 29;
            // 
            // SubscriptionAssume
            // 
            SubscriptionAssume.AutoSize = true;
            SubscriptionAssume.Font = new Font("Segoe UI", 7F);
            SubscriptionAssume.ForeColor = Color.Brown;
            SubscriptionAssume.Location = new Point(180, 0);
            SubscriptionAssume.Name = "SubscriptionAssume";
            SubscriptionAssume.Size = new Size(434, 45);
            SubscriptionAssume.TabIndex = 45;
            SubscriptionAssume.Text = resources.GetString("SubscriptionAssume.Text");
            // 
            // SubscriptionCoffee
            // 
            SubscriptionCoffee.BackColor = SystemColors.Window;
            SubscriptionCoffee.DropDownStyle = ComboBoxStyle.DropDownList;
            SubscriptionCoffee.FormattingEnabled = true;
            SubscriptionCoffee.Items.AddRange(new object[] { "Manual Selection", "Recommendation-based selection", "Mix of the two" });
            SubscriptionCoffee.Location = new Point(55, 132);
            SubscriptionCoffee.Name = "SubscriptionCoffee";
            SubscriptionCoffee.Size = new Size(579, 28);
            SubscriptionCoffee.TabIndex = 44;
            SubscriptionCoffee.SelectedIndexChanged += SubscriptionCoffee_SelectedIndexChanged;
            // 
            // SubscriptionCoffeeTitle
            // 
            SubscriptionCoffeeTitle.AutoSize = true;
            SubscriptionCoffeeTitle.Font = new Font("Segoe UI", 12F);
            SubscriptionCoffeeTitle.ForeColor = SystemColors.Control;
            SubscriptionCoffeeTitle.Location = new Point(18, 101);
            SubscriptionCoffeeTitle.Name = "SubscriptionCoffeeTitle";
            SubscriptionCoffeeTitle.Size = new Size(142, 28);
            SubscriptionCoffeeTitle.TabIndex = 43;
            SubscriptionCoffeeTitle.Text = "Choose Coffee:";
            // 
            // SubscriptionStrategyButton
            // 
            SubscriptionStrategyButton.ForeColor = SystemColors.ActiveCaptionText;
            SubscriptionStrategyButton.Location = new Point(399, 53);
            SubscriptionStrategyButton.Name = "SubscriptionStrategyButton";
            SubscriptionStrategyButton.Size = new Size(250, 50);
            SubscriptionStrategyButton.TabIndex = 42;
            SubscriptionStrategyButton.Text = "Select";
            SubscriptionStrategyButton.UseVisualStyleBackColor = true;
            SubscriptionStrategyButton.Click += SubscriptionStrategyButton_Click;
            // 
            // SubscriptionButton
            // 
            SubscriptionButton.ForeColor = SystemColors.ActiveCaptionText;
            SubscriptionButton.Location = new Point(222, 295);
            SubscriptionButton.Name = "SubscriptionButton";
            SubscriptionButton.Size = new Size(250, 50);
            SubscriptionButton.TabIndex = 41;
            SubscriptionButton.Text = "Update";
            SubscriptionButton.UseVisualStyleBackColor = true;
            SubscriptionButton.Click += SubscriptionButton_Click;
            // 
            // SubscriptionStartDate
            // 
            SubscriptionStartDate.Location = new Point(56, 254);
            SubscriptionStartDate.Name = "SubscriptionStartDate";
            SubscriptionStartDate.Size = new Size(241, 27);
            SubscriptionStartDate.TabIndex = 24;
            // 
            // SubscriptionDelivery
            // 
            SubscriptionDelivery.BackColor = SystemColors.Window;
            SubscriptionDelivery.DropDownStyle = ComboBoxStyle.DropDownList;
            SubscriptionDelivery.FormattingEnabled = true;
            SubscriptionDelivery.Items.AddRange(new object[] { "Weekly", "Bi-Weekly", "Monthly" });
            SubscriptionDelivery.Location = new Point(399, 254);
            SubscriptionDelivery.Name = "SubscriptionDelivery";
            SubscriptionDelivery.Size = new Size(236, 28);
            SubscriptionDelivery.TabIndex = 36;
            // 
            // SubscriptionStartDateTitle
            // 
            SubscriptionStartDateTitle.AutoSize = true;
            SubscriptionStartDateTitle.Font = new Font("Segoe UI", 12F);
            SubscriptionStartDateTitle.ForeColor = SystemColors.Control;
            SubscriptionStartDateTitle.Location = new Point(19, 223);
            SubscriptionStartDateTitle.Name = "SubscriptionStartDateTitle";
            SubscriptionStartDateTitle.Size = new Size(103, 28);
            SubscriptionStartDateTitle.TabIndex = 23;
            SubscriptionStartDateTitle.Text = "Start Date:";
            // 
            // SubscriptionDeleveryTitle
            // 
            SubscriptionDeleveryTitle.AutoSize = true;
            SubscriptionDeleveryTitle.Font = new Font("Segoe UI", 12F);
            SubscriptionDeleveryTitle.ForeColor = SystemColors.Control;
            SubscriptionDeleveryTitle.Location = new Point(352, 223);
            SubscriptionDeleveryTitle.Name = "SubscriptionDeleveryTitle";
            SubscriptionDeleveryTitle.Size = new Size(187, 28);
            SubscriptionDeleveryTitle.TabIndex = 35;
            SubscriptionDeleveryTitle.Text = "Delevery Frequency:";
            // 
            // SubscriptionBag
            // 
            SubscriptionBag.BackColor = SystemColors.Window;
            SubscriptionBag.DropDownStyle = ComboBoxStyle.DropDownList;
            SubscriptionBag.FormattingEnabled = true;
            SubscriptionBag.Location = new Point(56, 192);
            SubscriptionBag.Name = "SubscriptionBag";
            SubscriptionBag.Size = new Size(579, 28);
            SubscriptionBag.TabIndex = 34;
            // 
            // SubscriptionBagTitle
            // 
            SubscriptionBagTitle.AutoSize = true;
            SubscriptionBagTitle.Font = new Font("Segoe UI", 12F);
            SubscriptionBagTitle.ForeColor = SystemColors.Control;
            SubscriptionBagTitle.Location = new Point(21, 161);
            SubscriptionBagTitle.Name = "SubscriptionBagTitle";
            SubscriptionBagTitle.Size = new Size(198, 28);
            SubscriptionBagTitle.TabIndex = 33;
            SubscriptionBagTitle.Text = "Bag Size Per Delevery";
            // 
            // SubscriptionStrategy
            // 
            SubscriptionStrategy.BackColor = SystemColors.Window;
            SubscriptionStrategy.DropDownStyle = ComboBoxStyle.DropDownList;
            SubscriptionStrategy.FormattingEnabled = true;
            SubscriptionStrategy.Items.AddRange(new object[] { "Manual Selection", "Recommendation-based selection", "Mix of the two" });
            SubscriptionStrategy.Location = new Point(61, 71);
            SubscriptionStrategy.Name = "SubscriptionStrategy";
            SubscriptionStrategy.Size = new Size(332, 28);
            SubscriptionStrategy.TabIndex = 32;
            // 
            // SubscriptionStrategyTitle
            // 
            SubscriptionStrategyTitle.AutoSize = true;
            SubscriptionStrategyTitle.Font = new Font("Segoe UI", 12F);
            SubscriptionStrategyTitle.ForeColor = SystemColors.Control;
            SubscriptionStrategyTitle.Location = new Point(18, 40);
            SubscriptionStrategyTitle.Name = "SubscriptionStrategyTitle";
            SubscriptionStrategyTitle.Size = new Size(235, 28);
            SubscriptionStrategyTitle.TabIndex = 32;
            SubscriptionStrategyTitle.Text = "Coffee Selection Strategy:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 40);
            label1.TabIndex = 28;
            label1.Text = "Subscription";
            // 
            // TasteProfilePanel
            // 
            TasteProfilePanel.BackColor = Color.CadetBlue;
            TasteProfilePanel.Controls.Add(TasteProfileDisplay);
            TasteProfilePanel.Controls.Add(TasteProfileFalvor);
            TasteProfilePanel.Controls.Add(TasteProfileButton);
            TasteProfilePanel.Controls.Add(TasteProfileStrength);
            TasteProfilePanel.Controls.Add(TasteProfileStrengthTitle);
            TasteProfilePanel.Controls.Add(TasteProfileRoast);
            TasteProfilePanel.Controls.Add(TasteProfileRoastTitle);
            TasteProfilePanel.Controls.Add(TasteProfileFlavorTitle);
            TasteProfilePanel.Controls.Add(TasteProfileTitle);
            TasteProfilePanel.Location = new Point(14, 6);
            TasteProfilePanel.Name = "TasteProfilePanel";
            TasteProfilePanel.Size = new Size(686, 355);
            TasteProfilePanel.TabIndex = 20;
            // 
            // TasteProfileDisplay
            // 
            TasteProfileDisplay.Location = new Point(169, 6);
            TasteProfileDisplay.Multiline = true;
            TasteProfileDisplay.Name = "TasteProfileDisplay";
            TasteProfileDisplay.ReadOnly = true;
            TasteProfileDisplay.ScrollBars = ScrollBars.Vertical;
            TasteProfileDisplay.Size = new Size(495, 88);
            TasteProfileDisplay.TabIndex = 29;
            TasteProfileDisplay.Text = "Your Current TasteProfile:\r\n";
            // 
            // TasteProfileFalvor
            // 
            TasteProfileFalvor.Location = new Point(61, 132);
            TasteProfileFalvor.Name = "TasteProfileFalvor";
            TasteProfileFalvor.Size = new Size(574, 27);
            TasteProfileFalvor.TabIndex = 28;
            // 
            // TasteProfileButton
            // 
            TasteProfileButton.ForeColor = SystemColors.ActiveCaptionText;
            TasteProfileButton.Location = new Point(222, 297);
            TasteProfileButton.Name = "TasteProfileButton";
            TasteProfileButton.Size = new Size(250, 50);
            TasteProfileButton.TabIndex = 28;
            TasteProfileButton.Text = "Update";
            TasteProfileButton.UseVisualStyleBackColor = true;
            TasteProfileButton.Click += TasteProfileButton_Click;
            // 
            // TasteProfileStrength
            // 
            TasteProfileStrength.BackColor = SystemColors.Window;
            TasteProfileStrength.DropDownStyle = ComboBoxStyle.DropDownList;
            TasteProfileStrength.FormattingEnabled = true;
            TasteProfileStrength.Items.AddRange(new object[] { "Mild Strength", "Medium Strength", "Strong Strength" });
            TasteProfileStrength.Location = new Point(61, 251);
            TasteProfileStrength.Name = "TasteProfileStrength";
            TasteProfileStrength.Size = new Size(574, 28);
            TasteProfileStrength.TabIndex = 31;
            // 
            // TasteProfileStrengthTitle
            // 
            TasteProfileStrengthTitle.AutoSize = true;
            TasteProfileStrengthTitle.Font = new Font("Segoe UI", 12F);
            TasteProfileStrengthTitle.ForeColor = SystemColors.Control;
            TasteProfileStrengthTitle.Location = new Point(18, 220);
            TasteProfileStrengthTitle.Name = "TasteProfileStrengthTitle";
            TasteProfileStrengthTitle.Size = new Size(91, 28);
            TasteProfileStrengthTitle.TabIndex = 30;
            TasteProfileStrengthTitle.Text = "Strength:";
            // 
            // TasteProfileRoast
            // 
            TasteProfileRoast.BackColor = SystemColors.Window;
            TasteProfileRoast.DropDownStyle = ComboBoxStyle.DropDownList;
            TasteProfileRoast.FormattingEnabled = true;
            TasteProfileRoast.Items.AddRange(new object[] { "Light Roast", "Medium Roast", "Dark Roast" });
            TasteProfileRoast.Location = new Point(61, 193);
            TasteProfileRoast.Name = "TasteProfileRoast";
            TasteProfileRoast.Size = new Size(574, 28);
            TasteProfileRoast.TabIndex = 30;
            // 
            // TasteProfileRoastTitle
            // 
            TasteProfileRoastTitle.AutoSize = true;
            TasteProfileRoastTitle.Font = new Font("Segoe UI", 12F);
            TasteProfileRoastTitle.ForeColor = SystemColors.Control;
            TasteProfileRoastTitle.Location = new Point(18, 162);
            TasteProfileRoastTitle.Name = "TasteProfileRoastTitle";
            TasteProfileRoastTitle.Size = new Size(64, 28);
            TasteProfileRoastTitle.TabIndex = 29;
            TasteProfileRoastTitle.Text = "Roast:";
            // 
            // TasteProfileFlavorTitle
            // 
            TasteProfileFlavorTitle.AutoSize = true;
            TasteProfileFlavorTitle.Font = new Font("Segoe UI", 12F);
            TasteProfileFlavorTitle.ForeColor = SystemColors.Control;
            TasteProfileFlavorTitle.Location = new Point(18, 100);
            TasteProfileFlavorTitle.Name = "TasteProfileFlavorTitle";
            TasteProfileFlavorTitle.Size = new Size(127, 28);
            TasteProfileFlavorTitle.TabIndex = 28;
            TasteProfileFlavorTitle.Text = "Flavor Notes:";
            // 
            // TasteProfileTitle
            // 
            TasteProfileTitle.AutoSize = true;
            TasteProfileTitle.Font = new Font("Segoe UI", 17F);
            TasteProfileTitle.ForeColor = SystemColors.Control;
            TasteProfileTitle.Location = new Point(0, 0);
            TasteProfileTitle.Name = "TasteProfileTitle";
            TasteProfileTitle.Size = new Size(170, 40);
            TasteProfileTitle.TabIndex = 28;
            TasteProfileTitle.Text = "Taste Profile";
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = Color.CadetBlue;
            LoginPanel.Controls.Add(LoginPassword);
            LoginPanel.Controls.Add(Login);
            LoginPanel.Controls.Add(LoginPanelTitle);
            LoginPanel.Controls.Add(LoginUsername);
            LoginPanel.Controls.Add(LoginPasswordTitle);
            LoginPanel.Controls.Add(LoginUsernameTitle);
            LoginPanel.ForeColor = SystemColors.ControlLightLight;
            LoginPanel.Location = new Point(720, 6);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(491, 248);
            LoginPanel.TabIndex = 17;
            // 
            // LoginPassword
            // 
            LoginPassword.Location = new Point(47, 136);
            LoginPassword.Name = "LoginPassword";
            LoginPassword.Size = new Size(400, 27);
            LoginPassword.TabIndex = 27;
            // 
            // Login
            // 
            Login.ForeColor = SystemColors.ActiveCaptionText;
            Login.Location = new Point(123, 169);
            Login.Name = "Login";
            Login.Size = new Size(250, 50);
            Login.TabIndex = 23;
            Login.Text = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // LoginPanelTitle
            // 
            LoginPanelTitle.AutoSize = true;
            LoginPanelTitle.Font = new Font("Segoe UI", 17F);
            LoginPanelTitle.Location = new Point(3, 0);
            LoginPanelTitle.Name = "LoginPanelTitle";
            LoginPanelTitle.Size = new Size(102, 40);
            LoginPanelTitle.TabIndex = 6;
            LoginPanelTitle.Text = "Log in:";
            // 
            // LoginUsername
            // 
            LoginUsername.Location = new Point(47, 80);
            LoginUsername.Name = "LoginUsername";
            LoginUsername.Size = new Size(400, 27);
            LoginUsername.TabIndex = 26;
            // 
            // LoginPasswordTitle
            // 
            LoginPasswordTitle.AutoSize = true;
            LoginPasswordTitle.Font = new Font("Segoe UI", 12F);
            LoginPasswordTitle.Location = new Point(10, 105);
            LoginPasswordTitle.Name = "LoginPasswordTitle";
            LoginPasswordTitle.Size = new Size(97, 28);
            LoginPasswordTitle.TabIndex = 24;
            LoginPasswordTitle.Text = "Password:";
            // 
            // LoginUsernameTitle
            // 
            LoginUsernameTitle.AutoSize = true;
            LoginUsernameTitle.Font = new Font("Segoe UI", 12F);
            LoginUsernameTitle.Location = new Point(10, 49);
            LoginUsernameTitle.Name = "LoginUsernameTitle";
            LoginUsernameTitle.Size = new Size(103, 28);
            LoginUsernameTitle.TabIndex = 23;
            LoginUsernameTitle.Text = "Username:";
            // 
            // RegisterPanel
            // 
            RegisterPanel.BackColor = Color.CadetBlue;
            RegisterPanel.Controls.Add(RecommendationPanel);
            RegisterPanel.Controls.Add(RegisterType);
            RegisterPanel.Controls.Add(RegisterDate);
            RegisterPanel.Controls.Add(RegisterPasswordText);
            RegisterPanel.Controls.Add(RegisterEmailText);
            RegisterPanel.Controls.Add(RegisterNameText);
            RegisterPanel.Controls.Add(RegisterPaymentText);
            RegisterPanel.Controls.Add(Register);
            RegisterPanel.Controls.Add(label11);
            RegisterPanel.Controls.Add(RegisterAs);
            RegisterPanel.Controls.Add(RegisterAddressText);
            RegisterPanel.Controls.Add(NameTitle);
            RegisterPanel.Controls.Add(label4);
            RegisterPanel.Controls.Add(label7);
            RegisterPanel.Controls.Add(label5);
            RegisterPanel.Controls.Add(label6);
            RegisterPanel.ForeColor = SystemColors.Control;
            RegisterPanel.Location = new Point(720, 264);
            RegisterPanel.Name = "RegisterPanel";
            RegisterPanel.Size = new Size(491, 471);
            RegisterPanel.TabIndex = 18;
            // 
            // RecommendationPanel
            // 
            RecommendationPanel.BackColor = Color.CadetBlue;
            RecommendationPanel.Controls.Add(label14);
            RecommendationPanel.Controls.Add(RecommendationDescription);
            RecommendationPanel.Controls.Add(RecommendationButton);
            RecommendationPanel.Controls.Add(label16);
            RecommendationPanel.ForeColor = SystemColors.Control;
            RecommendationPanel.Location = new Point(0, 0);
            RecommendationPanel.Name = "RecommendationPanel";
            RecommendationPanel.Size = new Size(491, 471);
            RecommendationPanel.TabIndex = 24;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.ForeColor = Color.Brown;
            label14.Location = new Point(31, 47);
            label14.Name = "label14";
            label14.Size = new Size(361, 46);
            label14.TabIndex = 34;
            label14.Text = "* This doesn't work since direction said to not \r\nimplement.";
            // 
            // RecommendationDescription
            // 
            RecommendationDescription.Location = new Point(47, 93);
            RecommendationDescription.Multiline = true;
            RecommendationDescription.Name = "RecommendationDescription";
            RecommendationDescription.ReadOnly = true;
            RecommendationDescription.ScrollBars = ScrollBars.Vertical;
            RecommendationDescription.Size = new Size(400, 312);
            RecommendationDescription.TabIndex = 20;
            RecommendationDescription.Text = resources.GetString("RecommendationDescription.Text");
            // 
            // RecommendationButton
            // 
            RecommendationButton.ForeColor = SystemColors.ActiveCaptionText;
            RecommendationButton.Location = new Point(123, 411);
            RecommendationButton.Name = "RecommendationButton";
            RecommendationButton.Size = new Size(250, 50);
            RecommendationButton.TabIndex = 3;
            RecommendationButton.Text = "Generate";
            RecommendationButton.UseVisualStyleBackColor = true;
            RecommendationButton.Click += RecommendationButton_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 17F);
            label16.Location = new Point(0, 0);
            label16.Name = "label16";
            label16.Size = new Size(437, 40);
            label16.TabIndex = 7;
            label16.Text = "Weekly Coffee Recommendation:";
            // 
            // RegisterType
            // 
            RegisterType.BackColor = SystemColors.Window;
            RegisterType.DropDownStyle = ComboBoxStyle.DropDownList;
            RegisterType.FormattingEnabled = true;
            RegisterType.Items.AddRange(new object[] { "Customer", "Supplier", "Subscription Manager", "System Administrator" });
            RegisterType.Location = new Point(197, 12);
            RegisterType.Name = "RegisterType";
            RegisterType.Size = new Size(183, 28);
            RegisterType.TabIndex = 22;
            // 
            // RegisterDate
            // 
            RegisterDate.Location = new Point(47, 139);
            RegisterDate.Name = "RegisterDate";
            RegisterDate.Size = new Size(400, 27);
            RegisterDate.TabIndex = 21;
            // 
            // RegisterPasswordText
            // 
            RegisterPasswordText.Location = new Point(47, 256);
            RegisterPasswordText.Name = "RegisterPasswordText";
            RegisterPasswordText.Size = new Size(400, 27);
            RegisterPasswordText.TabIndex = 20;
            // 
            // RegisterEmailText
            // 
            RegisterEmailText.Location = new Point(47, 200);
            RegisterEmailText.Name = "RegisterEmailText";
            RegisterEmailText.Size = new Size(400, 27);
            RegisterEmailText.TabIndex = 20;
            // 
            // RegisterNameText
            // 
            RegisterNameText.Location = new Point(47, 78);
            RegisterNameText.Name = "RegisterNameText";
            RegisterNameText.Size = new Size(400, 27);
            RegisterNameText.TabIndex = 7;
            // 
            // RegisterPaymentText
            // 
            RegisterPaymentText.Location = new Point(47, 378);
            RegisterPaymentText.Name = "RegisterPaymentText";
            RegisterPaymentText.Size = new Size(400, 27);
            RegisterPaymentText.TabIndex = 18;
            // 
            // Register
            // 
            Register.ForeColor = SystemColors.ActiveCaptionText;
            Register.Location = new Point(123, 411);
            Register.Name = "Register";
            Register.Size = new Size(250, 50);
            Register.TabIndex = 3;
            Register.Text = "Register";
            Register.UseVisualStyleBackColor = true;
            Register.Click += Register_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(11, 347);
            label11.Name = "label11";
            label11.Size = new Size(162, 28);
            label11.TabIndex = 17;
            label11.Text = "Payment Method";
            // 
            // RegisterAs
            // 
            RegisterAs.AutoSize = true;
            RegisterAs.Font = new Font("Segoe UI", 17F);
            RegisterAs.Location = new Point(5, 0);
            RegisterAs.Name = "RegisterAs";
            RegisterAs.Size = new Size(164, 40);
            RegisterAs.TabIndex = 7;
            RegisterAs.Text = "Register As:";
            // 
            // RegisterAddressText
            // 
            RegisterAddressText.Location = new Point(47, 317);
            RegisterAddressText.Name = "RegisterAddressText";
            RegisterAddressText.Size = new Size(400, 27);
            RegisterAddressText.TabIndex = 16;
            // 
            // NameTitle
            // 
            NameTitle.AutoSize = true;
            NameTitle.Font = new Font("Segoe UI", 12F);
            NameTitle.Location = new Point(10, 47);
            NameTitle.Name = "NameTitle";
            NameTitle.Size = new Size(363, 28);
            NameTitle.TabIndex = 7;
            NameTitle.Text = "Name (UserName, No duplicated name):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(10, 108);
            label4.Name = "label4";
            label4.Size = new Size(126, 28);
            label4.TabIndex = 8;
            label4.Text = "Date of Birth:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(10, 286);
            label7.Name = "label7";
            label7.Size = new Size(166, 28);
            label7.TabIndex = 14;
            label7.Text = "Shipping Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(10, 169);
            label5.Name = "label5";
            label5.Size = new Size(138, 28);
            label5.TabIndex = 12;
            label5.Text = "Email Address:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(10, 225);
            label6.Name = "label6";
            label6.Size = new Size(97, 28);
            label6.TabIndex = 13;
            label6.Text = "Password:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.CadetBlue;
            panel5.Controls.Add(label15);
            panel5.Controls.Add(BrowseCoffeeText);
            panel5.Controls.Add(label10);
            panel5.ForeColor = SystemColors.Control;
            panel5.Location = new Point(720, 751);
            panel5.Name = "panel5";
            panel5.Size = new Size(491, 358);
            panel5.TabIndex = 19;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F);
            label15.ForeColor = Color.Brown;
            label15.Location = new Point(3, 38);
            label15.Name = "label15";
            label15.Size = new Size(488, 46);
            label15.TabIndex = 34;
            label15.Text = "*Assuming this will automatically update when coffee is added.\r\nAlso since it's guest feature, every user is able to access it.";
            // 
            // BrowseCoffeeText
            // 
            BrowseCoffeeText.Location = new Point(47, 87);
            BrowseCoffeeText.Multiline = true;
            BrowseCoffeeText.Name = "BrowseCoffeeText";
            BrowseCoffeeText.ReadOnly = true;
            BrowseCoffeeText.ScrollBars = ScrollBars.Vertical;
            BrowseCoffeeText.Size = new Size(400, 251);
            BrowseCoffeeText.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 17F);
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(329, 40);
            label10.TabIndex = 17;
            label10.Text = "Browse Available Coffee:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1916, 1175);
            Controls.Add(panel3);
            Name = "Form1";
            Text = "Form1";
            panel3.ResumeLayout(false);
            LogoutPanel.ResumeLayout(false);
            LogoutPanel.PerformLayout();
            HistoryPanel.ResumeLayout(false);
            HistoryPanel.PerformLayout();
            CoffeePanel.ResumeLayout(false);
            CoffeePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CoffeeData).EndInit();
            PricingPanel.ResumeLayout(false);
            PricingPanel.PerformLayout();
            OrderPanel.ResumeLayout(false);
            OrderPanel.PerformLayout();
            RatePanel.ResumeLayout(false);
            RatePanel.PerformLayout();
            SubscriptionPanel.ResumeLayout(false);
            SubscriptionPanel.PerformLayout();
            TasteProfilePanel.ResumeLayout(false);
            TasteProfilePanel.PerformLayout();
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            RegisterPanel.ResumeLayout(false);
            RegisterPanel.PerformLayout();
            RecommendationPanel.ResumeLayout(false);
            RecommendationPanel.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private TextBox CoffeeOrigin;
        private TextBox CoffeeName;
        private TextBox CoffeeFlavor;
        private DateTimePicker SubscriptionStartDate;
        private Button TasteProfileButton;
        private Panel HistoryPanel;
        private Label label13;
        private Panel CoffeePanel;
        private Label label12;
        private Panel PricingPanel;
        private Label label9;
        private Panel OrderPanel;
        private Label label3;
        private Panel SubscriptionPanel;
        private Label label1;
        private Panel TasteProfilePanel;
        private Label TasteProfileTitle;
        private Panel LoginPanel;
        private TextBox LoginPassword;
        private Button Login;
        private Label LoginPanelTitle;
        private TextBox LoginUsername;
        private Label LoginPasswordTitle;
        private Label LoginUsernameTitle;
        private Panel RegisterPanel;
        private ComboBox RegisterType;
        private DateTimePicker RegisterDate;
        private TextBox RegisterPasswordText;
        private TextBox RegisterEmailText;
        private TextBox RegisterNameText;
        private TextBox RegisterPaymentText;
        private Button Register;
        private Label label11;
        private Label RegisterAs;
        private TextBox RegisterAddressText;
        private Label NameTitle;
        private Label label4;
        private Label label7;
        private Label label5;
        private Label label6;
        private Panel panel5;
        private TextBox BrowseCoffeeText;
        private Label label10;
        private TextBox ActivityHistoryDisplay;
        private Label TasteProfileFlavorTitle;
        private Label TasteProfileStrengthTitle;
        private ComboBox TasteProfileRoast;
        private Label TasteProfileRoastTitle;
        private Label label18;
        private Label SubscriptionStrategyTitle;
        private DataGridView CoffeeData;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private DataGridViewTextBoxColumn BagSize;
        private DataGridViewTextBoxColumn Price;
        private Button CoffeeButton;
        private ComboBox TasteProfileStrength;
        private TextBox TasteProfileFalvor;
        private TextBox TasteProfileDisplay;
        private ComboBox SubscriptionDelivery;
        private Label SubscriptionStartDateTitle;
        private Label SubscriptionDeleveryTitle;
        private ComboBox SubscriptionBag;
        private Label SubscriptionBagTitle;
        private Button OrderButton;
        private Label label30;
        private ComboBox RuleApply;
        private TextBox RuleDiscount;
        private Label label31;
        private Button RuleButton;
        private TextBox RuleDuration;
        private Label label32;
        private TextBox OrderDescription;
        private Button SubscriptionButton;
        private ComboBox CoffeeRoast;
        private Label CoffeeWarning;
        private Button LogoutButton;
        private Panel LogoutPanel;
        private Label label8;
        private Panel RecommendationPanel;
        private Button RecommendationButton;
        private Label label16;
        private Label RuleValueTitle;
        private TextBox RuleValue;
        private Button SubscriptionStrategyButton;
        private ComboBox SubscriptionStrategy;
        private ComboBox SubscriptionCoffee;
        private Label SubscriptionCoffeeTitle;
        private Label label17;
        private Panel RatePanel;
        private Label label25;
        private Label label24;
        private Label label23;
        private TextBox RateFeedback;
        private TextBox RateRate;
        private Label label2;
        private Button RateButton;
        private TextBox RecommendationDescription;
        private Label label14;
        private Label label15;
        private Label SubscriptionAssume;
    }
}
