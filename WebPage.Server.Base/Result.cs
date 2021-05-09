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

        public Result<T> CreateSuccessResult(T content)
        {
            return new Result<T>(content, ResultState.Ok);
        }

        public Result<T> CreateNotFoundResult(T content)
        {
            return new Result<T>(content, ResultState.NotFound);
        }

        public Result<T> CreateBadRequestResult(T content)
        {
            return new Result<T>(content, ResultState.BadRequest);
        }


    }
}
