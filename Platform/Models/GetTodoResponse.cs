namespace NetCoreWebApi.Platform.Models
{
    public class GetTodoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
