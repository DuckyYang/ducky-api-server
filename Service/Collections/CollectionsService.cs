using ducky_api_server.Extensions;
using ducky_api_server.Repo.Collections;
using ducky_api_server.Repo.Documents;

namespace ducky_api_server.Service.Collections
{
    public class CollectionsService : ICollectionsService
    {
        private CollectionsRepo repo = new CollectionsRepo();
        private DocumentsRepo documentsRepo = new DocumentsRepo();
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
    }
}