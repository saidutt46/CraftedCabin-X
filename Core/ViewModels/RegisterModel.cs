using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Special characters are not allowed in the User Name.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "User Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
    }
}