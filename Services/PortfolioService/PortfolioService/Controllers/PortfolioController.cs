using Microsoft.AspNetCore.Mvc;
using PortfolioService.Service;
using PortfolioService.Service.Interfaces;

namespace PortfolioService.API.Controllers
{
    [ApiController]
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly PortfolioManager _portfolioManager;

        public PortfolioController(IPortfolioManager portfolioManager)
        {
            _portfolioManager = (PortfolioManager?)portfolioManager;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserPortfolio(int userId)
        {
            var portfolio = await _portfolioManager.GetUserPortfolioAsync(userId);
            return Ok(portfolio);
        }
    }
}
