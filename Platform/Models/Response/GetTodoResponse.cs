namespace NetCoreWebApi.Platform.Models.Response
{
    public record GetTodoResponse
    (
        int Id,
        string Title,
        bool IsCompleted
    );
}
