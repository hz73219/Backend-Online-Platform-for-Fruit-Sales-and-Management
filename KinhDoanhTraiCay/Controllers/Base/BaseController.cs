using Microsoft.AspNetCore.Mvc;
using Repository.Base;
using Service.Base;

namespace KinhDoanhTraiCay.Controllers.Base
{
    public  class BaseController<T, TDto, TRepo, TService> : Controller where T : class where TDto : class where TRepo : IBaseRepo<T> where TService : IBaseService<T, TDto, TRepo>
    {
        public readonly TService _Service;
        public BaseController(TService baseService)
        {
            _Service = baseService;
        }
        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {
            _Service.Get(id);
            if (_Service.Flag)
            {
                if (null == _Service.ObjDetail)
                {
                    return NotFound();
                }
                return Ok(_Service.ObjDetail);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            _Service.GetAll();
            if (_Service.Flag)
            {
                return Ok(_Service.ObjList);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpGet("{id}")]
        public virtual IActionResult GetDto(string id)
        {
            _Service.GetDto(id);
            if (_Service.Flag)
            {
                if(null==_Service.ObjDetailDto)
                {                   
                    return NotFound();
                }
                return Ok(_Service.ObjDetailDto);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpGet]
        public virtual IActionResult GetAllDto()
        {
            _Service.GetAllDto();
            if (_Service.Flag)
            {
                return Ok(_Service.ObjListDto);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpPost]
        public virtual IActionResult Create(T entity)
        {
            _Service.Create(entity);
            if (_Service.Flag)
            {
                return  Ok(entity);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpPut]
        public virtual IActionResult Update(T entity)
        {
            _Service.Update(entity);
            if (_Service.Flag)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
        [HttpDelete]
        public virtual IActionResult Delete(string id)
        {
            _Service.Delete(id);
            if (_Service.Flag)
            {
                return Ok();
            }
            else
            {
                return BadRequest(_Service.Error);
            }
        }
     
    }
}
