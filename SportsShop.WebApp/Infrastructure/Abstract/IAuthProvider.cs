namespace SportsShop.WebApp.Infrastructure.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
