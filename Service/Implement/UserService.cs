using AutoMapper;
using Model.Entities;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class UserService : BaseService<User, UserDto, IUserRepo>, IUserService
    {
        public UserService(IUserRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public void Login(User user)
        {
            try
            {
                this.ObjDetail = this.ThisRepo.findUserLogin(user);
            }
            catch(Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public override void Get(string id)
        {
            try
            {
                this.ObjDetail = this.ThisRepo._dbSet.Where(x=>x.Id==id).FirstOrDefault();  
                if(this.ObjDetail == null)
                {
                    Flag = false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

    }
}
