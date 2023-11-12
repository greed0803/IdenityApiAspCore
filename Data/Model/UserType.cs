using Data.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("UserType")]
    public class UserType: BaseModel<int>
    {
      //  public int UserTypeId { get; set; }
        public required String Desc { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual required Status Status { get; set; }
    }
}
