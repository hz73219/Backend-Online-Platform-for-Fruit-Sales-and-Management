using AutoMapper;
using KinhDoanhTraiCay.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Implement;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using Service.Interface;
using System.Data;

namespace KinhDoanhTraiCay.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public readonly IMapper _mapper;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {
            productService.Get(id);
            if (productService.Flag)
            {
                if (null == productService.ObjDetail)
                {
                    return NotFound();
                }
                return Ok(productService.ObjDetail);
            }
            else
            {
                return BadRequest(productService.Error);
            }
        }
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            productService.GetAll();
            if (productService.Flag)
            {
                return Ok(productService.ObjList);
            }
            else
            {
                return BadRequest(productService.Error);
            }
        }
        [HttpPost]
        public  IActionResult GetTypeProduct([FromBody] Search search)
        {
            productService.getListTypeProduct(search);
            if (productService.Flag)
            {
                return Ok(productService.result);
            }
            else
            {
                return BadRequest(productService.Error);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create([FromForm] Product entity, IList<IFormFile> listFile)
        {
            if (listFile.Count == 0)
            {
                return BadRequest();
            }
            productService.Create(entity, listFile);
            if (productService.Flag)
            {
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
            }
            else
            {
                return BadRequest(productService.Error);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public IActionResult Update([FromForm] ProductUpdate entity, [FromForm] IList<IFormFile> listFile)
        {
            Product product = new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                IdCategory = entity.IdCategory,
                IdOrigin = entity.IdOrigin,
                Quantity = entity.Quantity,
                Note = entity.Note,
                Detail = entity.Detail,
                IdImage = entity.IdImage,
                CreateDay = entity.CreateDay,
                SoldQuantity = entity.SoldQuantity
            };
            productService.Update(product, listFile, entity.ImagesUpdate);
            if (productService.Flag)
            {
                productService.Get(entity.Id);
                return Ok(productService.ObjDetail);

            }
            else
            {
                return BadRequest(productService.Error);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public virtual IActionResult Delete(string id)
        {
            productService.Delete(id);
            if (productService.Flag)
            {
                return Ok("Xoá thành công!");
            }
            else
            {
                return BadRequest(productService.Error);
            }
        }

    }
}
