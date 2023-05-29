using Esourcing.Sourcing.Entities;
using Esourcing.Sourcing.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Esourcing.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IBidRepository _bidsRepository;
        private readonly ILogger<BidsController> _logger;

        public BidsController(IBidRepository bidsRepository, ILogger<BidsController> logger)
        {
            _bidsRepository = bidsRepository;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> SendBid([FromBody] Bid bid)
        {
            await _bidsRepository.SendBid(bid);
            return Ok();
        }

        [HttpGet("GetBidsByAuctionId")]
        [ProducesResponseType(typeof(IEnumerable<Bid>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidsByAuctionId(string id) {
            IEnumerable<Bid> result = await _bidsRepository.GetBidsByAuctionId(id);
            return Ok(result);
        }

        [HttpGet("GetWinnerBid")]
        [ProducesResponseType(typeof(Bid), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bid>> GetWinnerBid(string id)
        {
            Bid result = await _bidsRepository.GetWinnerBid(id);
            return Ok(result);
        }

    }
}
