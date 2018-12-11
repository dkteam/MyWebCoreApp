﻿using System.Linq;
using System.Security.Claims;

namespace MyWebCoreApp.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimsType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimsType);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}