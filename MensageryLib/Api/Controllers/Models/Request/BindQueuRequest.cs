namespace Api.Controllers.Models.Request
{
    public class BindQueuRequest
    {
        public string exchange { get; set; }
        public string queue{get;set;}
        public string routKey { get; set; }
    }
}
