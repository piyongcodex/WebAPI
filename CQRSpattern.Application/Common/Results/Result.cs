namespace CQRSpattern.Application.Common.Results
{
    public sealed class Result<T>
    {
        public ResultStatus Status { get; }
        public T Value { get; }
        public string Error { get; }

        private Result(ResultStatus status, T value, string error)
        {
            Status = status;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) =>
            new Result<T>(ResultStatus.Success, value, null);

        public static Result<T> NotFound(string message) =>
            new Result<T>(ResultStatus.NotFound, default, message);

        public static Result<T> Conflict(string message) =>
            new Result<T>(ResultStatus.Conflict, default, message);

        public static Result<T> ValidationError(string message) =>
            new Result<T>(ResultStatus.ValidationError, default, message);
    }

}
