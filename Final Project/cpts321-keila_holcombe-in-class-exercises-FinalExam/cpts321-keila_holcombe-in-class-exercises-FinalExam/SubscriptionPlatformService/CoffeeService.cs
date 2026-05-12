// <copyright file="CoffeeService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages all the coffee and has methods to apply on the coffees.
    /// </summary>
    public class CoffeeService
    {
        /// <summary>
        /// Stores each of the coffee that the user creates into a list.
        /// </summary>
        protected List<Coffee> coffees;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoffeeService"/> class.
        /// Initialize the CoffeeService with an empty coffees list.
        /// </summary>
        public CoffeeService()
        {
            this.coffees = new List<Coffee>();
        }

        /// <summary>
        /// Gets the list of all the coffee that user created.
        /// </summary>
        public List<Coffee> Coffees
        {
            get { return this.coffees; }
        }

        /// <summary>
        /// Add a new coffee type based on the user's input.
        /// </summary>
        /// <param name="coffee"> The coffee that is being added.</param>
        /// <returns> Bool of if the coffee was succissifully added or not.</returns>
        public bool AddCoffee(Coffee coffee)
        {
            // Check if all input information is not empty
            if (string.IsNullOrEmpty(coffee.Name) || string.IsNullOrEmpty(coffee.Origin) || string.IsNullOrWhiteSpace(coffee.RoastType) || string.IsNullOrWhiteSpace(coffee.FlavorNotes))
            {
                return false;
            }

            // Check if this coffee type's name already exist
            foreach (Coffee existingCoffee in this.coffees)
            {
                if (existingCoffee.Name == coffee.Name)
                {
                    return false;
                }
            }

            // Check if the coffee has bagsizes
            if (coffee.BagSizes.Count == 0)
            {
                return false;
            }

            // Add the new coffee to the coffees list
            this.coffees.Add(coffee);
            return true;
        }

        /// <summary>
        /// Get the current coffee name from the coffees list.
        /// Referenced the following to learn about string.Equal:
        /// https://stackoverflow.com/questions/6371150/comparing-two-strings-ignoring-case-in-c-sharp.
        /// </summary>
        /// <param name="name"> The name of the coffee it's looking for.</param>
        /// <returns> The coffee that it's looking for.</returns>
        public Coffee? GetCoffee(string? name)
        {
            // Check if the string name is null or not
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            // Find the coffee from the coffees list
            foreach (Coffee coffee in this.coffees)
            {
                if (string.Equals(coffee.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return coffee;
                }
            }

            // If we were not able to find the coffee in coffees list, return null
            return null;
        }
    }
}
