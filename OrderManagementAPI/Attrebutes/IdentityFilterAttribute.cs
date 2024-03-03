using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderManagementAPI.Domen.Entites.Enums;
using System.Security.Claims;
using System.Text.Json;

namespace OrderManagementAPI.Attrebutes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Enum)]
    public class IdentityFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;

        public IdentityFilterAttribute(Permission permissionId)
        {
            _permissionId = (int)permissionId;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionIds = identity.FindFirst("Permissions")?.Value;

            var result = JsonSerializer.Deserialize<List<int>>(permissionIds).Any(x => _permissionId == x);

            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
