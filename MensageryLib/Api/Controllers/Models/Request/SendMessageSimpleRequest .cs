namespace Api.Controllers.Models.Request
{
    public class SendMessageSimpleRequest<T>
    {
        public T message { get; set; }
        public string queue { get; set; }
    }
}
