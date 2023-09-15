using BlogSite.Shared.Utilities.Results.ComplexTypes;


namespace BlogSite.Shared.Utilities.Results.Concreate
{
    public class DataResult<T> : IDataResult<T> //transferin with data 
    {           
        public DataResult(ResultStatus status, T data)
        {
            ResultStatus = status;
            Data = data;
        }
        public DataResult(ResultStatus status, string message, T data)
        {
            ResultStatus = status;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus status, string message, Exception exception, T data)
        {
            ResultStatus = status;
            Message = message;
            Exception = exception;
            Data = data;
        }

        public T Data { get; }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
