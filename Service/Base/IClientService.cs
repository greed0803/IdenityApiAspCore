using Service.Model;

namespace Service.Base
{
    public interface IClientService
    {
        public IEnumerable<ClientModel> Get();
        public ClientModel? Get(int Id);
        public void Delete(int Id);
        public ClientModel? Update(ClientModel _client);
        public ClientModel Create(ClientModel _client);
        public ClientModel? GetClientsByUserId(int userId);
        public IEnumerable<ClientModel> GetClientsByAgentUserId(int userId);
    }
}
