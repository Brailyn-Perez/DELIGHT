using DELIGHT.Core.Application.Interface.Repositories;
using DELIGHT.Core.Domain.Entities;
using DELIGHT.Infraestructure.Persistence.Context;
using DELIGHT.Infraestructure.Persistence.Repositories.Base;

namespace DELIGHT.Infraestructure.Persistence.Repositories
{
    public class MintRepository : BaseRepository<Mint>, IMintRepository
    {
        private readonly DELIGHTContext _context;
        public MintRepository(DELIGHTContext context) : base(context)
        {
            _context = context;
        }
    }
}
