using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DNPblazorAssignment.Data
{
    public interface IAdultService
    {
        
        Task AddAdult(Adult adult);
        Task RemoveAdult(int id);
        Task UpdateAdult(Adult adult);
        Task<Adult> GetAdult(int id);
        Task<IList<Adult>> GetAll();
    }
}