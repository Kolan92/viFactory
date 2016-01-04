using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Project
    {
        public Project()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Images = new HashSet<UserImage>();
        }

        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<UserImage> Images { get; set; }
    }
}