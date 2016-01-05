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

        public IQueryable<Models.News> GetAll()
        {
            throw new NotImplementedException();
        }

        public Models.News GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Models.News news)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.News news)
        {
            throw new NotImplementedException();
        }
    }
}