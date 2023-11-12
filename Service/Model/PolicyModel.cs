using Data.Model;
using Service.Model.Base;
namespace Service.Model
{
    public class PolicyModel : BaseServiceModel
    {
        public int Id { get; set; }
        public string CoverageType { get; set; }
        public Double PremiumAmount { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public int ClientId { get; set; }
        public ClientModel? Client { get; set; }

        public PolicyModel() { }
        public PolicyModel(Policy policy)
        {
            Id = policy.Id; 
            CoverageType = policy.CoverageType;
            PremiumAmount = policy.PremiumAmount;
            PolicyStartDate = policy.PolicyStartDate;
            PolicyEndDate = policy.PolicyEndDate;
            ClientId = policy.ClientId;
            //if (policy.Client != null)
            //{
            //    Client = new ClientModel(policy.Client);
            //}
        }
    }
}
