using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AthenaeumContext _context;
        private IBookInCollectionRepo _bookInCollection;

        public RepositoryWrapper(AthenaeumContext context)
        {
            _context = context;
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

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
