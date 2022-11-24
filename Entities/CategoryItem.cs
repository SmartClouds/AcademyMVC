using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace AcademyMVC.Entities
{
    public class CategoryItem
    {
        private DateTime _releaseDate= DateTime.MinValue;
        public int ID { get; set; }
        [Required]
        [StringLength(200,MinimumLength =2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int MediaTypeId { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem>? MediaType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTimeItemReleased {
            get
            {
                return (_releaseDate==DateTime.MinValue) ? DateTime.Now : _releaseDate;
            } 
            set
            {
                _releaseDate = value;
            }
        }
        [NotMapped]
        public int? ContentId { get; set; }


    }
}
