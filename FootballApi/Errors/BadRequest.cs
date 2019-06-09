namespace FootballApi.Errors
{
    public class BadRequestException : BaseException
    {
         public override int StatusCode {
            get 
            {
                return 400;
            }
        }
        public BadRequestException() { }
        public BadRequestException(string message) : base($"Bad request for '{message}'") {
            
        }
        public BadRequestException(string message, System.Exception inner) : base(message, inner) { }
        protected BadRequestException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}