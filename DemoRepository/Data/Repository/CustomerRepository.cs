using DemoRepository.Data.Interface;
using DemoRepository.Data.Model;

namespace DemoRepository.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}