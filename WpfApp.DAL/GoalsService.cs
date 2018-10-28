using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.DAL.DataContext;
using WpfApp.DataProtocol;

namespace WpfApp.DAL
{
    public class GoalsService
    {
        public User User { get; set; }

        public void AddGoals(Goals goals)
        {
            using (var db = new AppDbContext())
            {
                if (User != null)
                {
                    goals.UserId = User.Id;

                    db.Goals.Add(goals);
                    db.SaveChanges();
                }
            }
        }

        public List<Goals> Goals
        {
            get
            {
                using (var db = new AppDbContext())
                {
                    return db.Goals.Where(g => g.UserId == User.Id).ToList();
                }
            }
        }
   }
}
