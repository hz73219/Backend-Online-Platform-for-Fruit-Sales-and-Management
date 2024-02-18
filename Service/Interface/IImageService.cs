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
    public interface IImageService : IBaseService<Image, ImageDto, IImageRepo>
    {
    }
}
