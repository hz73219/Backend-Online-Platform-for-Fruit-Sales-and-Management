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
    public class VoucherController : BaseController<Voucher, VoucherDto, IVoucherRepo, IVoucherService>
    {
        public VoucherController(IVoucherService baseService) : base(baseService)
        {
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public override IActionResult Create(Voucher entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            return base.Create(entity);
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public override IActionResult Update(Voucher entity)
        {
            return base.Update(entity);
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public override IActionResult Delete(string id)
        {
            return base.Delete(id);
        }
    }
}
