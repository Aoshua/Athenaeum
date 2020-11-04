using Athenaeum.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AthenaeumContext _context;
        private IBookInCollectionRepo _bookInCollection;
        private IUserCollectionRepo _userCollection;
        private ICollectionRepo _collection;

        public RepositoryWrapper(AthenaeumContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IBookInCollectionRepo BookInCollection
        {
            get
            {
                if(_bookInCollection == null)
                {
                    _bookInCollection = new BookInCollectionRepo(_context);
                }
                return _bookInCollection;
            }
        }

        public IUserCollectionRepo UserCollection
        {
            get
            {
                if (_userCollection == null)
                {
                    _userCollection = new UserCollectionRepo(_context);
                }
                return _userCollection;
            }
        }

        public ICollectionRepo Collection
        {
            get
            {
                if(_collection == null)
                {
                    _collection = new CollectionRepo(_context);
                }
                return _collection;
            }
        }
    }
}
