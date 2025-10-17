using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreMVC_Identity.Controllers
{
    [NonController]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ClaimCheckAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // если пользователь не аутентифицирован, то закрыть доступ
            if (!user.Identity.IsAuthenticated)
                return;

            var isAuthorized = user.Identity is ClaimsIdentity      // у пользователя есть Claims
                && ((ClaimsIdentity)user.Identity).HasClaim(t => t.Type == ClaimType && t.Value == ClaimValue);

            // если у пользователя нет claims или claim имеет неправильное занчение
            if (!isAuthorized)
            {
                // запретить доспуп к защищаемому объекту
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
