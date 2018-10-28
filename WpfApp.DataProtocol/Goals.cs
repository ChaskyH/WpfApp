using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataProtocol
{
    public class Goals
    {
        public Goals()
        {
            Id = Guid.NewGuid();
            Nutritions = new FoodNutritions();
        }

        public Guid UserId { get; set; }
        public Guid Id { get; set; }

        public DateTime GoalStartDate { get; set; }
        public DateTime GoalEndDate
        {
            get { return GoalStartDate.AddDays(7); }
        }
        public FoodNutritions Nutritions { get; set; }
    }
}
