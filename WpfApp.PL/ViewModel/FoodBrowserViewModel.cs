using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.BLL.Foods;
using WpfApp.DataProtocol;

namespace WpfApp.PL.ViewModel
{
    public class FoodBrowserViewModel : ViewModelBase
    {
        public FoodBrowserViewModel():base()
        {
            SearchCommand = new RelayCommand(UpdateFoods);
            ViewNutritionsCommand = new RelayCommand<String>(
                    (x) => ViewNutritions(x)
                );

            if (IsInDesignMode)
            {
                FoodNutritions = new FoodNutritions()
                {
                    FoodName="Food Name", ServingUnit="Cups", ServingQuantity=2,
                    ServingWeight="10"
                };

                Foods = new List<BasicFood>()
                {
                    new BasicFood()  { Name="Apple" },
                    new BasicFood() { Name="Pear" }
                };
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand ViewNutritionsCommand { get; set; }

        async private void UpdateFoods()
        {
            FoodLogic foodLogic = new FoodLogic();
            Foods = await foodLogic.GetFoods(SearchText);
        }

        async private void ViewNutritions(String foodName)
        {
            FoodLogic foodLogic = new FoodLogic();
            FoodNutritions = await foodLogic.GetNutritions(foodName);
        }

        /// <summary>
        /// The <see cref="Foods" /> property.
        /// </summary>
        private List<BasicFood> _Foods = null;
        public List<BasicFood> Foods
        {
            get
            {
                return _Foods;
            }
            set
            {
                if (_Foods == value)
                {
                    return;
                }
                _Foods = value;
                RaisePropertyChanged("Foods");
            }
        }

        /// <summary>
        /// The <see cref="SearchText" /> property.
        /// </summary>
        private String _SearchText = "";
        public String SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                if (_SearchText == value)
                {
                    return;
                }
                _SearchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// The <see cref="FoodNutritions" /> property.
        /// </summary>
        private FoodNutritions _FoodNutritions = null;
        public FoodNutritions FoodNutritions
        {
            get
            {
                return _FoodNutritions;
            }
            set
            {
                if (_FoodNutritions == value)
                {
                    return;
                }
                _FoodNutritions = value;
                RaisePropertyChanged("FoodNutritions");
            }
        }
        
    }
}
