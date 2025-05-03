namespace Api.Controllers.Models.Request
{
    public class SendMessageRequest<T>
    {
        public T Message { get; set; }
        public string Exchange { get; set; }
        public string RoutKey { get; set; }
    }
}
