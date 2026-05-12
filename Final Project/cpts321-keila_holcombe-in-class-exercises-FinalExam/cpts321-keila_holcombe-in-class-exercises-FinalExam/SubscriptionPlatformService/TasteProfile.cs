// <copyright file="TasteProfile.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// A taste profile that will capture user's coffee preference.
    /// </summary>
    public class TasteProfile
    {
        /// <summary>
        /// Stores the user's preferred coffee flavor.
        /// </summary>
        protected string flavor;

        /// <summary>
        /// Stores the user's preferred type of coffee roast.
        /// </summary>
        protected string roast;

        /// <summary>
        /// Stores the user's preferred coffee strength.
        /// </summary>
        protected string strength;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasteProfile"/> class.
        /// Initializes the TasteProfile with the information of coffee flavor, roast, and strength.
        /// </summary>
        /// <param name="newFlavor"> The new flavor preferrence.</param>
        /// <param name="newRoast"> The new roast preferrence.</param>
        /// <param name="newStrength"> The new strength preferrence.</param>
        public TasteProfile(string newFlavor, string newRoast, string newStrength)
        {
            this.flavor = newFlavor;
            this.roast = newRoast;
            this.strength = newStrength;
        }

        /// <summary>
        /// Gets or sets the preferred coffee flavor.
        /// </summary>
        public string Flavor
        {
            get => this.flavor;
            set
            {
                this.flavor = value;
            }
        }

        /// <summary>
        /// Gets or sets the preferred coffee roast.
        /// </summary>
        public string Roast
        {
            get => this.roast;
            set
            {
                this.roast = value;
            }
        }

        /// <summary>
        /// Gets or sets the preferred coffee strength.
        /// </summary>
        public string Strength
        {
            get => this.strength;
            set
            {
                this.strength = value;
            }
        }
    }
}
