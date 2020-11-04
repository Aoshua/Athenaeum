using Athenaeum.Data.Repositories.Interfaces;
using Athenaeum.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public class UserCollectionRepo : RepositoryBase<UserCollection>, IUserCollectionRepo
    {
        public UserCollectionRepo(AthenaeumContext context)
            : base(context)
        {
        }

        public void DeleteUserCollection(UserCollection collection)
        {
            Delete(collection);
        }

        public async Task<UserCollection> GetUserCollectionByIdAsync(int userCollectionId)
        {
            return await FindByCondition(collection => collection.UserCollectionId.Equals(userCollectionId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(int userId)
        {
            return await FindByCondition(collection => collection.UserId.Equals(userId)).ToListAsync();
        }

        public void InsertUserCollection(UserCollection collection)
        {
            Insert(collection);
        }

        public void UpdateUserCollection(UserCollection collection)
        {
            Update(collection);
        }
    }
}
