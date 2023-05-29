using Esourcing.Sourcing.Data.Interface;
using Esourcing.Sourcing.Entities;
using Esourcing.Sourcing.Repositories.Interface;
using MongoDB.Driver;

namespace Esourcing.Sourcing.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISourcingContext _context;

        public AuctionRepository(ISourcingContext context)
        {
            _context = context;
        }

        public async Task Create(Auction auction)
        {
            await _context.Auctions.InsertOneAsync(auction);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(x=>x.Id,id);
            DeleteResult deleteResult = await _context.Auctions.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount> 0;
        }

        public async Task<IEnumerable<Auction>> GetAllAuctions()
        {
            var result = await _context.Auctions.Find(x=>true).ToListAsync();
            return result;
        }

        public async Task<Auction> GetAuctionById(string id)
        {
            var result = await _context.Auctions.Find(x=>x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Auction> GetAuctionByName(string name)
        {
            FilterDefinition<Auction> filter = Builders<Auction>.Filter.Eq(x => x.Name, name);
            var result = await _context.Auctions.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Auction auction)
        {
            var updateAuction = await _context.Auctions.ReplaceOneAsync(filter: x => x.Id == auction.Id, replacement: auction);
            return updateAuction.IsAcknowledged && updateAuction.ModifiedCount > 0;
        }
    }
}
