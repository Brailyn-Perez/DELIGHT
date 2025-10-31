using DELIGHT.Core.Application.Dtos.Mint;
using DELIGHT.Core.Application.Interface.Repositories;
using DELIGHT.Core.Application.Interface.Services;
using DELIGHT.Core.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DELIGHT.Core.Application.Services
{
    public class MintService : IMintService
    {
        private readonly IMintRepository _mintRepository;
        private readonly ILogger<MintService> _logger;
        public MintService(IMintRepository mintRepository, ILogger<MintService> logger)
        {
            _mintRepository = mintRepository;
            _logger = logger;
        }
        public async Task<int> CreateMintAsync(CreateMint dto, CancellationToken cancellationToken)
        {
            try
            {
                await _mintRepository.AddAsync(new Mint
                {
                    Name = dto.Name,
                    Country = dto.Country,
                    SugarContent = dto.SugarContent,
                    Flavor = dto.Flavor,
                    WeightInGrams = dto.WeightInGrams,
                    Price = dto.Price,
                    PricePerUnit = dto.PricePerUnit
                }, cancellationToken);

                return await _mintRepository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new mint.");
                throw;
            }
        }

        public async Task<int> DeleteMintAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await _mintRepository.DeleteAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting a mint.");
                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<List<MintResponse>> GetAllMintsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var mints = await _mintRepository.GetAllAsync(cancellationToken);
                return mints.Select(m => new MintResponse
                {
                    Id = m.Id,
                    Name = m.Name,
                    Country = m.Country,
                    SugarContent = m.SugarContent,
                    Flavor = m.Flavor,
                    WeightInGrams = m.WeightInGrams,
                    Price = m.Price,
                    PricePerUnit = m.PricePerUnit
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all mints.");
                throw;
            }
        }

        public async Task<MintResponse> GetMintByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var mint = await _mintRepository.GetByIdAsync(id, cancellationToken);
                if (mint == null) return null;

                return new MintResponse
                {
                    Id = mint.Id,
                    Name = mint.Name,
                    Country = mint.Country,
                    SugarContent = mint.SugarContent,
                    Flavor = mint.Flavor,
                    WeightInGrams = mint.WeightInGrams,
                    Price = mint.Price,
                    PricePerUnit = mint.PricePerUnit
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving a mint by ID.");
                throw;
            }
        }

        public async Task<int> UpdateMintAsync(Guid id, UpdateMint dto, CancellationToken cancellationToken)
        {
            try
            {
                var mint = await _mintRepository.GetByIdAsync(id, cancellationToken);
                if (mint == null) return 0;

                mint.Name = dto.Name;
                mint.Country = dto.Country;
                mint.SugarContent = dto.SugarContent;
                mint.Flavor = dto.Flavor;
                mint.WeightInGrams = dto.WeightInGrams;
                mint.Price = dto.Price;
                mint.PricePerUnit = dto.PricePerUnit;

                await _mintRepository.UpdateAsync(mint, cancellationToken);
                return await _mintRepository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating a mint.");
                throw;
            }
        }
    }
}
