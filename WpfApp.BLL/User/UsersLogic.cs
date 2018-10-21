using System;
using System.Collections.Generic;
using System.Text;
using WpfApp.BLL.Validation;
using WpfApp.DAL;
using WpfApp.DataProtocol;
using System.Linq;

namespace WpfApp.BLL
{
    public class UsersLogic
    {
        public enum CreationStatus
        {
            None, Created, ConnectionError, UserWithThisEmailAlreadyExists, DataValidationError
        }
        
        public EmailValidator EmailValidator { get; set; }
        public DateValidator BirthDayValidator { get; set; }
        public PasswordStrengthValidator PasswordStrengthValidator { get; set; }

        public UsersLogic()
        {
            EmailValidator = new EmailValidator();
            BirthDayValidator = new DateValidator()
            {
                MinimumDate = new DateTime(1900, 1, 1),
                MaximumDate = DateTime.Now - TimeSpan.FromDays(365 * 10)
            };
            PasswordStrengthValidator = new PasswordStrengthValidator()
            {
                MinimumLength = 6
            };
        }


        public CreationStatus CreateUser(String firstName, String lastName, DateTime birthDay, String email, String password)
        {
            var res = CreationStatus.None;

            if (EmailValidator.Validate(email) &&
                PasswordStrengthValidator.Validate(password) &&
                BirthDayValidator.Validate(birthDay))
            {
                User user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDay = birthDay,
                    Email = email,
                    Password = password
                };

                UsersService userService = new UsersService();

                Credentials cred = new Credentials()
                {
                    Email=email,Password=password
                };

                if ((from u in userService.Users
                     where u.Email.ToLower() == email.ToLower()
                     select u).ToList().Count > 0)
                {
                    res = CreationStatus.UserWithThisEmailAlreadyExists;
                }
                else
                {
                    if (userService.AddUser(user))
                    {
                        res = CreationStatus.Created;
                    }
                    else
                    {
                        res = CreationStatus.ConnectionError;
                    }
                }
            }

            return res;
        }

        public User GetUser(Credentials credentials)
        {
            User user = null;

            UsersService usersService = new UsersService();
            user = usersService.GetUser(credentials);

            return user;
        }

        public User GetUser(Guid id)
        {
            User user = null;

            UsersService userService = new UsersService();
            var users = from u in userService.Users
                        where u.Id == id
                        select u;

            user = users.FirstOrDefault();

            return user;
        }
    }
}
