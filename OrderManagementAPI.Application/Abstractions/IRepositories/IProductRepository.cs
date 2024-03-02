using OrderManagementAPI.Domen.Entites.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementAPI.Application.Abstractions.IRepositories
{
    public interface IProductRepository:IBaseRepository<ProductModel>
    {
    }
}
