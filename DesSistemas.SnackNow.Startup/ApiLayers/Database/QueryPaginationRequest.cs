namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public class QueryPaginationRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}