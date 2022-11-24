using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyMVC.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Insert between 2 and 200 characters")]
        [StringLength(200,MinimumLength=2)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name ="Image Path")]
        public string ThumbnailImagePath { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<CategoryItem>? CategoryItems { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<UserCategory>? UserCategory { get; set; }
    }
}
