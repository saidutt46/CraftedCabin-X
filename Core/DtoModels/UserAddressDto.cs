using System;
using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DtoModels
{
	public class UserAddressDto
	{
        public required string Id { get; set; }
        public required string ApplicationUserId { get; set; }
        public required string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}

