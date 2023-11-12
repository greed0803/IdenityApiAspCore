using Data.Context;
using Data.Model;
using Repo;
using Service.Base;
using Service.Model;

namespace Service.Impl
{

    public class UserService : IUserService
    {
        
        UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _repository
                .GetAll()
                .Select(user => new UserModel() { 
                    UserName = user.UserName, 
                    Id = user.Id,
                    Status = user.Status,
                    StatusId = user.StatusId,   
                    UserType = user.UserType,   
                    UserTypeId = user.UserTypeId,
                });
        }

        public UserModel? GetById(int id)
        {
            User? user = _repository.GetById(id);
            if (user != null) {
                return new UserModel()
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    Status = user.Status,
                    StatusId = user.StatusId,
                    UserType = user.UserType,
                    UserTypeId = user.UserTypeId,
                    Email = user.Email,
                };
            }
            return null;
        }

        public UserModel? Authenticate(LoginModel loginModel) {
            return _repository
                .GetAll()
                ?.Where(x => x.StatusId == 1)
                ?.Where(x => x.Email.Equals(loginModel.Email))
                ?.Where(x => x.Password.Equals(loginModel.Password))
                ?.Select(user => new UserModel(user)
                {
                    UserName = user.UserName,
                    Id = user.Id,
                    Status = user.Status,
                    StatusId = user.StatusId,
                    UserType = user.UserType,
                    UserTypeId = user.UserTypeId,
                    Email = user.Email,
                }).FirstOrDefault();
        }
    }
}
