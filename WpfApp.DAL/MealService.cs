using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WpfApp.DAL.DataContext;
using WpfApp.DataProtocol;

namespace WpfApp.DAL
{
    public class MealService
    {
        public User User { get; set; }

        public async Task AddMeal(Meal meal)
        {
            if (User != null && meal != null)
            {
                using (var db = new AppDbContext())
                {
                    User user = db.Users.Where((u) => u.Id == User.Id).FirstOrDefault();
                    
                    if (user != null)
                    {
                        meal.UserId = user.Id;
                        db.Meals.Add(meal);
                        await db.SaveChangesAsync();
                    }
                }
            }
        }

        public List<Meal> GetMeals()
        {
            if (User != null)
            {
                using (var db = new AppDbContext())
                {
                    return db.Meals.Include(m => m.Foods).Where((m) => m.UserId == User.Id).ToList();
                }
            }

            return null;
        }
    }
}
