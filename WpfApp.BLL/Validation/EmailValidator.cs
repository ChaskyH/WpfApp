using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.BLL.Validation
{
    public class EmailValidator : IValidator
    {
        public bool Validate(object value)
        {
            return Validate(value as String);
        }

        public bool Validate(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
