using AutoMapper;
using Model.Entities;
using Repository.Implement;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using Service.Helper;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class ImageService : BaseService<Image, ImageDto, IImageRepo>, IImageService
    {
        public ImageService(IImageRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
        //delete product
        public override void Delete(string id)
        {
            try
            {
                var imageDeletes = ThisRepo.GetImagesByParent(id);
                foreach (var image in imageDeletes)
                {
                    ServiceImage.deleteImage(image.Path);
                    base.Delete(image.Id);
                }          
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        //update product
        public override void Delete(Image item)
        {
            try
            {
                ServiceImage.deleteImage(item.Path);
                base.Delete(item.Id);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
    }
}
