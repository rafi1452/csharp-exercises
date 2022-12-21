using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    public partial class ArticleChat
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public uint Id { get; set; }
        public uint UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public uint ContentId { get; set; }
        public uint VersionId { get; set; }
        public string Section { get; set; } = null!;
        public string Msg { get; set; } = null!;
    }
}
