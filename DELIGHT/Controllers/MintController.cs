using DELIGHT.Core.Application.Dtos.Mint;
using DELIGHT.Core.Application.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace DELIGHT.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MintController : ControllerBase
    {
        private readonly ILogger<MintController> _logger;
        private readonly IMintService _mintService;
        public MintController(ILogger<MintController> logger, IMintService mintService)
        {
            _logger = logger;
            _mintService = mintService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMints(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching all mints.");
                var mints = await _mintService.GetAllMintsAsync(cancellationToken);
                _logger.LogInformation("Successfully fetched {Count} mints.", mints.Count);
                return Ok(mints);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching mints.");
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMintById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching mint with ID: {Id}", id);
                var mint = await _mintService.GetMintByIdAsync(id, cancellationToken);
                if (mint == null)
                {
                    _logger.LogWarning("Mint with ID: {Id} not found.", id);
                    return NotFound();
                }
                _logger.LogInformation("Successfully fetched mint with ID: {Id}", id);
                return Ok(mint);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching mint with ID: {Id}", id);
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateMint([FromBody] CreateMint dto, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Creating a new mint.");
                var result = await _mintService.CreateMintAsync(dto, cancellationToken);
                _logger.LogInformation("Successfully created a new mint with result: {Result}", result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new mint.");
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMint(Guid id, [FromBody] UpdateMint dto, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Updating mint with ID: {Id}", id);
                var result = await _mintService.UpdateMintAsync(id, dto, cancellationToken);
                _logger.LogInformation("Successfully updated mint with ID: {Id} with result: {Result}", id, result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating mint with ID: {Id}", id);
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMint(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Deleting mint with ID: {Id}", id);
                var result = await _mintService.DeleteMintAsync(id, cancellationToken);
                _logger.LogInformation("Successfully deleted mint with ID: {Id} with result: {Result}", id, result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting mint with ID: {Id}", id);
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }
    }
}
