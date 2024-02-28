using System.Security.Claims;
using AppCore.Extensions;
using AppCore.Models;
using MainData.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MainData.Middlewares;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly bool _allowInactive;
    private readonly bool _allowAllRole;

    public AuthorizeAttribute(bool allowInactive = false, bool allowAllRole = false)
    {
        _allowInactive = allowInactive;
        _allowAllRole = allowAllRole;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        var user = context.HttpContext.User;
        if (!user.GetActive() && !_allowInactive)
            throw new ApiException(MessageKey.Forbidden, StatusCode.FORBIDDEN);

        var active = user.GetActive();
        if (active && _allowInactive)
            throw new ApiException(MessageKey.AccountNotActivated, StatusCode.NOT_ACTIVE);
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
}