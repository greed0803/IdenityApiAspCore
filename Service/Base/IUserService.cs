using Service.Model;

namespace Service.Base
{
    public interface IUserService 
    {
        public UserModel? Authenticate(LoginModel loginModel);
        public IEnumerable<UserModel> GetAll();
        public UserModel? GetById(int id);
    }
}
