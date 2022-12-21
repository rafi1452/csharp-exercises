using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    public partial class Tag
    {
        public uint Id { get; set; }
        public uint ParentId { get; set; }
        public int Lft { get; set; }
        public int Rgt { get; set; }
        public uint Level { get; set; }
        public string Path { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string Note { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Published { get; set; }
        public uint CheckedOut { get; set; }
        public DateTime CheckedOutTime { get; set; }
        public uint Access { get; set; }
        public string Params { get; set; } = null!;
        /// <summary>
        /// The meta description for the page.
        /// </summary>
        public string Metadesc { get; set; } = null!;
        /// <summary>
        /// The meta keywords for the page.
        /// </summary>
        public string Metakey { get; set; } = null!;
        /// <summary>
        /// JSON encoded metadata properties.
        /// </summary>
        public string Metadata { get; set; } = null!;
        public uint CreatedUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedByAlias { get; set; } = null!;
        public uint ModifiedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Images { get; set; } = null!;
        public string Urls { get; set; } = null!;
        public uint Hits { get; set; }
        public string Language { get; set; } = null!;
        public uint Version { get; set; }
        public DateTime PublishUp { get; set; }
        public DateTime PublishDown { get; set; }
    }
}
