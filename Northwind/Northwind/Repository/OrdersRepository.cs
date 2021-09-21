using AquariumService.Abstractions;
using NorthwindService.Models;

namespace NorthwindService.Repository
{
    public class OrdersRepository : GenericRepository<Order>
    {
        public OrdersRepository(NorthwindContext context) : base(context)
        {

        }
    }
}
