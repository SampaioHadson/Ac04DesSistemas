namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public class PaginationResponseBase<TResponse>
    {
        public IList<TResponse>? Items { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PaginationResponseBase(IList<TResponse>? items,
            int page,
            int perPage,
            int totalItems,
            int totalPages)
        {
            Items = items;
            Page = page;
            PerPage = perPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}