using KinhDoanhTraiCay.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.Interface;
using System.Data;

namespace KinhDoanhTraiCay.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost(Name = "Login")]
        public IActionResult Login([FromBody] User user)
        {

            user.Password = JWT.hashPassword(user.Password);
            userService.Login(user);
            if (userService.Flag)
            {
                if (null == userService.ObjDetail)
                {
                    return NotFound("Vui lòng nhập đúng tài khoản hoặc mật khẩu tài khoản!");
                }
                else
                {
                    string token = JWT.GenerateToken(userService.ObjDetail.Id, userService.ObjDetail.Role);
                    return Ok(token);
                }
            }
            else
            {
                return BadRequest(userService.Error);
            }

        }
        [HttpPost(Name = "Register")]
        public IActionResult Register([FromBody] User user)
        {
            user.Role = "user";
            user.Password = JWT.hashPassword(user.Password);
            user.Id = Guid.NewGuid().ToString();
            userService.Create(user);
            if (userService.Flag)
            {
                return Ok();
            }
            else
            {
                return BadRequest(userService.Error);
            }
        }
        [HttpPost(Name = "ValidateToken")]
        public IActionResult ValidateToken([FromBody] string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                   string roleClaim =  JWT.GetUserRole(token);
                    if (!string.IsNullOrEmpty(roleClaim))
                    {
                        return Ok(roleClaim);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
