// <copyright file="Coffee.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores information about the coffee.
    /// </summary>
    public class Coffee
    {
        /// <summary>
        /// Stores the name of the coffee.
        /// </summary>
        protected string? name;

        /// <summary>
        /// Stores the origin of the coffee.
        /// </summary>
        protected string? origin;

        /// <summary>
        /// Stores the roast type of the coffee.
        /// </summary>
        protected string? roastType;

        /// <summary>
        /// Stores the flavor notes of the coffee.
        /// </summary>
        protected string? flavorNotes;

        /// <summary>
        /// Stores all the size and the price for this coffee.
        /// </summary>
        protected List<BagSizes> bagSizes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coffee"/> class.
        /// Initializes the new coffee with name, origin, roast type, and flavor notes. As well as all the bag size and their price.
        /// </summary>
        /// <param name="newName"> The name of the coffee.</param>
        /// <param name="newOrigin"> The origin of the coffee.</param>
        /// <param name="newRoastType"> The roast type of the coffee.</param>
        /// <param name="newFlavorNotes"> The flavor notes of the coffee.</param>
        /// <param name="newBagSizes"> List of all bag sizes abd price of the coffee.</param>
        public Coffee(string? newName, string? newOrigin, string newRoastType, string? newFlavorNotes, List<BagSizes> newBagSizes)
        {
            this.name = newName;
            this.origin = newOrigin;
            this.roastType = newRoastType;
            this.flavorNotes = newFlavorNotes;
            this.bagSizes = newBagSizes;
        }

        /// <summary>
        /// Gets or sets and sets the name of the coffee.
        /// </summary>
        public string? Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the origin of the coffee.
        /// </summary>
        public string? Origin
        {
            get => this.origin;
            set
            {
                this.origin = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the roast type of the coffee.
        /// </summary>
        public string? RoastType
        {
            get => this.roastType;
            set
            {
                this.roastType = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the flavor notes of the coffee.
        /// </summary>
        public string? FlavorNotes
        {
            get => this.flavorNotes;
            set
            {
                this.flavorNotes = value;
            }
        }

        /// <summary>
        /// Gets or sets and sets the bagsize list of the coffee.
        /// </summary>
        public List<BagSizes> BagSizes
        {
            get => this.bagSizes;
            set
            {
                this.bagSizes = value;
            }
        }
    }
}
