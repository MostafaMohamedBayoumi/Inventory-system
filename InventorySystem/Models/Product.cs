using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InventorySystem.Models
{
	
	public class Product
	{
        public int Id { get; set; }
		[MaxLength(50, ErrorMessage = "Product Name mustn't be exceed 50 charcters.")]
		[DisplayName("Product Name")]
		public string ProductName { get; set; }
		
		[MaxLength(5, ErrorMessage = "Product Quantity mustn't be exceed 5 charcters.")]
        [DisplayName("Product Quantity")]
        public string ProductQuantity { get; set; }
        [DisplayName("Image")]
        [ValidateNever]
		public string ImageUrl { get; set; }

       


    }
}
