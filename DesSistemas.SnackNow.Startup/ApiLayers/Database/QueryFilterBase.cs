namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public class QueryFilterBase
    {
        public DateTime? MinCreatedAt { get; set; } 
        public DateTime? MaxCreatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}