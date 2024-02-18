using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public class BaseService<T, TDto, TRepo > : IBaseService<T, TDto, TRepo> where T : class, new() where TDto : class, new() where TRepo : IBaseRepo<T>
    {
        public virtual T? ObjDetail { get; set; }
        public virtual List<T> ObjList { get; set; }
        public virtual TDto? ObjDetailDto { get; set; }
        public virtual List<TDto> ObjListDto { get; set; }
        public virtual bool Flag { get; set; }
        public virtual string Error { get; set; }
        public virtual TRepo ThisRepo { get; set; }

        public  readonly IMapper _mapper;
        public  BaseService(TRepo repo, IMapper mapper)
        {
            ObjDetail = new T();
            ObjList = new List<T>();
            ObjDetailDto = new TDto();
            ObjListDto = new List<TDto>();
            Flag = true;
            Error = "";
            ThisRepo = repo;
            _mapper = mapper;
        }

        public virtual void Get(string id)
        {
            try
            {            
                this.ObjDetail = ThisRepo.Get(id);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public virtual void GetDto(string id)
        {
            try
            {
                this.ObjDetailDto = _mapper.Map<TDto>(ThisRepo.Get(id));

            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public virtual void GetAll()
        {
            try
            {
                this.ObjList = ThisRepo.GetAll();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public virtual void GetAllDto()
        {
            try
            {
                this.ObjListDto = _mapper.Map<List<TDto>>(ThisRepo.GetAll());
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public virtual void Update(T entity)
        {
            try
            {
                ThisRepo.Update(entity);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public virtual void Create(T entity)
        {
            try
            {
                ThisRepo.Create(entity);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                ThisRepo.Delete(entity);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public virtual void Delete(string id)
        {
            try
            {
                ThisRepo.Delete(id);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

        public virtual void Delete(List<string> ListId)
        {
            try
            {
                ThisRepo.Delete(ListId);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }

    }
}
