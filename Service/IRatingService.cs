using Entite;

namespace Service
{
    public interface IRatingService
    {
        Task Addrating(Rating rating);
    }
}