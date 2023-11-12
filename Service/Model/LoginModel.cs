using Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class LoginModel: BaseServiceModel
    {
        public required String Email { get; set; }   
        public required String Password { get; set; }
    }
}
