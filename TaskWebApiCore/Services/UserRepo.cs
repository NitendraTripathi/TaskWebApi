using Microsoft.EntityFrameworkCore;
using TaskWebApiCore.Data;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Services
{
    public class UserRepo : IUserRepo
    {


        public TaskDbContext _DbContext { get; }

        public UserRepo(TaskDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        //public User Loginuser(User usr)
        //{
        //    var user= _DbContext.users.Where(x=> x.username== usr.username && x.password==usr.password ).FirstOrDefault();
        //    if (user != null) {
        //    return user;
        //    }
        //    else
        //    {
        //        return null;
        //    }
             
        //}
        public async Task<User> Loginuser(User usr)
        {
            var user =await _DbContext.users.Where(x => x.username == usr.username && x.password == usr.password).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public User AddUser(User usr)
        {
            _DbContext.users.Add(usr);
            _DbContext.SaveChanges();

            return usr;

        }

        public User UpdateUser(User usr)
        {


            _DbContext.users.Update(usr);
            _DbContext.SaveChanges();

            return usr;


        }
        public List<User> GetUsers()
        {
            var users = _DbContext.users.ToList();
            return users;
        }

        public User GetUserById(int usrId)
        {
            var user = _DbContext.users.Where(x => x.id == usrId).FirstOrDefault();
            return user;
        }


        public void DeleteUser(int usrid)
        {
            var user = _DbContext.users.Where(x => x.id == usrid).FirstOrDefault();

            if (user != null)
            {
                _DbContext.users.Remove(user);
                _DbContext.SaveChanges();
            }



        }
    }
}
