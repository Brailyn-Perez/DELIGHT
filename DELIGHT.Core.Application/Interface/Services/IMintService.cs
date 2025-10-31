using DELIGHT.Core.Application.Dtos.Mint;

namespace DELIGHT.Core.Application.Interface.Services
{
    public interface IMintService
    {
        Task<int> CreateMintAsync(CreateMint dto, CancellationToken cancellationToken);
        Task<int> UpdateMintAsync(Guid id, UpdateMint dto, CancellationToken cancellationToken);
        Task<int> DeleteMintAsync(Guid id, CancellationToken cancellationToken);
        Task<MintResponse> GetMintByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<MintResponse>> GetAllMintsAsync(CancellationToken cancellationToken);
    }
}
