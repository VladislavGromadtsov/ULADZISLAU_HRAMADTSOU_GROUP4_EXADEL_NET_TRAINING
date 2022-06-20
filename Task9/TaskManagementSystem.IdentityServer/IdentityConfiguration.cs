using IdentityModel;
using IdentityServer4.Models;
using IdentityModel;
using IdentityServer4;

namespace TaskManagementSystem.IdentityServer
{
    public class IdentityConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> 
            {
                new ApiScope("TaskManagementSystem", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("TaskManagementSystem", "Web API", new []
                { JwtClaimTypes.Name })
                {
                    Scopes = {"TaskManagementSystem"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId ="task-management-system",
                    ClientName = "Task Management System",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://.../signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://.../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "TaskManagementSystem"
                    },
                    AllowAccessTokensViaBrowser = true,

                }
            };
    }
}
