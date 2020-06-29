namespace Api.RestSharp.TestFramework
{
    public class ToDoItemPOCOWithoutId
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
        public ToDoItemPOCOWithoutId() { }
    }
}