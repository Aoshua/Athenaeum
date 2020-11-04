using Athenaeum.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public interface IRepositoryWrapper
    {
        IBookInCollectionRepo BookInCollection { get; }
        IUserCollectionRepo UserCollection { get; }
        ICollectionRepo Collection { get; }
        Task SaveAsync();
    }
}
