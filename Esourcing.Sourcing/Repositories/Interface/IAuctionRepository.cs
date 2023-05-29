using Esourcing.Sourcing.Entities;

namespace Esourcing.Sourcing.Repositories.Interface
{
    public interface IAuctionRepository
    {
        Task Create(Auction auction);
        Task<bool> Delete(string id);
        Task<bool> Update(Auction auction);
        Task<IEnumerable<Auction>> GetAllAuctions();
        Task<Auction> GetAuctionById(string id);
        Task<Auction> GetAuctionByName(string name);
    }
}
