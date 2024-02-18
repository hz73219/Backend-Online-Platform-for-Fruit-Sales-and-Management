using KinhDoanhTraiCay.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;
using Service.Interface;

namespace KinhDoanhTraiCay.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class OrderController  : BaseController<Order, OrderDto, IOrderRepo, IOrderService>
    {
        public OrderController(IOrderService baseService) : base(baseService)
        {
        }
        public override IActionResult Create(Order entity)
        {
            string userId = HttpContext.Items["UserId"].ToString();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }
            entity.IdUser = userId;
            return base.Create(entity);
        }
        [Authorize(Roles = "admin")]

        public override IActionResult GetAll()
        {
            return base.GetAll();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public  IActionResult UpdateStatus(string id,int status)
        {
            this._Service.Get(id);
            if (this._Service.ObjDetail==null|| this._Service.ObjDetail.Status==4)
            {
                return NotFound();
            }
            if(status==4)
            {
                this._Service.ObjDetail.FinishDay = DateTime.Now;
            }    
            this._Service.ObjDetail.Id = id;
            this._Service.ObjDetail.Status = status;
            this._Service.Update(this._Service.ObjDetail);
            if(this._Service.Flag)
            {
                return Ok(this._Service.ObjDetail);
            }
            else
            {
                return BadRequest(_Service.Error);
            }    
        }

    }
}
