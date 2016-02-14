namespace Eloqua.Api.Bulk.Models.Acitivity
{
    /// <summary>
    /// Known types of an email send.
    /// <seealso cref="Activity.EmailSendType"/>
    /// </summary>
    public static class EmailSendType
    {
        /// <summary>
        /// Campaign type of an email send
        /// </summary>
        public const string Campaign = "Campaign";

        /// <summary>
        /// Form processing step type of an email send
        /// </summary>
        public const string FormProcessingStep = "FormProcessingStep";

        /// <summary>
        /// Quick send type of an email send
        /// </summary>
        public const string QuickSend = "QuickSend";
    }
}