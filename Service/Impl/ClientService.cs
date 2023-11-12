using Data.Model;
using Microsoft.EntityFrameworkCore;
using Repo;
using Service.Base;
using Service.Model;

namespace Service.Impl
{
    public class ClientService: IClientService
    {
        ClientRepository _clientRepository;
        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ClientModel Create(ClientModel _client)
        {
            Client client = _clientRepository.Create(new Client()
            {   
                Email = _client.Email,
                FirstName = _client.FirstName,
                LastName = _client.LastName,
                UserId = _client.UserId,
                AgentUserId = _client.AgentUserId,
            });
            return new ClientModel(client);
        }

        public void Delete(int Id)
        {

            _clientRepository.Delete(Id);
        }

        public IEnumerable<ClientModel> Get()
        {
            return _clientRepository
                .GetAll()
                .Select(client => new ClientModel(client)); 
        }

        public ClientModel? Get(int Id)
        {
            Client? client = _clientRepository.GetById(Id);
            if (null != client) { 
                return new ClientModel(client);
            }
            return null;
        }

        public ClientModel? Update(ClientModel _client)
        {
            Client? client = _clientRepository.Update(new Client()
            {
                Id = _client.Id,
                FirstName = _client.FirstName,
                LastName = _client.LastName,
                UserId = _client.UserId,
                Email = _client.Email,
                AgentUserId= _client.AgentUserId,
            });

            if(null != client)
            {
                return new ClientModel(client);
            }
            return null;
        }

        public ClientModel? GetClientsByUserId(int userId)
        {
            return _clientRepository
                .GetAll()
                .Where(client => client.UserId == userId)
                .Include(client => client.Policies)
                .Select(client => new ClientModel(client))
                .FirstOrDefault();
        }

        public IEnumerable<ClientModel>  GetClientsByAgentUserId(int userId)
        {
            return _clientRepository
                .GetAll()
                .Include(client => client.Policies)
                .Where(client => client.AgentUserId == userId)
                .Select(client => new ClientModel(client));
        }
    }
}
