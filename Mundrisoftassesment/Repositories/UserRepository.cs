using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Mundrisoftassesment.Data;
using Mundrisoftassesment.Models;
using NuGet.Common;

namespace Mundrisoftassesment.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db=db;
        }
       
        public Users LoginAuthentication(Users user)
        {
            Users ur=new Users();
            ur=_db.Users.Where(x=>x.EmailId==user.EmailId).FirstOrDefault();
            return ur;
        }
       

        public int UserRegistration(Users user)
        {
            user.RoleId = 2;
            _db.Users.Add(user);
            int regs = _db.SaveChanges();
            return regs;
        }
        public int ForgetPassword(Users user)
        {
            int result = 0;
            var ur = _db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (ur != null)
            {
                ur.Password = user.Password;
                result = _db.SaveChanges();
            }
            return result;

        }

        public Users FindUserByEmail(string email)
        {
            var user = _db.Users.Where(x => x.EmailId ==email).FirstOrDefault();
            return user;

        }
       
        public int UpdatePassword(Users user)
        {
            int res = 0;
            var u = _db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (u != null)
            {
                u.Password = user.Password;
                res = _db.SaveChanges();
            }
            return res;
        }
    }

}
