using Microsoft.IdentityModel.JsonWebTokens;
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
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(FruitContext context) : base(context)
        {
        }

        public User? findUserLogin(User user)
        {
           return _dbSet.Where(x=>x.UserName==user.UserName&&x.Password==user.Password).FirstOrDefault();
        }
    }
}
