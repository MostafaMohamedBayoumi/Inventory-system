using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InventorySystem.Models
{
	public class Sale
	{
		public int Id { get; set; }
		[MaxLength(50, ErrorMessage = "Sale Name mustn't be exceed 50 charcters.")]
		[DisplayName("Sale Product")]
		public string SaleProduct { get; set; }

		[MaxLength(5, ErrorMessage = "Sale Qnty mustn't be exceed 5 charcters.")]
		[DisplayName("Sale quantity")]
		public string Salequantity { get; set; }
		[DisplayName("Sale Date")]
		public DateTime SaleDate { get; set; }
       

        



    }
}
