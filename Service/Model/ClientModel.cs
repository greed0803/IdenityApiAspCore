using Data.Model;
using Service.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ClientModel : BaseServiceModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? UserId { get; set; }
        public int AgentUserId { get; set; }
        public virtual UserModel? Agent { get; set; }
        public IEnumerable<PolicyModel>? Policies { get; set; }
        public ClientModel() { }
        public ClientModel(Client client) {
            Id = client.Id;
            Email = client.Email;
            FirstName = client.FirstName;
            LastName = client.LastName;
            UserId = client.UserId;
            AgentUserId = client.AgentUserId;

            if (null != client.Policies) {
                Policies = client
                    .Policies
                    .Select(p => new PolicyModel(p));

            }

            if (null != client.Agent) { 
                Agent = new UserModel(client.Agent);
            }
        }
    }
}
