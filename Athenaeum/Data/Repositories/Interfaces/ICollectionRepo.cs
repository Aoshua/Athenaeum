using Athenaeum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories.Interfaces
{
    public interface ICollectionRepo : IRepositoryBase<Collection>
    {
        Task<IEnumerable<Collection>> GetCollectionsAsync();
        Task<Collection> GetCollectionById(int collectionId);
        void InsertCollection(Collection collection);
        void UpdateCollection(Collection collection);
        void DeleteCollection(Collection collection);
    }
}
