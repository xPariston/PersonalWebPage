namespace WebPage.Server.Base
{
    public class Result<T>
        where T : class
    {
        public T Content { get; set; }

        public ResultState ResultState { get; set; }

        private Result(T content, ResultState resultState)
        {
            Content = content;
            ResultState = resultState;
        }

        private Result(ResultState resultState)
        {
            ResultState = resultState;
        }

        public static Result<T> CreateSuccessResult(T content)
        {
            return new Result<T>(content, ResultState.Ok);
        }

        public static Result<T> CreateNotFoundResult()
        {
            return new Result<T>(ResultState.NotFound);
        }

        public static Result<T> CreateBadRequestResult()
        {
            return new Result<T>(ResultState.BadRequest);
        }


    }
}
