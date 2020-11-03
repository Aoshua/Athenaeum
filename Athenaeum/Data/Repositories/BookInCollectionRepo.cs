using Athenaeum.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public class BookInCollectionRepo : RepositoryBase<BookInCollection>, IBookInCollectionRepo
    {
        public BookInCollectionRepo(AthenaeumContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<BookInCollection>> GetBooksInCollectionAsync(int collectionId)
        {
            return await FindByCondition(book => book.CollectionId.Equals(collectionId)).ToListAsync();
        }

        public async Task<IEnumerable<BookInCollection>> GetUserBooksInCollectionAsync(int collectionId)
        {
            throw new NotImplementedException();
            //return await FindByCondition(book => book.CollectionId.Equals(collectionId))
            //    .Join()
        }

        public async Task<BookInCollection> GetBookInCollectionByIdAsync(int id)
        {
            return await FindByCondition(book => book.BookInCollectionId.Equals(id)).FirstOrDefaultAsync();
        }

        public void InsertBookInCollection(BookInCollection book)
        {
            Insert(book);
        }

        public void UpdateBookInCollection(BookInCollection book)
        {
            Update(book);
        }

        public void DeleteBookInCollection(BookInCollection book)
        {
            Delete(book);
        }
    }
}
