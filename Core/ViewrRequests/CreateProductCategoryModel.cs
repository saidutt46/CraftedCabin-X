using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewrRequests
{
	public class CreateProductCategoryModel
	{
        [Required(ErrorMessage = "Category Name is required")]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}

