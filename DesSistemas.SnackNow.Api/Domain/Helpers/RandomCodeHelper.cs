using System.Text;

namespace DesSistemas.SnackNow.Api.Domain.Helpers
{
    public static class RandomCodeHelper
    {
        public static string GetRandomCode(int length = 5) 
        { 
            var random = new Random();
            var strBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                strBuilder.Append(random.Next(1, 10));
            }

            return strBuilder.ToString();
        }

        public static string GetVerifyRandomCode(int randomIntlength = 5)
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(Guid.NewGuid().ToString("N"));
            strBuilder.Append(GetRandomCode(randomIntlength));
            return strBuilder.ToString();
        }
    }
}