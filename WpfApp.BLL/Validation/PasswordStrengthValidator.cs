using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.BLL.Validation
{
    public class PasswordStrengthValidator : IValidator
    {
        public int MinimumLength { get; set; }

        public bool Validate(object value)
        {
            return Validate(value as String);
        }

        public bool Validate(String value)
        {
            var res = false;

            if (value != null)
            {
                res = value.Length >= MinimumLength;
            }

            return res;
        }
    }
}
