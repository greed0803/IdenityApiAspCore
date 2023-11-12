using Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    [Table("Policy")]
    public class Policy: BaseModel<int>
    {
        public required string CoverageType { get; set; }
        public Double PremiumAmount { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set;}
        public int ClientId { get; set; }

        //[ForeignKey("ClientId")]
        //public virtual Client? Client { get; set; }
    }
}
