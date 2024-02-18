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
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailDto, IOrderDetailRepo>, IOrderDetailService
    {
        public OrderDetailService(IOrderDetailRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
