using KinhDoanhTraiCay.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interface;
using Service.DTO;
using Service.Interface;

namespace KinhDoanhTraiCay.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : BaseController<Category,CategoryDto,ICategoryRepo,ICategoryService>
    {
        public CategoryController(ICategoryService baseService) : base(baseService)
        {      
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public override IActionResult Create(Category entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            return base.Create(entity);
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public override IActionResult Update(Category entity)
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
