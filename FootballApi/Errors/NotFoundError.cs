namespace FootballApi.Errors
{
    public class NotFoundException: BaseException
    {
         public override int StatusCode {
            get 
            {
                return 404;
            }
        }
        public NotFoundException() { }
        public NotFoundException(string message) : base($"Not found for '{message}'") {
            
        }
        public NotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected NotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}