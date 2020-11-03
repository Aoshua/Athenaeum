using System.Threading.Tasks;

namespace Athenaeum.Data.Repositories
{
    public interface IRepositoryWrapper
    {
        IBookInCollectionRepo BookInCollection { get; }
        Task SaveAsync();
    }
}
