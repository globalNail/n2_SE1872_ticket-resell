﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        int GetMaxId();
        Task<string?> GetLatestOrderStatusByMemberAsync(int buyerId);
    }
}
