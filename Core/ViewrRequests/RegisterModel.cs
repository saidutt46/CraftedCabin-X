using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Special characters are not allowed in the User Name.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}