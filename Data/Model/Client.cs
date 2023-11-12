using Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    [Table("Client")]
    public class Client : BaseModel<int>
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? UserId { get; set; }
        public int AgentUserId { get; set; }
        [ForeignKey("AgentUserId")]
        public virtual User? Agent { get; set; }
        public virtual ICollection<Policy>? Policies { get; set; }
    }
}
