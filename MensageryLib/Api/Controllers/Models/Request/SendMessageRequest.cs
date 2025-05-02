namespace Api.Controllers.Models.Request
{
    public class SendMessageRequest<T>
    {
        public T message { get; set; }
        public string exchange { get; set; }
        public string routKey { get; set; }
    }
}
