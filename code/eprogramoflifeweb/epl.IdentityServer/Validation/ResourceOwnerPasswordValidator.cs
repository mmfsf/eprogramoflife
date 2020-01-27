using epl.core.Interfaces;
using epl.IdentityServer.Models;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace epl.IdentityServer.Validation
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IAsyncRepository<User> repository;

        public ResourceOwnerPasswordValidator(IAsyncRepository<User> repository)
        {
            this.repository = repository;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = (await repository.List()).First(x => x.Username == context.UserName);
                if (user != null)
                {
                    if (user.Password == context.Password)
                    {
                        //set the result
                        var claims = new List<Claim>()
                        {
                            new Claim(JwtClaimTypes.Id, user.SubjectId),
                            new Claim(JwtClaimTypes.Name, user.Username)
                        };

                        context.Result = new GrantValidationResult(
                            subject: user.SubjectId,
                            authenticationMethod: "custom",
                            claims: claims);

                        return;
                    }

                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                    return;
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                return;
            }
            catch (Exception ex)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, $"Invalid request: {ex.Message}");
            }
        }
    }
}
