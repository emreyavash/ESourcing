using Esourcing.Sourcing.Entities;

namespace Esourcing.Sourcing.Repositories.Interface
{
    public interface IBidRepository
    {
        Task SendBid(Bid bid);
        Task<List<Bid>> GetBidsByAuctionId(string id);
        Task<Bid> GetWinnerBid(string id);
    }
}
