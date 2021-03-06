﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface INewsRepo
    {
        IQueryable<News> GetAll();
        IQueryable<News> GetNewsPage(int? page, int? newsCount);
        News GetById(int id);
        void Add(News news);
        void Update(News news);
    }
}
