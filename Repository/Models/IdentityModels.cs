using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.News = new HashSet<News>();
            this.Projects = new HashSet<Project>();
            this.Events = new HashSet<Event>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsVisible { get; set; }

        [MaxLength(10000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Url { get; set; }

        public string ImageId { get; set; }
        public virtual UserImage Avatar { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }




    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("viFactory")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<News> News { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<UserImage> Image { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}