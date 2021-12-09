using epl.core.Domain;
using epl.core.Interfaces;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace epl.IdentityServer.Storages
{
    public class ProfileService : IProfileService
    {
        private IAsyncRepository<Account> repository;

        public ProfileService(IAsyncRepository<Account> repository)
        {
            this.repository = repository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                //depending on the scope accessing the user data.
                if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
                {
                    //get user from db (in my case this is by email)
                    var user = (await repository.List()).First(x => x.Username == context.Subject.Identity.Name);

                    if (user != null)
                    {
                        //set issued claims to return
                        context.IssuedClaims = new List<Claim>()
                        {
                            new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                            new Claim(JwtClaimTypes.Name, user.Username)
                        };
                    }
                }
                else
                {
                    //get subject from context (this was set ResourceOwnerPasswordValidator.ValidateAsync),
                    //where and subject was set to my user id.
                    var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

                    if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                    {
                        //get user from db (find user by user id)
                        var user = await repository.Get(userId.Value);

                        // issue the claims for the user
                        if (user != null)
                        {
                            context.IssuedClaims = new List<Claim>()
                            {
                                new Claim(JwtClaimTypes.Id, user.Id),
                                new Claim(JwtClaimTypes.Name, user.Username)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log your error
            }
        }

        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");

                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    var user = await repository.Get(userId.Value);

                    if (user != null)
                    {
                        if (user.IsActive)
                        {
                            context.IsActive = user.IsActive;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //handle error logging
            }
        }
    }
}
