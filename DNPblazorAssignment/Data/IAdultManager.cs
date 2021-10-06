using System.Collections.Generic;
using Models;

namespace DNPblazorAssignment.Data
{
    public interface IAdultManager
    {
        
        void AddAdult(Adult adult);
        void RemoveAdult(int id);
        void UpdateAdult(Adult adult);
        Adult GetAdult(int id);
        IList<Adult> GetAll();
    }
}