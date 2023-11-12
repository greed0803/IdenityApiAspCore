using Data.Model;

namespace Service.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
        public int UserTypeId { get; set; }
        public Status? Status { get; set; }
        public UserType? UserType { get; set; }

        public UserModel() { }
        public UserModel(User user) {
            UserName = user.UserName;
            Id = user.Id;
            Status = user.Status;
            StatusId = user.StatusId;
            UserType = user.UserType;
            UserTypeId = user.UserTypeId;
            Email = user.Email;
        }
    }
}
