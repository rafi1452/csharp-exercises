using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    public partial class ArticleVersion
    {
        public uint VersionId { get; set; }
        public uint UcmItemId { get; set; }
        public uint UcmTypeId { get; set; }
        /// <summary>
        /// Optional version name
        /// </summary>
        public string VersionNote { get; set; } = null!;
        public DateTime SaveDate { get; set; }
        public uint EditorUserId { get; set; }
        /// <summary>
        /// Number of characters in this version.
        /// </summary>
        public uint CharacterCount { get; set; }
        /// <summary>
        /// SHA1 hash of the version_data column.
        /// </summary>
        public string Sha1Hash { get; set; } = null!;
        /// <summary>
        /// json-encoded string of version data
        /// </summary>
        public string VersionData { get; set; } = null!;
        /// <summary>
        /// 0=auto delete; 1=keep
        /// </summary>
        public sbyte KeepForever { get; set; }
    }
}
