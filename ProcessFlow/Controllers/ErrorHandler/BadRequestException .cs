namespace ProcessFlow.Controllers.ErrorHandler
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
