using KinhDoanhTraiCay.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;
using Service.DTO;
using Service.Interface;
using System.Data;

namespace KinhDoanhTraiCay.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController  : BaseController<User, UserDto, IUserRepo, IUserService>
    {
        public UserController(IUserService baseService) : base(baseService)
        {
        }
        [HttpGet]
        public override IActionResult Get(string id)
        {
            string userId = HttpContext.Items["UserId"].ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }
            return base.Get(userId);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public override IActionResult GetAll()
        {
            return base.GetAll(); 
        }
        [HttpPut]
        public override IActionResult Update(User entity)
        {
            entity.ListCart = null;
            entity.ListOrder = null;
            return base.Update(entity);
        }
    }
}
