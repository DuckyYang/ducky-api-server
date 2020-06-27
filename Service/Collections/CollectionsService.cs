using ducky_api_server.Extensions;
using ducky_api_server.Repo.Collections;
using ducky_api_server.Repo.Request;

namespace ducky_api_server.Service.Collections
{
    public class CollectionsService : ICollectionsService
    {
        private CollectionsRepo repo = new CollectionsRepo();
        private RequestRepo documentsRepo = new RequestRepo();
        public bool AddRequest(string collectionId, string name)
        {
            if (collectionId.IsEmpty() || name.IsEmpty())
            {
                return false;
            }
            var collection = repo.Get(collectionId);
            if (collection.IsNull())
            {
                return false;
            }
            return documentsRepo.AddRequest(collectionId, name);
        }
        public bool Rename(string id,string name)
        {
            return repo.Rename(id,name);
        }
        public bool Remove(string id)
        {
            if(repo.Remove(id))
            {
                documentsRepo.RemoveDocumentByCollectionID(id);
                return true;
            }
            return false;
        }
    }
}