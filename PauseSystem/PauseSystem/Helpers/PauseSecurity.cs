using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace PauseSystem
{


    public static class PauseSecurity
    {
        private static System.Security.Principal.IIdentity Identity
        {
            get
            {
                return HttpContext.Current.User.Identity;
            }
        }

        private static Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public static void Login(PauseIdentity pauseIndentity, bool isPersistant = false)
        {
           // var claimsIdentity = new PauseIdentity(userId, username, new List<string> { "user" });
            //This uses OWIN authentication
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistant }, pauseIndentity);
            HttpContext.Current.User = new PausePrincipal(AuthenticationManager.AuthenticationResponseGrant.Principal);
        }

        public static void Logout()
        {
            AuthenticationManager.SignOut();
        }

        public static string GetUserName()
        {
            return Identity.GetUserName();
        }

        public static string GetFullName()
        {
            return AuthenticationManager.User.FindFirst(ClaimTypes.GivenName).Value;
        }

        public static int GetUserId()
        {
            return Identity.GetUserId<int>();
        }

        public static bool IsAuthenticated
        {
            get
            {
                return Identity.IsAuthenticated;
            }
        }

        public static bool IsInRole(string roleType)
        {
            return AuthenticationManager.User.HasClaim(x => x.Type == ClaimTypes.Role && x.Value == roleType);
        }


        //Id = Guid.NewGuid().ToString();
        //    Issuer = ClaimSet.System;
        //    UserName = userName;
        //    Password = password;
        //    using (var context =
        //        new SubusiContext(
        //            "Data Source=195.190.30.148;Initial Catalog=Frugt;Persist Security Info=True;User ID=MsFrugt;Password=MsService1234;MultipleActiveResultSets=true;"))
        //    {
        //        if (context.Medarbejdere.Any(m =>
        //         System.String.Compare(m.Fornavn, userName, System.StringComparison.CurrentCultureIgnoreCase) == 0 &&
        //         System.String.Compare(m.Password, password, System.StringComparison.CurrentCultureIgnoreCase) == 0))
        //        {
        //            var me =
        //                context.Medarbejdere.First(
        //                    m =>
        //                        System.String.Compare(m.Fornavn, userName,
        //                            System.StringComparison.CurrentCultureIgnoreCase) == 0 &&
        //                        System.String.Compare(m.Password, password,
        //                            System.StringComparison.CurrentCultureIgnoreCase) == 0);
        //            this.User = new User()
        //            {
        //                Id = me.Id,
        //                IsAdmin = true,
        //                IsKunde = false,
        //                Navn = me.FullName
        //            };
        //            FullName = me.FullName;
        //        }
        //        if (context.Medarbejdere.Any(m =>
        //            System.String.Compare(m.SugarUser, userName, System.StringComparison.CurrentCultureIgnoreCase) == 0 &&
        //            System.String.Compare(m.PausePassword, password, System.StringComparison.CurrentCultureIgnoreCase) == 0))
        //        {
        //            var me =
        //                context.Medarbejdere.First(
        //                    m =>
        //                        System.String.Compare(m.SugarUser, userName,
        //                            System.StringComparison.CurrentCultureIgnoreCase) == 0 &&
        //                        System.String.Compare(m.PausePassword, password,
        //                            System.StringComparison.CurrentCultureIgnoreCase) == 0);
        //            this.User = new User()
        //            {
        //                Id = me.Id,
        //                IsAdmin = true,
        //                IsKunde = false,
        //                Navn = me.FullName
        //            };
        //            FullName = me.FullName;

        //        }
        //        int kundenr = 0;
        //        if (int.TryParse(userName, out kundenr) && 
        //            context.Kunder.Any(k => k.KundeNr.Value.CompareTo(kundenr) == 0 && 
        //            System.String.Compare(password, k.AfmeldingsPass, System.StringComparison.CurrentCultureIgnoreCase) == 0)
        //            )
        //        {
        //            var ku = context.Kunder.First(k => k.KundeNr.Value.CompareTo(kundenr) == 0);
        //            this.User =  new User()
        //            {
        //                Id = ku.Id,
        //                IsAdmin = false,
        //                IsKunde = true,
        //                Navn = ku.Navn
        //            };
        //            FullName = ku.NrOgNavn;
        //        }
        //    }
    }

    public class PauseIdentity : ClaimsIdentity
    {
        public PauseIdentity(int userId, string username, string name, IEnumerable<string> roles):base(DefaultAuthenticationTypes.ApplicationCookie)
        {
            AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
            AddClaim(new Claim(ClaimTypes.Name, username));
            AddClaim(new Claim(ClaimTypes.GivenName, name));
        }

        public IEnumerable<string> Roles
        {
            get
            {
                return from claim in FindAll(ClaimTypes.Role) select claim.Value;
            }
        }

        public int UserId { get { return Convert.ToInt32(FindFirst(ClaimTypes.NameIdentifier).Value); } }

    }

    public class PausePrincipal : ClaimsPrincipal
    {
        public PausePrincipal(PausePrincipal identity)
            : base(identity)
        {

        }

        public PausePrincipal(ClaimsPrincipal claimsPrincipal)
            : base(claimsPrincipal)
        {

        }

        //public override bool IsInRole(string role)
        //{
        //    return base.IsInRole(role);
        //}

        //public override System.Security.Principal.IIdentity Identity
        //{
        //    get
        //    {
        //        return (PauseIdentity)base.Identity;
        //    }
        //}

    }

    public class RoleTypes
    {
        public const string Customer = "Customer";
        public const string Employee = "Employee";
    }

}