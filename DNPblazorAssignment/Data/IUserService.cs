using System.Threading.Tasks;
using Models;

namespace DNPblazorAssignment.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}