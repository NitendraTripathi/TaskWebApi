using TaskWebApiCore.Data;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Services
{
    public interface IUserRepo
    {
        TaskDbContext _DbContext { get; }
        Task<User> Loginuser(User usr);
        User AddUser(User usr);
        void DeleteUser(int usrid);
        List<User> GetUsers();
        User GetUserById(int usrId);
        User UpdateUser(User usr);
    }
}