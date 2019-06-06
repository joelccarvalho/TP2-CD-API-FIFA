namespace FootballApi.Errors
{
    public class NoContentException : BaseException
    {
        public override int StatusCode {
            get 
            {
                return 204;
            }
        }
        public NoContentException() { }
        public NoContentException(string message) : base($"No content found for '{message}'") {
            
        }
        public NoContentException(string message, System.Exception inner) : base(message, inner) { }
        protected NoContentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}