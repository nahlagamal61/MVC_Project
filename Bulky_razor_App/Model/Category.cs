namespace Bulky_razor_App.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must add Category name !")]
        [MaxLength(30)]
        [DisplayName("Name of Category")]
        public string Name { get; set; }
        [Range(1, 50, ErrorMessage = "category display Order must be between 1 & 50")]
        [DisplayName("Category Order")]
        public int CategoryOrder { get; set; }
    }
}
