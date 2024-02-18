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
    public class OriginRepo : BaseRepo<Origin>, IOriginRepo
    {
        public OriginRepo(FruitContext context) : base(context)
        {
        }
    }
}
