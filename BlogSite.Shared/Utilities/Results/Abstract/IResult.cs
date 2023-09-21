using BlogSite.Shared.Utilities.Results.ComplexTypes;


namespace BlogSite.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; } //our spesific result state
        public string Message { get; }
        public Exception Exception { get; }
    }
}
