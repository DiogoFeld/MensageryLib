namespace Api.Controllers.Models.Request
{
    public class SendMessageSimpleRequest<T>
    {
        public T Message { get; set; }
        public string Queue { get; set; }
    }
}
