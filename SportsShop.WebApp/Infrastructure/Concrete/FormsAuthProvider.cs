namespace SportsShop.WebApp.Infrastructure.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using SportsShop.WebApp.Infrastructure.Abstract;
    using System.Security.Cryptography;
    using System.Text;
    using SportsShop.Domain.Concrete;

    public class FormsAuthProvider : IAuthProvider
    {
        public EFDbContext _dbContext { get; set; }

        public bool Authenticate(string username, string password)
        {
            bool result = false;
            var user = _dbContext.Identities.FirstOrDefault(i => i.Username.Equals(username));

            if(user != null)
            {
                result = user.PasswordHash.Equals(CreateMD5(password));

                if (result)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                }
            }

            return result;
        }

        private string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                var hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}