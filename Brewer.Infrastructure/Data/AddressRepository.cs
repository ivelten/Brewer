using Brewer.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Brewer.Infrastructure.Data
{
    public class AddressRepository : Repository<Address, int>
    {
        public AddressRepository(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}