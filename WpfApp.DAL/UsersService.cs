using System;
using System.Linq;
using System.Data.SqlClient;
using WpfApp.DAL.DataContext;
using WpfApp.DataProtocol;
using System.Collections.Generic;

namespace WpfApp.DAL
{
    public class UsersService
    {
        public IEnumerable<User> Users
        {
            get
            {
                using (var db = new AppDbContext())
                {
                    return db.Users.ToList();
                }
            }
        }

        public bool AddUser(User user)
        {
            var res = false;

            using (var db = new AppDbContext())
            {
                db.Users.Add(user);
                res = true;
                db.SaveChanges();
            }

            return res;
        }

        public User GetUser(Credentials credentials)
        {
            User res = null;

            using (var db = new AppDbContext())
            {
                var query = from user in db.Users
                            where user.Email.ToLower() == credentials.Email.ToLower() && credentials.Password == user.Password
                            select user;

                var users = query.ToList();

                if (users.Count == 1)
                {
                    res = users.First();
                }
                else if (users.Count > 1)
                {
                    throw new Exception("Critical error. You can't have two users with the same credentials.");
                }
            }

            return res;
        }
    }
}
