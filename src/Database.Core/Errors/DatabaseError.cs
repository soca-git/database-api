namespace Database.Core.Errors
{
    public class DatabaseError
    {
        public DatabaseError(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public DatabaseError(int code, string message, string property)
        {
            Code = code;
            Message = message;
            Property = property;
        }

        public int Code { get; private set; }

        public string Message { get; private set; }

        public string Property { get; private set; }
    }
}
