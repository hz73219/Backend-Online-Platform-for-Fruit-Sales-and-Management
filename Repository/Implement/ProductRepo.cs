using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class ProductRepo:BaseRepo<Product>,IProductRepo
    {
        public ProductRepo(FruitContext dbContext) : base(dbContext)
        {
        }
        public override void Update(Product entity)
        {
            _dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreateDay).IsModified = false;
            _context.SaveChanges();
        }
    }
}
