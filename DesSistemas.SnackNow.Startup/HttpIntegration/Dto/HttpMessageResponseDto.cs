namespace DesSistemas.SnackNow.Startup.HttpIntegration.Dto
{
    public class HttpMessageResponseDto<TContent>
    {
        public TContent Content { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;

        public HttpMessageResponseDto(TContent content, int statusCode)
        {
            Content = content;
            StatusCode = statusCode;
        }
    }

    public class HttpDefaultMessageResponseDto : HttpMessageResponseDto<string>
    {
        public HttpDefaultMessageResponseDto(string content, int statusCode) : base(content, statusCode)
        {
        }
    }
}