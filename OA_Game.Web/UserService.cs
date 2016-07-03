using Microsoft.AspNet.Identity;
using OA_Game.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace OA_Game.Web
{
    public class UserService
    {
        public static ClaimsIdentity CreateIdentity(AdminUser user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.UserName));
            return _identity;
        }
    }
}