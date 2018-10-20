using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataProtocol
{
    public class Credentials
    {
        public Credentials()
        {
            Email = "";
            Password = "";
            RememberMe = false;
        }

        public String Email { get; set; }
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
