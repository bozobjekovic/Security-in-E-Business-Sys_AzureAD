using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ITNewsService.Helpers
{
    public static class UserDetails
    {
        private static string urlType_objectidentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        public static string GetUserDetails()
        {
            return string.Format("Hello {0} {1}", ClaimsPrincipal.Current.FindFirst(ClaimTypes.GivenName).Value, ClaimsPrincipal.Current.FindFirst(ClaimTypes.Surname).Value);
        }

        public static Guid GetUserID()
        {
            return Guid.Parse(ClaimsPrincipal.Current.FindFirst(urlType_objectidentifier).Value);
        }
    }
}