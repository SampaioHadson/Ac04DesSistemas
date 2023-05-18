using DesSistemas.SnackNow.Startup.ApiLayers;

namespace DesSistemas.SnackNow.Api.Dto.Establishments
{
    public class EstablishmentItemResponse : ResponseItemBase<long>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}