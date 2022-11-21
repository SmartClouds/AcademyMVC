using System.ComponentModel.DataAnnotations;

namespace AcademyMVC.Entities
{
    public class CategoryItem
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }
        public DateTime DateTimeItemReleased { get; set; }

    }
}
