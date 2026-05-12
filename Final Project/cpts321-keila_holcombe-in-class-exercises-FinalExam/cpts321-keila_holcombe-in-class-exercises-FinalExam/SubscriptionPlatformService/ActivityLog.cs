// <copyright file="ActivityLog.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Stores the information about each activity logs.
    /// </summary>
    public class ActivityLog
    {
        /// <summary>
        /// Stores the user that is doing the activity.
        /// </summary>
        protected User user;

        /// <summary>
        /// Stores the action that is happening during this activity.
        /// </summary>
        protected string action;

        /// <summary>
        /// Stores when this activity is happening.
        /// </summary>
        protected DateTime time;

        /// <summary>
        /// Stores the description of this activity.
        /// </summary>
        protected string description;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityLog"/> class.
        /// Initialize the activity log with the user, action and description. As well as with the current time.
        /// </summary>
        /// <param name="newUser"> The user that is doing the activity.</param>
        /// <param name="newAction"> The action that is happening.</param>
        /// <param name="newDescription"> The description of the activity.</param>
        public ActivityLog(User newUser, string newAction, string newDescription)
        {
            this.user = newUser;
            this.action = newAction;
            this.time = DateTime.Now;
            this.description = newDescription;
        }

        /// <summary>
        /// Gets the user stored in this class.
        /// </summary>
        public User User
        {
            get => this.user;
        }

        /// <summary>
        /// Gets the action that is stored in this class.
        /// </summary>
        public string Action
        {
            get => this.action;
        }

        /// <summary>
        /// Gets the time that is stored in this class.
        /// </summary>
        public DateTime Time
        {
            get => this.time;
        }

        /// <summary>
        /// Gets the description that is stored in this class.
        /// </summary>
        public string Description
        {
            get => this.description;
        }
    }
}
