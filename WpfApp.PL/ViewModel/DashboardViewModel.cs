using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL;
using WpfApp.BLL.Foods;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        public User User { get; set; }

        public DashboardViewModel()
        {
            RefreshCommand = new RelayCommand(Refresh);
        }

        public RelayCommand RefreshCommand { get; set; }

        public void Refresh()
        {
            GoalsLogic goalsLogic = new GoalsLogic();
            Goals = goalsLogic.GetGoals(User, DateTime.Today);

            if (Goals != null)
            {
                FoodLogic foodLogic = new FoodLogic();
                var meals = foodLogic.GetMeals(User, Goals.GoalStartDate, Goals.GoalEndDate);
                Weekly = foodLogic.GetTotals(meals);
            }
        }

        /// <summary>
        /// The <see cref="Weekly" /> property.
        /// </summary>
        private FoodNutritions _Weekly = null;
        public FoodNutritions Weekly
        {
            get
            {
                return _Weekly;
            }
            set
            {
                if (_Weekly == value)
                {
                    return;
                }
                _Weekly = value;
                RaisePropertyChanged("Weekly");
            }
        }

        /// <summary>
        /// The <see cref="Goals" /> property.
        /// </summary>
        private Goals _Goals = null;
        public Goals Goals
        {
            get
            {
                return _Goals;
            }
            set
            {
                if (_Goals == value)
                {
                    return;
                }
                _Goals = value;
                RaisePropertyChanged("Goals");
            }
        }
    }
}
