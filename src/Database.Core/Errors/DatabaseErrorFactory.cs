namespace Database.Core.Errors
{
    public static class DatabaseErrorFactory
    {
        public static DatabaseError EntryNotFound() => new DatabaseError(100, "A matching entry was not found");

        public static DatabaseError EntryNotFound(string property) => new DatabaseError(100, "A matching entry was not found", property);
    }
}
