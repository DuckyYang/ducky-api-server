namespace ducky_api_server.Service.Collections
{
    public interface ICollectionsService
    {
        bool AddRequest(string collectionId, string name);
        bool Rename(string id,string name);
        bool Remove(string id);
    }
}