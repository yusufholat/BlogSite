using BlogSite.Shared.Utilities.Results.Abstract;
using BlogSite.Shared.Utilities.Results.ComplexTypes;


namespace BlogSite.Shared.Utilities.Results.Concreate
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message, Exception exeption)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exeption;
        }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
