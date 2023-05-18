using DesSistemas.SnackNow.Api.Domain.Enums;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;

namespace DesSistemas.SnackNow.Api.Domain.Entities
{
    public class UserSystemPassRecovery : EntityBase<long>
    {
        public long UserSystemId { get; set; }
        public string MessageCode { get; set; } = null!;
        public UserSystemPassRecoveryStatus Status { get; set; }
        public string CodeToVerify { get; set; } = null!;

        public UserSystemPassRecovery() { }

        public UserSystemPassRecovery(long userSystemId, string messageCode, string codeToVerify)
        {
            UserSystemId = userSystemId;
            MessageCode = messageCode;
            Status = UserSystemPassRecoveryStatus.WaitingConfirm;
            CodeToVerify = codeToVerify;
        }
    }
}