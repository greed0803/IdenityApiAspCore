using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Base;
using Service.Model;
using System.Security.Claims;

namespace IdentityProviderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolicyController : ControllerBase
    {
        IPolicyService _policyService;
        IClientService _clientService;
        IUserService _userService;

        public PolicyController(IPolicyService policyService, IClientService clientService, IUserService userService)
        {
            _policyService = policyService;
            _clientService = clientService;
            _userService = userService;
        }

        [HttpGet]
        [Route("policy")]
        public IActionResult Get()
        {
            return Ok(GetClients());
        }


        private IEnumerable<ClientModel> GetClients()
        {
            ClaimsPrincipal principal = HttpContext?.User;
            IEnumerable<Claim> claims = principal.Claims;
            int userId = int.Parse(claims
                .Where(claim => "Id".Equals(claim.Type))
                .Select(claim => claim.Value)
                .First());

            if (principal.IsInRole("Admin")) {

                return _clientService.Get();
            } else if (principal.IsInRole("Agent")) {
            
                return _clientService.GetClientsByAgentUserId(userId);          
            } else {

                List<ClientModel> clients = new List<ClientModel>();
                ClientModel? clientModel = _clientService.GetClientsByUserId(userId);
                if (clientModel != null)
                {
                    clients.Add(clientModel);
                }
                return clients;
            }
        }
    }
}
