// <copyright file="ActivityLogService.cs" company="Keila Holcombe 011896868">
// Copyright (c) Keila Holcombe. All rights reserved.
// </copyright>
using System.ComponentModel;

namespace SubscriptionPlatformService
{
    /// <summary>
    /// Manages all the activity logs and allows adding the activities.
    /// </summary>
    public class ActivityLogService
    {
        /// <summary>
        /// Stores each user's activities in the application in a list.
        /// </summary>
        protected List<ActivityLog> activities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityLogService"/> class.
        /// Initialize the activitylogservice with an empty activity log list.
        /// </summary>
        public ActivityLogService()
        {
            this.activities = new List<ActivityLog>();
        }

        /// <summary>
        /// Notifies the event when the property changes.
        /// </summary>
        public event PropertyChangedEventHandler? OnUIPropertyChanged;

        /// <summary>
        /// Gets the activity log list stores in this class.
        /// </summary>
        public List<ActivityLog> Activities
        {
            get => this.activities;
        }

        /// <summary>
        /// Add an activity log to the list.
        /// </summary>
        /// <param name="activityLog">The activity log that is being added.</param>
        public void AddActivities(ActivityLog activityLog)
        {
            this.activities.Add(activityLog);

            // After adding it to the activity, notify the change
            this.UIPropertyChanged("Activity History");
        }

        /// <summary>
        /// Notify that the activity has been changed.
        /// </summary>
        /// <param name="state"> The state of change that happened.</param>
        public void UIPropertyChanged(string state)
        {
            this.OnUIPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(state));
        }
    }
}
