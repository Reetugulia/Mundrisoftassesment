using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Repositories
{
    public interface IUserRepository
    {

        int UserRegistration(Users user);
        Users LoginAuthentication(Users user);
        int ForgetPassword(Users user);

        Users FindUserByEmail(string email);
        int UpdatePassword(Users user);
        
    }
}
