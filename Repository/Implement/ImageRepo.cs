using Model.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class ImageRepo : BaseRepo<Image>, IImageRepo
    {
        public ImageRepo(FruitContext context) : base(context)
        {
        }
        public List<Image> GetImagesByParent(string parent)
        {
           return this._dbSet.Where(x=> x.Parent == parent).ToList();
        }

    }
}
