using Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    [Table("User")]
    public class User : BaseModel<int>
    {
        //public int UserID { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public int StatusId { get; set; }
        public int UserTypeId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status? Status { get; set; }
        [ForeignKey("UserTypeId")]
        public virtual UserType? UserType { get; set; }
    }
}
