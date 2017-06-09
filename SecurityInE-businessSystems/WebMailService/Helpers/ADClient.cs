using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebMailService.Models;

namespace WebMailService.Helpers
{
    public class ADClient
    {
        private string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private string appKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
        private string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];

        private string graphResourceID = "https://graph.windows.net";
        private string urlType_objectidentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        private string urlType_tenantID = "http://schemas.microsoft.com/identity/claims/tenantid";

        public ActiveDirectoryClient GetADClient()
        {
            string tenantID = ClaimsPrincipal.Current.FindFirst(urlType_tenantID).Value;

            Uri servicePointUri = new Uri(graphResourceID);
            Uri serviceRoot = new Uri(servicePointUri, tenantID);
            return new ActiveDirectoryClient(serviceRoot,
                  async () => await GetTokenForApplication());
        }

        public async Task<Guid> GetReceiverIDbyEmail(string receiverEmail)
        {
            try
            {
                ActiveDirectoryClient activeDirectoryClient = GetADClient();
                var result = await activeDirectoryClient.Users
                    .Where(u => u.UserPrincipalName.Equals(receiverEmail))
                    .ExecuteAsync();
                IUser user = result.CurrentPage.ToList().First();

                return Guid.Parse(user.ObjectId);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        private async Task<string> GetTokenForApplication()
        {
            string signedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
            string tenantID = ClaimsPrincipal.Current.FindFirst(urlType_tenantID).Value;
            string userObjectID = ClaimsPrincipal.Current.FindFirst(urlType_objectidentifier).Value;

            // get a token for the Graph without triggering any user interaction (from the cache, via multi-resource refresh token, etc)
            ClientCredential clientcred = new ClientCredential(clientId, appKey);
            // initialize AuthenticationContext with the token cache of the currently signed in user, as kept in the app's database
            AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID, new ADALTokenCache(signedInUserID));
            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenSilentAsync(graphResourceID, clientcred, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
            return authenticationResult.AccessToken;
        }
    }
}