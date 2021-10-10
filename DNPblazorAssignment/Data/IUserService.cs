using Models;

namespace DNPblazorAssignment.Data
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
    }
}