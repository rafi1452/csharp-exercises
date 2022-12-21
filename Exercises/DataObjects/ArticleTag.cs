using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    /// <summary>
    /// Maps items from content tables to tags
    /// </summary>
    public partial class ArticleTag
    {
        public string TypeAlias { get; set; } = null!;
        /// <summary>
        /// PK from the core content table
        /// </summary>
        public uint CoreContentId { get; set; }
        /// <summary>
        /// PK from the content type table
        /// </summary>
        public int ContentItemId { get; set; }
        /// <summary>
        /// PK from the tag table
        /// </summary>
        public uint TagId { get; set; }
        /// <summary>
        /// Date of most recent save for this tag-item
        /// </summary>
        public DateTime TagDate { get; set; }
        /// <summary>
        /// PK from the content_type table
        /// </summary>
        public int TypeId { get; set; }
    }
}
