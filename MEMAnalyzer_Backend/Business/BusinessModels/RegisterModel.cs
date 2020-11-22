using MEMAnalyzer_Backend.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MEMAnalyzer_Backend.Business.BusinessModels
{
    /// <summary>
    /// User model for registration
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        /// <example>BlackDragon223</example>
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        /// <summary>
        /// FullName
        /// </summary>
        /// <example>Oleg Olegov</example>
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// <example>oleg123@ya.ru</example>
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        /// <example>Oleg123@</example>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        /// <example>21.03.2000</example>
        [JsonConverter(typeof(DateTimeConverter))]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTimeOffset DateOfBirth { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        /// <example>true</example>
        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }
    }
}
