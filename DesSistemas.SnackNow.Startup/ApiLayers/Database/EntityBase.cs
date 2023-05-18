namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public class EntityBase<TId>
        where TId : struct
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}