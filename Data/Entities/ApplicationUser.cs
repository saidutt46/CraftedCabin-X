using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
	public class ApplicationUser : IdentityUser
	{
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DateJoined { get; set; }

        public ICollection<UserAddress>? UserAddresses { get; set; }
        // Association to CabinStore
        public Guid? CabinStoreId { get; set; }
        public CabinStore? CabinStore { get; set; }

    }
}