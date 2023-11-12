using Data.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("Status")]
    public class Status : BaseModel<int>
    {
        public required string Desc { get; set; }
    }
}
