using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class News
    {
        public News()
        {
            this.Images = new HashSet<UserImage>();
        }

        public int Id { get; set; }

        [MaxLength(300)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [MaxLength(10000)]
        [Display(Name = "Treść ")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publikowany ")]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd", ApplyFormatInEditMode=true)]
        public DateTime PublishDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Edytowany")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime? EditDate { get; set; }

        public virtual ICollection<UserImage> Images { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}