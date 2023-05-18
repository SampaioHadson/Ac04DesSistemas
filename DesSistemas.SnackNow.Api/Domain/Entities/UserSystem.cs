using DesSistemas.SnackNow.Api.Dto.UserSystem;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class UserSystem : EntityBase<long>
    {
        public string UserName { get; set; } = null!;
        public string AuthZeroId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string GivenName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public string Cellphone { get; set; } = null!;


        public UserSystem(UserSystemAddRequest request, string authZeroId)
        {
            UserName = request.Username;
            Email = request.Email;
            GivenName = request.GivenName;
            FamilyName = request.FamilyName;
            Name = request.Name;
            Nickname = request.Nickname;
            Cellphone = request.Cellphone;
            AuthZeroId = authZeroId;
        }

        public UserSystem() { }
    }
}