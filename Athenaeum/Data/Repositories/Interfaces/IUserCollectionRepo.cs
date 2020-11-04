using Athenaeum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories.Interfaces
{
    public interface IUserCollectionRepo : IRepositoryBase<UserCollection>
    {
        Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(int userId);
        Task<UserCollection> GetUserCollectionByIdAsync(int userCollectionId);
        void InsertUserCollection(UserCollection collection);
        void UpdateUserCollection(UserCollection collection);
        void DeleteUserCollection(UserCollection collection);
    }
}
