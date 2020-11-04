using Athenaeum.Data.Repositories.Interfaces;
using Athenaeum.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public class CollectionRepo : RepositoryBase<Collection>, ICollectionRepo
    {
        public CollectionRepo(AthenaeumContext context)
            : base(context)
        {
        }

        public void DeleteCollection(Collection collection)
        {
            Delete(collection);
        }

        public async Task<Collection> GetCollectionById(int collectionId)
        {
            return await FindByCondition(collection => collection.CollectionId.Equals(collectionId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Collection>> GetCollectionsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public void InsertCollection(Collection collection)
        {
            Insert(collection);
        }

        public void UpdateCollection(Collection collection)
        {
            Update(collection);
        }
    }
}
