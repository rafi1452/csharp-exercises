using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    public partial class ArticleDraft
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public uint Id { get; set; }
        public uint ContentId { get; set; }
        public string Title { get; set; } = null!;
        public string Introtext { get; set; } = null!;
        public string State { get; set; } = null!;
        /// <summary>
        /// Comma-separated list of tag IDs
        /// </summary>
        public string Tags { get; set; } = null!;
        public DateTime Modified { get; set; }
        public uint ModifiedBy { get; set; }
        /// <summary>
        /// Base article version
        /// </summary>
        public uint Version { get; set; }
        /// <summary>
        /// Optional version name
        /// </summary>
        public string VersionNote { get; set; } = null!;
    }
}
