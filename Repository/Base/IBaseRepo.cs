﻿using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public interface  IBaseRepo <T> where T:class
    {
        public DbSet<T> _dbSet { get; set; }
        T? Get(string id);
        List<T> GetAll();
        void Create(T entity);
        void Create(List<T> listEntity);
        void Update(T entity);
        void Delete(string id);
        void Delete(T entity);
        void Delete(List<string> listEntity);
        void Delete(List<T> listEntity);

    }
}
