using System;
using System.ComponentModel.DataAnnotations;

namespace Eloqua.Api.Bulk.Models.Acitivity
{
    /// <summary>
    /// More information about the fields can be found at
    /// http://docs.oracle.com/cloud/latest/marketingcs_gs/OMCAB/index.html#Developers/BulkAPI/Reference/activity-fields.htm%3FTocPath%3DBulk%25202.0%2520API%7CReference%7C_____7
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Unique identifier of the activity
        /// </summary>
        public int? ActivityId { get; set; }

        /// <summary>
        /// Type of the activity. This should be an enum, but all its possible values are
        /// not known, so it is a string. The currently known values are available as constants at the
        /// <see cref="Eloqua.Api.Bulk.Models.Acitivity.ActivityType"/> class
        /// </summary>
        public string ActivityType { get; set; }

        /// <summary>
        /// Date of the activity
        /// </summary>
        public DateTime ActivityDate { get; set; }

        /// <summary>
        /// Email Address that is related to the activity
        /// </summary>
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Unique identifier of the contact
        /// </summary>
        public int? ContactId { get; set; }

        /// <summary>
        /// IP Address of the person that originated this activity
        /// </summary>
        [MaxLength(50)]
        public string IpAddress { get; set; }

        /// <summary>
        /// Unique identifier of the visitor
        /// </summary>
        public int? VisitorId { get; set; }

        /// <summary>
        /// Unique identifier of the email recipient
        /// </summary>
        public string EmailRecipientId { get; set; }

        /// <summary>
        /// Type of the asset related to this activity. This should be an enum, but all its possible values are
        /// not known, so it is a string. The currently known values are available as constants at the
        /// <see cref="Eloqua.Api.Bulk.Models.Acitivity.AssetType"/> class
        /// </summary>
        public string AssetType { get; set; }

        /// <summary>
        /// Name of the asset related to this activity
        /// </summary>
        [MaxLength(100)]
        public string AssetName { get; set; }

        /// <summary>
        /// Unique identifier of the asset of this activity
        /// </summary>
        public int? AssetId { get; set; }

        /// <summary>
        /// Subject of the activity
        /// </summary>
        [MaxLength(500)]
        public string SubjectLine { get; set; }

        /// <summary>
        /// Web link of the email. This has a maximum length of 8192
        /// </summary>
        public Uri EmailWebLink { get; set; }

        /// <summary>
        /// External unique identfier of te visitor
        /// </summary>
        [MaxLength(38)]
        public string VisitorExternalId { get; set; }

        /// <summary>
        /// Unique identifier of the activity
        /// </summary>
        public int? CampaignId { get; set; }

        /// <summary>
        /// External unique identifier for this activity
        /// </summary>
        [MaxLength(38)]
        public string ExternalId { get; set; }

        /// <summary>
        /// The type of the send made related to this activity. This should be an enum, but all its possible values are
        /// not known, so it is a string. The currently known values are available as constants at the
        /// <see cref="Eloqua.Api.Bulk.Models.Acitivity.EmailSendType"/> class
        /// </summary>
        [MaxLength(100)]
        public string EmailSendType { get; set; }

        /// <summary>
        /// Date when the activity was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the deployment email
        /// </summary>
        public int? EmailDeploymentId { get; set; }

        /// <summary>
        /// Link of the click throu. This has a maximum length of 8192
        /// </summary>
        public Uri EmailClickedThruLink { get; set; }

        /// <summary>
        /// Data without any formatting
        /// </summary>
        [MaxLength(64000)]
        public string RawData { get; set; }

        /// <summary>
        /// URL of the referrer
        /// </summary>
        public Uri ReferrerUrl { get; set; }

        /// <summary>
        /// Unique identifier of the web visit
        /// </summary>
        public int? WebVisitId { get; set; }

        /// <summary>
        /// URL of this activity
        /// </summary>
        public Uri Url { get; set; }

        public bool? IsWebTrackingOptedIn { get; set; }

        /// <summary>
        /// Quantity of pages of the activity
        /// </summary>
        public int? NumberOfPages { get; set; }

        /// <summary>
        /// The URL of the first page view
        /// </summary>
        public Uri FirstPageViewUrl { get; set; }

        /// <summary>
        /// Duration of the activity
        /// </summary>
        public string Duration { get; set; }
    }
}
