using AquariumService.Abstractions;
using NorthwindService.Models;

namespace NorthwindService.Repository
{
    public class CustomersRepository : GenericRepository<Customer>
    {
        public CustomersRepository(NorthwindContext context) : base(context)
        {

        }
    }
}
