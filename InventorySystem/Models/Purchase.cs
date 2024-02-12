using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace InventorySystem.Models
{
	public class Purchase
	{
		public int Id { get; set; }
		[MaxLength(50, ErrorMessage = "Purchase product mustn't be exceed 50 charcters.")]
		[DisplayName("Purchased Product")]
		public string PurchaseProduct { get; set; }

		[MaxLength(5, ErrorMessage = "Purchase quantity mustn't be exceed 5 charcters.")]
		[DisplayName("Purchased Quantity")]
		public string PurchaseQuantity { get; set; }
		[DisplayName("Purchased Date")]
		public DateTime PurchaseDate { get; set; }
       

    }
}
