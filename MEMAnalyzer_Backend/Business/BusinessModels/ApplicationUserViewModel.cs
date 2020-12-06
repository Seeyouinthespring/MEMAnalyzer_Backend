using MEMAnalyzer_Backend.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MEMAnalyzer_Backend.Business
{
    /// <summary>
    /// User model for updating
    /// </summary>
    public class ApplicationUserDtoModel
    {
        /// <summary>
        /// Full name
        /// </summary>
        /// <example>Oleg Olegov</example>
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        /// <summary>
        /// Email of user
        /// </summary>
        /// <example>oleg123@ya.ru</example>
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        /// <summary>
        /// Gender of user
        /// </summary>
        /// <example>true</example>
        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }
    }

    /// <summary>
    /// User view model
    /// </summary>
    public class ApplicationUserViewModel : ApplicationUserDtoModel
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <example>372bja8osdrdq28efw87qwh</example>
        public string Id { get; set; }

        /// <summary>
        /// Date of birth for user
        /// </summary>
        /// <example>21.03.2020</example>
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTimeOffset DateOfBirth { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        /// <example>1</example>
        public string UserName { get; set; }
    }

    /// <summary>
    /// Model of user with result
    /// </summary>
    public class ApplicationUserWithResultViewModel : ApplicationUserViewModel 
    {
        /// <summary>
        /// Result model
        /// </summary>
        public ResultViewModel Result { get; set; }

        /// <summary>
        /// Role of user
        /// </summary>
        /// <example>Administrator</example>
        public string Role { get; set; }

        /// <summary>
        /// Date of lockout end
        /// </summary>
        /// <example>2021-11-16</example>
        public DateTimeOffset LockoutEnd { get; set; }

        /// <summary>
        /// Is user locked
        /// </summary>
        /// <example>true</example>
        public bool IsLocked { get; set; }
    }

    /// <summary>
    /// Model that returns in autorization and registration
    /// </summary>
    public class ApplicationUserEnterViewModel : ApplicationUserWithResultViewModel
    {
        /// <summary>
        /// Authorization token
        /// </summary>
        /// <example>long string</example>
        public string Token { get; set; }

        /// <summary>
        /// Expiration of token date
        /// </summary>
        /// <example>1</example>
        public DateTime Expiration { get; set; }
    }

}
