using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DesSistemas.SnackNow.RecaptchaHelper
{
    public class ValidateReCaptchaAttribute : ActionFilterAttribute
    {
        private const string HeaderName = "X-Recaptcha-Token";

        public ValidateReCaptchaAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var result = true;
            var header = context.HttpContext.Request.Headers.FirstOrDefault(f => f.Key.Equals(HeaderName, System.StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(header.Key) || string.IsNullOrEmpty(header.Value))
            {
                result = false;
            }
            else
            {
                var scope = context.HttpContext.RequestServices.CreateScope();
                var serviceValidator = scope.ServiceProvider.GetService<IRecaptchaHelper>();
                result = serviceValidator!.ValidateAsync(header.Value!).GetAwaiter().GetResult();
            }

            if (!result)
            {
                context.Result = new ForbidResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
