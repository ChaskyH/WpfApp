using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
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

            Labels = new String[] {
                        "Calories",
                        "Cholestrol",
                        "Sugars",
                        "Saturated Fat",
                        "Total Fat",
                        "Total Carbohydrate",
                        "Sodium",
                        "Protien",
                        "Potassium"
                    };
            Formatter = value => value.ToString("N");

            if (IsInDesignMode)
            {
                FoodNutritions = new FoodNutritions()
                {
                    FoodName="Food Name", ServingUnit="Cups", ServingQuantity=2,ServingWeight="10",
                    TotalFat=2,SaturatedFat=5,Protien=9,Calories=7,Cholestrol=7
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

                if (_FoodNutritions != null)
                {
                    NutritionsChartValues = new ChartValues<double>() {
                        _FoodNutritions.Calories,
                        _FoodNutritions.Cholestrol,
                        _FoodNutritions.Sugars,
                        _FoodNutritions.SaturatedFat,
                        _FoodNutritions.TotalFat,
                        _FoodNutritions.TotalCarbohydrate,
                        _FoodNutritions.Sodium,
                        _FoodNutritions.Protien,
                        _FoodNutritions.Potassium
                    };
                        
                }

                RaisePropertyChanged("FoodNutritions");
            }
        }

        /// <summary>
        /// The <see cref="NutritionsChartValues" /> property.
        /// </summary>
        private ChartValues<double> _NutritionsChartValues = null;
        public ChartValues<double> NutritionsChartValues
        {
            get
            {
                return _NutritionsChartValues;
            }
            set
            {
                if (_NutritionsChartValues == value)
                {
                    return;
                }
                _NutritionsChartValues = value;
                RaisePropertyChanged("NutritionsChartValues");
            }
        }
        
        /// <summary>
        /// The <see cref="Labels" /> property.
        /// </summary>
        private String[] _Labels = null;
        public String[] Labels
        {
            get
            {
                return _Labels;
            }
            set
            {
                if (_Labels == value)
                {
                    return;
                }
                _Labels = value;
                RaisePropertyChanged("Labels");
            }
        }

        /// <summary>
        /// The <see cref="Formatter" /> property.
        /// </summary>
        private Func<double, string> _Formatter = null;
        public Func<double, string> Formatter
        {
            get
            {
                return _Formatter;
            }
            set
            {
                if (_Formatter == value)
                {
                    return;
                }
                _Formatter = value;
                RaisePropertyChanged("Formatter");
            }
        }
    }
}
