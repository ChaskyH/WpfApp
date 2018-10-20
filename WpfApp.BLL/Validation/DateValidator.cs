using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.BLL.Validation
{
    public class DateValidator : IValidator
    {
        public DateTime MinimumDate { get; set; }
        public DateTime MaximumDate { get; set; }

        public bool Validate(object value)
        {
            return Validate((DateTime)value);
        }

        public bool Validate(DateTime date)
        {
            var res = false;

            if (date != null)
            {
                res = true;

                if (MinimumDate != null)
                {
                    res = date >= MinimumDate;
                }
                
                if (res && MaximumDate != null)
                {
                    res = date <= MaximumDate;
                }
            }

            return res;
        }
    }
}
