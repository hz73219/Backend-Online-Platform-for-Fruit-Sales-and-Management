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
    public class OrderService : BaseService<Order, OrderDto, IOrderRepo>, IOrderService
    {
        public IVoucherRepo voucherRepo;
        public IProductRepo productRepo;
        public OrderService(IOrderRepo repo, IMapper mapper, IVoucherRepo IVoucherRepo, IProductRepo IProductRepo) : base(repo, mapper)
        {
            this.voucherRepo = IVoucherRepo;
            this.productRepo = IProductRepo;
        }
        public override void Create(Order entity)
        {
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.Status = 1;
                entity.CreateDay = DateTime.Now;
                entity.TotalPrice = 0;
                foreach (var orderDetail in entity.ListOrderDetail)
                {
                    orderDetail.IdOrder = entity.Id;
                    orderDetail.Id = Guid.NewGuid().ToString();
                    var product = productRepo.Get(orderDetail.IdProduct);
                    orderDetail.Price = product.Price;
                    entity.TotalPrice += orderDetail.Price * orderDetail.Quantity;
                    product.SoldQuantity = orderDetail.Quantity;
                    productRepo.Update(product);
                }
                
                Voucher voucher = voucherRepo.Get(entity.IdVoucher);
                entity.PriceDiscount = entity.TotalPrice;
                if (voucher != null)
                {
                    entity.PriceDiscount = entity.TotalPrice - (entity.TotalPrice * voucher.Discount) / 100;
                    voucher.isUse = true;
                    voucherRepo.Update(voucher);
                }
                ThisRepo.Create(entity);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
    }
}
