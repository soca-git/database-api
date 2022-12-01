using System;
using System.Net;

namespace Database.Core.Errors
{
    public class DatabaseException : Exception
    {
        public DatabaseException(DatabaseError error)
        {
            Payload = new DatabaseExceptionPayload
            {
                Error = error
            };
        }

        public DatabaseExceptionPayload Payload { get; private set; }

        public class DatabaseExceptionPayload
        {
            public HttpStatusCode StatusCode => (HttpStatusCode)422;

            public string Title => "A database error occurred";

            public DatabaseError Error { get; set; }
        }
    }
}
