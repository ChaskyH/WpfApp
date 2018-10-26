using System;
using System.Collections.Generic;

namespace WpfApp.DataProtocol
{
    public class User
    {
        public Guid Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public String Initials
        {
            get
            {
                var res = "";

                foreach (var name in FullName.Split(' '))
                {
                    res += name.Length > 0 ? name[0].ToString() : "";
                }

                return res;
            }
        }

        public String Email { get; set; }

        public String Password { get; set; }

        public DateTime BirthDay { get; set; }

        public int Age {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - BirthDay.Year;

                if (now < BirthDay.AddYears(age))
                    age--;

                return age;
            }
        }
    }
}
