using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace OAM.Service.Helpers
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "Role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "OAM.Service",
                    DisplayName = "Open Asset Manager Service API",
                    UserClaims = new List<string> {"role"},
                    Scopes = new List<Scope>
                    {
                        // Only one scope needed for OAM.Service.
                        new Scope("OAM.Service")
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Administrator",
                    ClientName = "OAM Administrator",
                    AllowOfflineAccess = true,
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets = {
                        new Secret("Adm1n1strat0r!".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "OAM.Service" },
                    Claims = new List<Claim>
                    {
                        // We're an admin, so we need the appropriate role.
                        new Claim(JwtClaimTypes.Role, "Admin")
                    }
                }
            };
        }
    }
}
