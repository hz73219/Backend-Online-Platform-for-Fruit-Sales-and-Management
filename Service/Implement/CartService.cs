using AutoMapper;
using Model.Entities;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class CartService : BaseService<Cart, CartDto, ICartRepo>, ICartService
    {
        public CartService(ICartRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
        public void AddCart(Cart cart)
        {
            try
            {
                this.ObjDetail = this.ThisRepo._dbSet.FirstOrDefault(x => x.IdProduct == cart.IdProduct && x.IdUser == cart.IdUser);
                if (this.ObjDetail != null)
                {
                    this.ObjDetail.Quantity += cart.Quantity;
                    ThisRepo.Update(this.ObjDetail);
                }
                else
                {
                    ThisRepo.Create(cart);
                }
            }
            catch (Exception ex)
            {

                Error = ex.Message;
                Flag = false;
            }

        }
        public void GetByIdUser(string id)
        {
            try
            {
                this.ObjList = this.ThisRepo._dbSet.Where(x => x.IdUser == id).ToList();

            }
            catch (Exception ex)
            {

                Error = ex.Message;
                Flag = false;
            }
        }
    }
}
