using Entite;

namespace Repository
{
    public interface IRatingRepository
    {
        Task AddOrder(Rating raiting);
    }
}