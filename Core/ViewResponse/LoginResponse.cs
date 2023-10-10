using System;
using Core.DtoModels;

namespace Core.ViewResponse
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserProfileDto? UserProfile { get; set; }
    }
}

