using Model.Entities;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService : IBaseService<User, UserDto, IUserRepo>
    {
        public void Login(User user);
    }
}
