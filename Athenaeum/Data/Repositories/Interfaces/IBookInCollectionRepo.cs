using Athenaeum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public interface IBookInCollectionRepo : IRepositoryBase<BookInCollection>
    {
        Task<IEnumerable<BookInCollection>> GetBooksInCollectionAsync(int collectionId);
        Task<IEnumerable<BookInCollection>> GetUserBooksInCollectionAsync(int collectionId);
        Task<BookInCollection> GetBookInCollectionByIdAsync(int bookId);
        void InsertBookInCollection(BookInCollection book);
        void UpdateBookInCollection(BookInCollection book);
        void DeleteBookInCollection(BookInCollection book);
    }
}
