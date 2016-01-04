using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Event
    {
        public int Id { get; set; }
        DateTime EventDate { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
        [MaxLength(1000)]
        public string Location { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}