using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.DAL;
using WpfApp.DataProtocol;

namespace WpfApp.BLL
{
    public class GoalsLogic
    {
        public void AddGoal(User user, Goals goals)
        {
            var goalsService = new GoalsService()
            {
                User = user
            };

            goalsService.AddGoals(goals);
        }

        public Goals GetGoals(User user, DateTime date)
        {
            var goalsService = new GoalsService()
            {
                User = user
            };

            return goalsService.Goals.Where(g => date >= g.GoalStartDate && date <= g.GoalEndDate ).FirstOrDefault();
        }
    }
}
