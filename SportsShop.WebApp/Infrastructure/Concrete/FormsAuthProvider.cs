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

    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, CreateMD5(password));

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }

        private string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                var hashBytes = md5.ComputeHash(inputBytes);

                var s= Convert.ToBase64String(hashBytes);
                return s;

                //StringBuilder sb = new StringBuilder();

                //for(int i = 0;i<hashBytes.Length;i++)
                //{
                //    sb.Append(hashBytes[i].ToString("X2"));
                //}
                //return sb.ToString();
            }
        }
    }
}