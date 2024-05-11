using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Services
{
    public interface IUserServices
    {
        int UserRegistration(Users user);
        Users LoginAuthentication(Users user);
        int ForgetPassword(Users user);

        int UpdatePassword(Users users);





    }
}
