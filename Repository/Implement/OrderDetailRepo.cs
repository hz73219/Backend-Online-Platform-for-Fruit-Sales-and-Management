﻿using Model.Entities;
using Repository.Base;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class OrderDetailRepo : BaseRepo<OrderDetail>, IOrderDetailRepo
    {
        public OrderDetailRepo(FruitContext context) : base(context)
        {
        }
    }
}
