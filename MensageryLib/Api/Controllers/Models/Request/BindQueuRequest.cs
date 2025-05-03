namespace Api.Controllers.Models.Request
{
    public class BindQueuRequest
    {
        public string Exchange { get; set; }
        public string Queue{get;set;}
        public string RoutKey { get; set; }
    }
}
