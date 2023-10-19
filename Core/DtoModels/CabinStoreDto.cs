using System;
using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Core.DtoModels
{
	public class CabinStoreDto
	{
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? StoreOwnerId { get; set; }
    }
}

