using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    public partial class ArticleStat
    {
        /// <summary>
        /// fkd5g_content.id
        /// </summary>
        public uint ItemId { get; set; }
        public string Type { get; set; } = null!;
        public int Count { get; set; }
    }
}
