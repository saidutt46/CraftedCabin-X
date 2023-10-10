using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Shared;

namespace Data.Entities
{
    public class UserAddress : BaseEntity
    {
        [Required]
        [ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public required ApplicationUser ApplicationUser { get; set; }

        [Required]
        [MaxLength(255)]
        public required string AddressLine1 { get; set; }

        [MaxLength(255)]
        public string? AddressLine2 { get; set; }

        [Required]
        [MaxLength(100)]
        public required string City { get; set; }

        [Required]
        [MaxLength(20)]
        public required string PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Country { get; set; }
    }
}

