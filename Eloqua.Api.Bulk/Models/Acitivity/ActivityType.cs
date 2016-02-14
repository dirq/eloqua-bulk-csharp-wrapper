namespace Eloqua.Api.Bulk.Models.Acitivity
{
    /// <summary>
    /// Known types of an <see cref="Activity"/>.
    /// <seealso cref="Activity.ActivityType"/>
    /// </summary>
    public static class ActivityType
    {
        /// <summary>
        /// Opening of an email
        /// </summary>
        public const string EmailOpen = "EmailOpen";

        /// <summary>
        /// Click through in the email
        /// </summary>
        public const string EmailClickthrough = "EmailClickthrough";

        /// <summary>
        /// Sending of an email
        /// </summary>
        public const string EmailSend = "EmailSend";

        /// <summary>
        /// Subscribing activity
        /// </summary>
        public const string Subscribe = "Subscribe";

        /// <summary>
        /// Unsubscribing activity
        /// </summary>
        public const string Unsubscribe = "Unsubscribe";

        /// <summary>
        /// Bounceback activity
        /// </summary>
        public const string Bounceback = "Bounceback";

        /// <summary>
        /// Visit of a web
        /// </summary>
        public const string WebVisit = "WebVisit";

        /// <summary>
        /// View of a page activity
        /// </summary>
        public const string PageView = "PageView";
    }
}
