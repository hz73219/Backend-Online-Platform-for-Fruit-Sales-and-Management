using KinhDoanhTraiCay.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using Service.Interface;
using System.Data;

namespace KinhDoanhTraiCay.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class CartController : BaseController<Cart, CartDto, ICartRepo, ICartService>
    {
        public CartController(ICartService baseService) : base(baseService)
        {
        }
        [HttpPost]
        public override IActionResult Create([FromBody]Cart entity)
        {
            string userId = HttpContext.Items["UserId"].ToString();
            if(string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }
            entity.IdUser = userId;
            entity.Id = Guid.NewGuid().ToString();
            this._Service.AddCart(entity);
            if(_Service.Flag)
            {
                return Ok();
            }    
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public override IActionResult Get(string id)
        {
            string userId = HttpContext.Items["UserId"].ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }
            _Service.GetByIdUser(userId);
            if (_Service.Flag)
            {
                return Ok(_Service.ObjList);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
