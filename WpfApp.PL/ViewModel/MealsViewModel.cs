using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Foods;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    public class MealsViewModel : ViewModelBase
    {
        public MealsViewModel()
        {
            SearchCommand = new RelayCommand(Search);
        }

        public RelayCommand SearchCommand { get; set; }
        public User User { get; set; }
        public void Search()
        {
            var foodLogic = new FoodLogic();
            Meals = foodLogic.GetMeals(User, From, To);

            Totals = new FoodNutritions()
            {
                Calories = Meals.Sum(meal => meal.Totals.Calories),
                SaturatedFat = Meals.Sum(meal => meal.Totals.SaturatedFat),
                TotalFat = Meals.Sum(meal => meal.Totals.TotalFat),
                Sodium = Meals.Sum(meal => meal.Totals.Sodium),
                Potassium = Meals.Sum(meal => meal.Totals.Potassium),
                Protien = Meals.Sum(meal => meal.Totals.Protien),
                DietaryFiber = Meals.Sum(meal => meal.Totals.DietaryFiber),
                Sugars = Meals.Sum(meal => meal.Totals.Sugars),
                Cholestrol = Meals.Sum(meal => meal.Totals.Cholestrol),
                TotalCarbohydrate = Meals.Sum(meal => meal.Totals.TotalCarbohydrate)
            };
        }

        /// <summary>
        /// The <see cref="Meals" /> property.
        /// </summary>
        private List<Meal> _Meals = null;
        public List<Meal> Meals
        {
            get
            {
                return _Meals;
            }
            set
            {
                if (_Meals == value)
                {
                    return;
                }
                _Meals = value;
                RaisePropertyChanged("Meals");
            }
        }

        /// <summary>
        /// The <see cref="From" /> property.
        /// </summary>
        private DateTime _From = DateTime.Today;
        public DateTime From
        {
            get
            {
                return _From;
            }
            set
            {
                if (_From == value)
                {
                    return;
                }
                _From = value;
                RaisePropertyChanged("From");
            }
        }

        /// <summary>
        /// The <see cref="To" /> property.
        /// </summary>
        private DateTime _To = DateTime.Today.AddDays(1);
        public DateTime To
        {
            get
            {
                return _To;
            }
            set
            {
                if (_To == value)
                {
                    return;
                }
                _To = value;
                RaisePropertyChanged("To");
            }
        }

        /// <summary>
        /// The <see cref="Totals" /> property.
        /// </summary>
        private FoodNutritions _Totals = null;
        public FoodNutritions Totals
        {
            get
            {
                return _Totals;
            }
            set
            {
                if (_Totals == value)
                {
                    return;
                }
                _Totals = value;
                RaisePropertyChanged("Totals");
            }
        }
    }
}
