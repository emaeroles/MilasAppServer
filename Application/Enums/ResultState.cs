namespace Application.Enums
{
    public enum ResultState
    {
        Success,

        Data,
        NotFound,
        Conflict,
        BadRequest,

        Created,
        NotCreated,
        Updated,
        NotUpdated,
        Deleted,
        NotDeleted,

        Authorized,
        Unauthorized,
    }
}
