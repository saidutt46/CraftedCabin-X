using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewrRequests
{
	public class CreateStoreModel
	{
        [Required(ErrorMessage = "Product Name is required")]
        [MaxLength(255)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description Name is required")]
        [MaxLength(500)]
        public required string Description { get; set; }
        public required string StoreOwnerId { get; set; }

    }
}

