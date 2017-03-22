using Application.DailyStatus.BusinessCommon;
using Application.DailyStatus.BusinessInterface;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Practices.Unity;
using Application.DailyStatus.BusinessEntities;

namespace Application.DailyStatus.WebApi
{
    public class DailyStatusAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            IUserServices userService = UnityContainerHelper.GetUnityContainerInstance().Resolve<IUserServices>();
            UserEntity userEntity = userService.AuthenticateUser(context.UserName, context.Password);
            if (userEntity != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", userEntity.LoginId));
                identity.AddClaim(new Claim(ClaimTypes.Name, userEntity.UserName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}