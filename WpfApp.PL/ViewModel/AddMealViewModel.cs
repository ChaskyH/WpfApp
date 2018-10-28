using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.BLL.Foods;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    public class AddMealViewModel : ViewModelBase
    {
        public User User { get; set; }

        public AddMealViewModel()
        {
            AddToMealCommand = new RelayCommand(AddToMeal, () => { return MealString.Length > 0; });
            ClearMealCommand = new RelayCommand(Clear, IsMealEmpty);
            SaveCommand = new RelayCommand(Save, IsMealEmpty);
        }

        public RelayCommand AddToMealCommand { get; set; }
        public RelayCommand ClearMealCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public async void AddToMeal()
        {
            FoodLogic foodLogic = new FoodLogic();
            Meal = await foodLogic.AddToMealAsync(Meal, MealString);
        }

        public async void Save()
        {
            FoodLogic foodLogic = new FoodLogic();
            await foodLogic.AddMeal(User, Meal);
        }

        public void Clear()
        {
            Meal = null;
            MealString = "";
        }

        public bool IsMealEmpty()
        {
            return Meal != null && Meal.Foods.Count > 0;
        }

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
            AddToMealCommand.RaiseCanExecuteChanged();
            ClearMealCommand.RaiseCanExecuteChanged();
            SaveCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// The <see cref="Meal" /> property.
        /// </summary>
        private Meal _Meal = null;
        public Meal Meal
        {
            get
            {
                return _Meal;
            }
            set
            {
                _Meal = value;
                RaisePropertyChanged("Meal");
            }
        }

        /// <summary>
        /// The <see cref="MealString" /> property.
        /// </summary>
        private String _MealString = "";
        public String MealString
        {
            get
            {
                return _MealString;
            }
            set
            {
                if (_MealString == value)
                {
                    return;
                }
                _MealString = value;
                RaisePropertyChanged("MealString");
            }
        }
    }
}
