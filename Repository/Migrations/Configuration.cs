using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;

namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Repository.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //For debug purpose
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            //ClearDatabase(context);
            SeedRoles(context);
            SeedImages(context);
            SeedUsers(context);
            SeedNews(context);
            SeedProjects(context);
            SeedEvents(context);
        }


        public static void ClearDatabase(ApplicationDbContext context)
        {
            var tableNames = context.Database.SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%'").ToList();
            foreach (var tableName in tableNames)
            {
                context.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tableName));
            }

            context.SaveChanges();
        }
        private void SeedUsers(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new ApplicationUser { UserName = "Admin" };
                var adminresult = manager.Create(user, "1234Abc.");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
            //if (!context.Users.Any(u => u.UserName.StartsWith("User")))
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        var user = new ApplicationUser { UserName = string.Format("User{0}@gmail.com", i.ToString()) };
            //        var adminResult = manager.Create(user, "1234Abc.");
            //        if (adminResult.Succeeded)
            //            manager.AddToRole(user.Id, "CurrentMember");
            //    }
            //}
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole {Name = "Admin"};
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("CurrentMember"))
            {
                var role = new IdentityRole {Name = "CurrentMember"};
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("FormerMember"))
            {
                var role = new IdentityRole {Name = "FormerMember"};
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("ScientificSupervisor"))
            {
                var role = new IdentityRole {Name = "ScientificSupervisor"};
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Partner"))
            {
                var role = new IdentityRole {Name = "Partner"};
                roleManager.Create(role);
            }
        }

        private void SeedImages(ApplicationDbContext context)
        {
            int i = 0;
            foreach (var file in Directory.GetFiles(@"c:\users\pawel\documents\visual studio 2013\Projects\viFactory\Repository\Resources\Letters\"))
            {
                var image = Image.FromFile(file);

                var userImage = new UserImage()
                {
                    Id = i,
                    Image = ImageToByteArray(image)
                };
                i++;
                context.Set<UserImage>().AddOrUpdate(userImage);
            }

            foreach (var file in Directory.GetFiles(@"c:\users\pawel\documents\visual studio 2013\Projects\viFactory\Repository\Resources\Numbers\"))
            {
                var image = Image.FromFile(file);

                var userImage = new UserImage()
                {
                    Id = i,
                    Image = ImageToByteArray(image)
                };
                i++;
                context.Set<UserImage>().AddOrUpdate(userImage);
            }
        }

        private void SeedNews(ApplicationDbContext context)
        {
            var userId = context.Set<ApplicationUser>().Where(u => u.UserName == "Admin")
                                                        .FirstOrDefault().Id;

            var userImages = context.Set<UserImage>().AsQueryable();
            var index = 0;
            foreach (var image in userImages)
            {

                var images = new HashSet<UserImage>();
                images.Add(image);

                var news = new News()
                {
                    Images = images,
                    Content = "Przyk³adowa treœæ " + index.ToString() + Repository.Models.Constants.loremIpsum,
                    PublishDate = DateTime.Now.AddDays(-1),
                    Title = "Tytu³ " + index.ToString(),
                    UserId = userId,
                };
                index++;
                context.News.Add(news);
            }
            context.SaveChanges();
        }

        private void SeedProjects(ApplicationDbContext context)
        {
            var user = context.Set<ApplicationUser>().Where(u => u.UserName == "Admin").FirstOrDefault();

            var image = context.Set<UserImage>().FirstOrDefault();

            var images = new HashSet<UserImage>();
            images.Add(image);

            var users = new HashSet<ApplicationUser>();
            users.Add(user);

                var project = new Project()
                {
                    Images = images,
                    Description = "Przyk³adowa treœæ ",
                    Title = "Tytu³ " ,
                    UserId = user.Id,
                    Users = users

                };

                context.Project.Add(project);

            context.SaveChanges();
        }

        private void SeedEvents(ApplicationDbContext context)
        {
            var user = context.Set<ApplicationUser>().Where(u => u.UserName == "Admin").FirstOrDefault();

            var image = context.Set<UserImage>().FirstOrDefault();


                var myEvent = new Event()
                {
                    Description = "Przyk³adowa treœæ " ,
                    Location = "Miejsce " ,
                    UserId = user.Id,
                    Name = "Wydarzenie " ,
                };

                context.Event.Add(myEvent);

            context.SaveChanges();
        }

        public byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }


    }
}
