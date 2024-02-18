using Microsoft.AspNetCore.Http;
using Model.Entities;
using Repository.Implement;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService :IBaseService<Product,ProductDto,IProductRepo>
    {
        public Result result { get; set; }
        public void Create(Product entity, IList<IFormFile> listFile);
        public void Update(Product entity, IList<IFormFile> listFile, List<Image> listFileDelete);
        public void GetListNewProduct();
        public void getListTypeProduct(Search search);


    }
}
