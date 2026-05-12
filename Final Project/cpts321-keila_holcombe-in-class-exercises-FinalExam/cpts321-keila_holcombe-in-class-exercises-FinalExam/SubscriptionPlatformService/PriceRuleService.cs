// <copyright file="PriceRuleService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages all the the pricerule that was created and method for them.
    /// </summary>
    public class PriceRuleService
    {
        /// <summary>
        /// Stores the list of pricceRukeDiscounts that will be applied to the subscription's price.
        /// </summary>
        protected List<IPriceRuleDiscount> priceRuleDiscounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceRuleService"/> class.
        /// Initialize the priceRuleDiscounts list as an empty list.
        /// </summary>
        public PriceRuleService()
        {
            this.priceRuleDiscounts = new List<IPriceRuleDiscount>();
        }

        /// <summary>
        /// Adding the new priceRuleDiscount to the list of priceRuleDiscounts, if there exist a rule with same target, it will replace it with the new rule.
        /// </summary>
        /// <param name="priceRuleDiscount"> The new priceRuleDiscount that will be added to the list.</param>
        /// <returns> True or false of if the price rule was successfully added.</returns>
        public bool AddPriceRuleDiscount(IPriceRuleDiscount priceRuleDiscount)
        {
            IPriceRuleDiscount? exist = null;

            // Check if a rule with same target exist, if yes save it to exist so later we can remove it
            foreach (IPriceRuleDiscount rules in this.priceRuleDiscounts)
            {
                if (rules.GetTarget() == priceRuleDiscount.GetTarget())
                {
                    exist = rules;
                }
            }

            // If there is a rule with same target exist, remove it so it can be replaced
            if (exist != null)
            {
                this.priceRuleDiscounts.Remove(exist);
            }

            // Add the new rule
            this.priceRuleDiscounts.Add(priceRuleDiscount);
            return true;
        }

        /// <summary>
        /// by using the subscription, find the appropriate priceRUleDiscount to apply to the inputted subscription and calculate the price after the discount.
        /// </summary>
        /// <param name="subscription"> The subscription that will be calculated for the discount.</param>
        /// <returns> The calculated price after applying the discount. </returns>
        public double? CalculatePrice(Subscription? subscription)
        {
            double? price = subscription?.BagSize?.Price;

            // For each priceRuleDiscount we have, calculate the discount and update the price
            foreach (IPriceRuleDiscount priceRuleDiscount in this.priceRuleDiscounts)
            {
                price = priceRuleDiscount.CalculateDiscount(subscription, price);
            }

            // If the price is negative, make it to $0
            if (price < 0)
            {
                price = 0;
            }

            return price;
        }

        /// <summary>
        /// Create a price rule discount based on the target of what it will apply to.
        /// </summary>
        /// <param name="apply"> What this rule will apply to.</param>
        /// <param name="target"> The target value of the discount.</param>
        /// <param name="discount"> The discount price.</param>
        /// <param name="duration"> The duration of the discount.</param>
        /// <returns> True or false of if the price rule discount was successfully added.</returns>
        public bool CreatePriceRuleDiscount(string apply, string target, double discount, int duration)
        {
            // Based on the apply, check which discount to create
            if (apply == "Apply to All Order")
            {
                AllDiscount allDiscount = new AllDiscount(discount, duration);
                this.priceRuleDiscounts.Add(allDiscount);
            }
            else if (apply == "BagSize")
            {
                BagSizeDiscount bagSizeDiscount = new BagSizeDiscount(target, discount, duration);
                this.priceRuleDiscounts.Add(bagSizeDiscount);
            }
            else if (apply == "Coffee")
            {
                CoffeeDiscount coffeeDiscount = new CoffeeDiscount(target, discount, duration);
                this.priceRuleDiscounts.Add(coffeeDiscount);
            }
            else if (apply == "Over Specific Price")
            {
                OverPriceDiscount overPriceDiscount = new OverPriceDiscount(target, discount, duration);
                this.priceRuleDiscounts.Add(overPriceDiscount);
            }
            else
            {
                // If it applies to none of them, return false
                return false;
            }

            return true;
        }
    }
}