using System.Collections.Generic;
using Eloqua.Api.Bulk.Clients;

namespace Eloqua.Api.Bulk.Models
{
    /// <summary>
    /// Result of a set request. This might be used by the <see cref="JsonDataClient.ExportDataAsync{T}"/> method.
    /// Defines basic set result with its metadata.
    /// </summary>
    /// <typeparam name="T">The type of the retrieved elements.</typeparam>
    public class ExportResult<T>
    {
        /// <summary>
        /// The total quantity of returned items. This seems to be the same as <see cref="Count"/>.
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// The limit used to take the items. May be greater than the actual quantity of returned items.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// The start point where the items were taken.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Quantity of returned items. This seems to be the same as <see cref="TotalResults"/>.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Indicates whether or not there are more items that can be retrieved.
        /// </summary>
        public bool HasMore { get; set; }

        /// <summary>
        /// The actual returned items.
        /// </summary>
        public List<T> Items { get; set; }
    }
}
