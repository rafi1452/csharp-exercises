using System;
using System.Collections.Generic;

namespace Exercises.DataObjects
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public sbyte Block { get; set; }
        public sbyte? SendEmail { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastvisitDate { get; set; }
        public string Activation { get; set; } = null!;
        public string Params { get; set; } = null!;
        /// <summary>
        /// Date of last password reset
        /// </summary>
        public DateTime LastResetTime { get; set; }
        /// <summary>
        /// Count of password resets since lastResetTime
        /// </summary>
        public int ResetCount { get; set; }
        /// <summary>
        /// Two factor authentication encrypted keys
        /// </summary>
        public string OtpKey { get; set; } = null!;
        /// <summary>
        /// One time emergency passwords
        /// </summary>
        public string Otep { get; set; } = null!;
        /// <summary>
        /// Require user to reset password on next login
        /// </summary>
        public sbyte RequireReset { get; set; }
    }
}
