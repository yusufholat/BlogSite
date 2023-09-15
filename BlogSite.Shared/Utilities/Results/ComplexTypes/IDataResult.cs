using BlogSite.Shared.Utilities.Results.Abstract;


namespace BlogSite.Shared.Utilities.Results.ComplexTypes
{
    public interface IDataResult<out T> : IResult //generic type for one item or list 
    {
        public T Data { get; } 
    }
}
