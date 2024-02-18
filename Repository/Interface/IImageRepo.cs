using Model.Entities;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IImageRepo : IBaseRepo<Image>
    {
        public List<Image> GetImagesByParent(string parent);
    }
}
