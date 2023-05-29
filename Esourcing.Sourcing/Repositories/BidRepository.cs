using Esourcing.Sourcing.Data.Interface;
using Esourcing.Sourcing.Entities;
using Esourcing.Sourcing.Repositories.Interface;
using MongoDB.Driver;

namespace Esourcing.Sourcing.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ISourcingContext _context;

        public BidRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task<List<Bid>> GetBidsByAuctionId(string id)
        {
            FilterDefinition<Bid> filter = Builders<Bid>.Filter.Eq(a => a.AuctionId, id);
            List<Bid> bids = await _context.Bids.Find(filter).ToListAsync();
            bids = bids.OrderByDescending(a => a.CreatedAt).GroupBy(c => c.SellerUserName)
                .Select(a => new Bid
                {
                    AuctionId = a.FirstOrDefault().AuctionId,
                    ProductId = a.FirstOrDefault().ProductId,
                    Price = a.FirstOrDefault().Price,
                    CreatedAt = a.FirstOrDefault().CreatedAt,
                    Id = a.FirstOrDefault().Id,
                    SellerUserName = a.FirstOrDefault().SellerUserName
                }).ToList();
            return bids;
        }

        public async Task<Bid> GetWinnerBid(string id)
        {
            List<Bid> bids = await GetBidsByAuctionId(id);
            return bids.OrderByDescending(x=>x.Price).FirstOrDefault();
        }

        public async Task SendBid(Bid bid)
        {
            await _context.Bids.InsertOneAsync(bid);
        }
    }
}
