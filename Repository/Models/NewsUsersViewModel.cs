using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Repository.Models
{
    public class NewsUsersViewModel
    {
        public IEnumerable<ApplicationUser> PartnerUser { get; set; }
        public IPagedList<News> NewsPagedList { get; set; }
    }
}