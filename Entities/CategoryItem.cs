using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace AcademyMVC.Entities
{
    public class CategoryItem
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem>? MediaType { get; set; }
        public DateTime DateTimeItemReleased { get; set; }
        [NotMapped]
        public int? ContentId { get; set; }


    }
}
