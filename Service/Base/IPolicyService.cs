using Service.Model;

namespace Service.Base
{
    public interface IPolicyService
    {
        public IEnumerable<PolicyModel> Get();
        public PolicyModel? Get(int Id);
        public void Delete(int Id);
        public PolicyModel? Update(PolicyModel _policy);
        public PolicyModel Create(PolicyModel _policy);
    }
}
