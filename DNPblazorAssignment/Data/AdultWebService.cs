using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DNPblazorAssignment.Data
{
    public class AdultWebService : IAdultService
    {
        public Task AddAdult(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAdult(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAdult(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public Task<Adult> GetAdult(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Adult>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}