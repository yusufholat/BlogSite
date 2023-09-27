using BlogSite.Data.Abstact;
using BlogSite.Data.Concreate.EntityFramework.Contexts;
using BlogSite.Data.Concreate.EntityFramework.Repositories;


namespace BlogSite.Data.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArcticleRepository _efArcticleRepository;
        private EfCategoryRepository _efCategoryRepository;
        private EfCommentRepository _efCommentRepository;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        public IArcticleRepository Articles => _efArcticleRepository ?? new EfArcticleRepository(_context);
        public ICategoryRepository Categories => _efCategoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _efCommentRepository ?? new EfCommentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
