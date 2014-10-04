using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public interface IRepository
    {
        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetAllOrdersWithDetails();
        Order GetOrder(int id);
    }
}
