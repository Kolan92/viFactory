using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.IRepo;
using Repository.Models;

namespace Repository.Repo
{
    public class NewsRepo : INewsRepo 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<News> GetAll()
        {
            return db.News.AsNoTracking();
        }

        public IQueryable<News> GetNewsPage(int? page, int? newsCount)
        {
            var news = db.News.OrderByDescending(x => x.PublishDate)
                .Skip((page.Value - 1)*newsCount.Value)
                .Take(newsCount.Value);

            return news;
        }
        
        public News GetById(int id)
        {
            return db.News.FirstOrDefault(x => x.Id == id);
        }

        public void Add(News news)
        {
            throw new NotImplementedException();
        }

        public void Update(News news)
        {
            throw new NotImplementedException();
        }   
    }
}