using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        // Kullanıcı bize kullanıcı adı ve şifresini verecek biz de onlara
        // token verecez ve ne zaman sonlanacağı bilgisini vereceğiz
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
