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
        [Required (ErrorMessage ="Please Select a valid item from the '{0}' dromdown list")]
        [Display(Name= "Media Type")]
        public int MediaTypeId { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem>? MediaType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Item Released Time")]
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
