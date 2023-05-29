using Esourcing.Sourcing.Entities;
using MongoDB.Driver;

namespace Esourcing.Sourcing.Data
{
    public class SourcingContextSeed
    {

        public static void SeedData(IMongoCollection<Auction> mongoCollection)
        {
            bool exist = mongoCollection.Find(x => true).Any();
            if (!exist)
            {
                mongoCollection.InsertManyAsync(GetPreconfiguredAuction());
            }

        }

        private static IEnumerable<Auction> GetPreconfiguredAuction()
        {
            return new List<Auction>()
            {
                new Auction
                {
                    Name = "Auction1",
                    Description ="Auction1",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId="56421234561231aa5648",
                    IncludeSellers =new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 1,
                    Status = (int)Status.Active
                },
                new Auction
                {
                    Name = "Auction2",
                    Description ="Auction2",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId="56421234561231aa5649",
                    IncludeSellers =new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 1,
                    Status = (int)Status.Active
                },
                 new Auction
                {
                    Name = "Auction3",
                    Description ="Auction3",
                    CreatedAt = DateTime.Now,
                    StartedAt = DateTime.Now,
                    FinishedAt = DateTime.Now.AddDays(10),
                    ProductId="56421234561231aa5640",
                    IncludeSellers =new List<string>()
                    {
                        "seller1@test.com",
                        "seller2@test.com",
                        "seller3@test.com",
                    },
                    Quantity = 1,
                    Status = (int)Status.Active
                }

            };
        }
    }
}
