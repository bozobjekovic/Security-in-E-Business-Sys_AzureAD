using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebMailService.Helpers
{
    public static class UserDetails
    {
        public static string GetUserDetails()
        {
            ClaimsPrincipal cp = ClaimsPrincipal.Current;

            if (cp != null)
            {
                return string.Format("Hello {0} {1}", cp.FindFirst(ClaimTypes.GivenName).Value, cp.FindFirst(ClaimTypes.Surname).Value);
            }
            else
            {
                return "";
            }
        }
    }
}