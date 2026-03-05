namespace Store.Application.DTOs.Common
{
    public class CommonResponse
    {
        public bool Successful { get; set; }
        public string UserMessage { get; set; }
        public int HttpCode { get; set; }
        public string InternalError { get; set; }
    }
}
