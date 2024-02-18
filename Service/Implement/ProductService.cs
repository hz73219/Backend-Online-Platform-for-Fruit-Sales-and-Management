using AutoMapper;
using Microsoft.AspNetCore.Http;
using Model.Entities;
using Repository.Implement;
using Repository.Interface;
using Service.Base;
using Service.Helper;
using Service.DTO;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class ProductService : BaseService<Product, ProductDto, IProductRepo>, IProductService
    {
        public readonly IImageService imageService;
        public readonly IProductRepo productRepo;
        public Result result { get; set; }

        public ProductService(IProductRepo repo, IMapper mapper, IImageService imageService) : base(repo, mapper)
        {
            this.imageService = imageService;
            this.productRepo = repo;
            result = new Result();
        }
        public void Create(Product entity, IList<IFormFile> listFile)
        {
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.CreateDay = DateTime.Now;
                entity.IdImage = Guid.NewGuid().ToString();
                base.Create(entity);
                foreach (var item in listFile)
                {   
                    string path = ServiceImage.createImage(item);
                    if (!string.IsNullOrEmpty(path))
                    {
                        var image = new Image();
                        image.Id = Guid.NewGuid().ToString();
                        image.Name_Old = item.FileName;
                        image.Path = path;
                        image.Parent = entity.IdImage;
                        imageService.Create(image);
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public void Update(Product entity, IList<IFormFile> listFile, List<Image> listFileDelete)
        {
            try
            {
                base.Update(entity);
                foreach (var item in listFileDelete)
                {
                    imageService.Delete(item);
                }
                foreach (var item in listFile)
                {
                    string path = ServiceImage.createImage(item);
                    if (!string.IsNullOrEmpty(path))
                    {
                        var image = new Image();
                        image.Id = Guid.NewGuid().ToString();
                        image.Name_Old = item.Name;
                        image.Path = path;
                        image.Parent = entity.IdImage;
                        imageService.Create(image);
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public override void Delete(string id)
        {
            try
            {
                this.Get(id);
                string parent = this.ObjDetail.IdImage;
                imageService.Delete(parent);               
                base.Delete(id);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public void GetListNewProduct()
        {
            try
            {
              this.ObjList = productRepo._dbSet.OrderByDescending(x => x.CreateDay).ToList();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public void getListTypeProduct(Search search)
        {
            try
            {
                var query = productRepo._dbSet.AsQueryable();

                if (null== search)
                {
                    var rowCount = query.Count();
                    var result = query.Skip(0).Take(10).ToList();
                    this.result.MaxPage = (int)Math.Ceiling((double)rowCount / 10);
                    this.result.Products = result;
                }    
                else
                {
                    if(search.Page<=0)
                    {
                        search.Page = 1;
                    }    
                    if (!string.IsNullOrEmpty(search.Name))
                    {
                        query = query.Where(x => x.Name.Contains(search.Name));
                    }
                    if (search.PriceProduct == "maxtomin")
                    {
                        query = query.OrderByDescending(x => x.Price);
                    }
                    if (search.PriceProduct == "mintomax")
                    {
                        query = query.OrderBy(x => x.Price);
                    }
                    if (search.MostProduct)
                    {
                        query = query.OrderByDescending(x => x.SoldQuantity);
                    }
                    if (search.NewProduct)
                    {
                        query = query.OrderByDescending(x => x.CreateDay);
                    }
                    if (search.MaxPrice > 0)
                    {
                        query = query.Where(x => x.Price <= search.MaxPrice);
                    }
                    if (search.MinPrice > 0)
                    {
                        query = query.Where(x => x.Price >= search.MinPrice);
                    }
                    if (!string.IsNullOrEmpty(search.Origin))
                    {
                        query = query.Where(x => x.IdOrigin == search.Origin);
                    }
                    if (!string.IsNullOrEmpty(search.Category))
                    {
                        query = query.Where(x => x.IdCategory == search.Category);
                    }
                    var rowCount = query.Count();
                    int startIndex = search.PageSize * (search.Page - 1);
                    var result = query.Skip(startIndex).Take(search.PageSize).ToList();
                    this.result.MaxPage = (int)Math.Ceiling((double)rowCount / search.PageSize);
                    this.result.Products = result;
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
