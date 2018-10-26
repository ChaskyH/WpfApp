using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataProtocol
{
    public class Meal
    {
        public Meal()
        {
            Foods = new ObservableCollection<FoodNutritions>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String Type { get; set; }
        public ObservableCollection<FoodNutritions> Foods { get; set; }

        public FoodNutritions Totals
        {
            get
            {
                return new FoodNutritions()
                {
                    Calories=Foods.Sum(food => food.Calories),
                    SaturatedFat = Foods.Sum(food => food.SaturatedFat),
                    TotalFat = Foods.Sum(food => food.TotalFat),
                    Sodium = Foods.Sum(food => food.Sodium),
                    Potassium = Foods.Sum(food => food.Potassium),
                    Protien = Foods.Sum(food => food.Protien),
                    DietaryFiber = Foods.Sum(food => food.DietaryFiber),
                    Sugars = Foods.Sum(food => food.Sugars),
                    Cholestrol = Foods.Sum(food => food.Cholestrol),
                    TotalCarbohydrate = Foods.Sum(food => food.TotalCarbohydrate)
                };
            }
        }
    }
}
