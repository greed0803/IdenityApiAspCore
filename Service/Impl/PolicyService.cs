using Data.Model;
using Repo;
using Service.Base;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class PolicyService : IPolicyService
    {
        PolicyRepository _policyRepository;
        public PolicyService(PolicyRepository policyRepository) {

            _policyRepository = policyRepository;
        }
        public PolicyModel Create(PolicyModel _policy)
        {
            Policy policy = _policyRepository.Create(new Policy() { 
               PremiumAmount = _policy.PremiumAmount,
               CoverageType = _policy.CoverageType,
               PolicyEndDate = _policy.PolicyEndDate,
               PolicyStartDate = _policy.PolicyStartDate,
               ClientId = _policy.ClientId,
            });
            return new PolicyModel(policy);
        }
        public void Delete(int Id)
        {
            _policyRepository.Delete(Id);
        }
        public IEnumerable<PolicyModel> Get()
        {
            return _policyRepository
                .GetAll()
                .Select(x => new PolicyModel(x));
        }
        public PolicyModel? Get(int Id)
        {
            Policy? policy = _policyRepository.GetById(Id);
            if (null !=  policy)
            {
                return new PolicyModel(policy);
            }
            return null;
        }
        public PolicyModel? Update(PolicyModel _policy)
        {
            Policy? policy = _policyRepository.Update(new Policy()
            {
                Id = _policy.Id,
                ClientId = _policy.ClientId,
                CoverageType = _policy.CoverageType,
                PolicyEndDate = _policy.PolicyEndDate,
                PolicyStartDate = _policy.PolicyStartDate,
                PremiumAmount= _policy.PremiumAmount
            });
            if (null != policy)
            {
                return new PolicyModel(policy);
            }
            return null;
        }
    }
}
