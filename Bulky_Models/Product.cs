namespace Bulky_Models
{
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int Id  { get; set; }
        
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN {get; set; }
        
        [Required(ErrorMessage = "List Price is required")]
        [DisplayName("List Price")]
        [Range(1, 1000, ErrorMessage = "price must be bwtween 1 -1000")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage ="Book price is required")]
        [DisplayName("price ")]
        [Range(1, 1000, ErrorMessage = "price must be bwtween 1 -1000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Price for 50 +")]
        [Range(1, 1000, ErrorMessage ="price must be bwtween 1 -1000")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Price for 100 +")]
        [Range(1, 1000, ErrorMessage = "price must be bwtween 1 -1000")]
        public double Price100 { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageURL  { get; set; }

    }
}
