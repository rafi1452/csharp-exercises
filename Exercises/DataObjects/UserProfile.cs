using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    /// <summary>
    /// Simple user profile storage table
    /// </summary>
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string ProfileKey { get; set; } = null!;
        public string ProfileValue { get; set; } = null!;
        public int Ordering { get; set; }
    }
}
