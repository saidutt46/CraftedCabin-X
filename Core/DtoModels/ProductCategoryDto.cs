using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DtoModels
{
	public class ProductCategoryDto
	{
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}