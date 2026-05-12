// <copyright file="BagSizes.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores the information about the bagsizes.
    /// </summary>
    public class BagSizes
    {
        /// <summary>
        /// Stores the bagsize of the coffee.
        /// </summary>
        protected double? bagsize;

        /// <summary>
        /// Stores the price of the bagsize.
        /// </summary>
        protected double? price;

        /// <summary>
        /// Initializes a new instance of the <see cref="BagSizes"/> class.
        /// Initializing the bagsize and their price for each input that user created.
        /// </summary>
        /// <param name="newBagsize"> The bagsize in ounces.</param>
        /// <param name="newPrice"> The price of that bagsize.</param>
        public BagSizes(double? newBagsize, double? newPrice)
        {
            this.bagsize = newBagsize;
            this.price = newPrice;
        }

        /// <summary>
        /// Gets or sets and sets the bagsize of the coffee.
        /// </summary>
        public double? BagSize
        {
            get => this.bagsize;
            set
            {
                this.bagsize = value;
            }
        }

        /// <summary>
        /// Gets getter to get the price of the coffee.
        /// </summary>
        public double? Price
        {
            get => this.price;
        }
    }
}
