using Karimaneh.Application.Features.Wallets.DTOs;
using Karimaneh.Application.Features.Wallets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karimaneh.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Policy = "Accessibility")]
    public class WalletsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Wallets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletResponseDto>>> GetWallets(CancellationToken cancellationToken, int limit = 25, int offset = 0)
        {
            var wallets = await _mediator.Send(new GetAllWalletsQuery { Limit = limit, Offset = offset }, cancellationToken);
            return Ok(wallets);
        }

        // GET: api/Wallets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WalletResponseDto>> GetWallet(Guid id, CancellationToken cancellationToken)
        {
            var wallet = await _mediator.Send(new GetWalletByIdQuery { Id = id }, cancellationToken);

            if (wallet == null)
            {
                return NotFound();
            }

            return Ok(wallet);
        }
    }
}
