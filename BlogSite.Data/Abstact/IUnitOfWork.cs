

namespace BlogSite.Data.Abstact
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //this are uses in _unitofwork.xxx.AddAsync(); from IEntityRepository
        IArcticleRepository Articles {  get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        Task<int> SaveAsync(); //effected saved elements
    }
}
