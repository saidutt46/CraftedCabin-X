using System;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
	public class ApplicationUser : IdentityUser
	{
        public ICollection<UserAddress>? UserAddresses { get; set; }

    }
}