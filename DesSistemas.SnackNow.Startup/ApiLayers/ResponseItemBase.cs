namespace DesSistemas.SnackNow.Startup.ApiLayers
{
    public class ResponseItemBase<TId>
        where TId : struct
    {
        public virtual TId Id { get; set; }
        public virtual DateTime CreatedAt { get; set; } 
        public virtual DateTime UpdatedAt { get; set; }
        public virtual bool IsActive { get; set; }
    }
}