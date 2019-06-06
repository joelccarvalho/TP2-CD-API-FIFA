namespace FootballApi.Errors
{
    public class BaseException : System.Exception
    {
        public virtual int StatusCode { get; set; }
        public BaseException() { }
        public BaseException(string message) : base(message) { }
        public BaseException(string message, System.Exception inner) : base(message, inner) { }
        protected BaseException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}