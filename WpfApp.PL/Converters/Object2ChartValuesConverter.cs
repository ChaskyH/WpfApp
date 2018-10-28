using LiveCharts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp.DataProtocol;

namespace WpfApp.PL.Converters
{
    public class Object2ChartValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object res = null;

            if (value is FoodNutritions foodNutrition)
            {
                res = new ChartValues<double>() {
                        foodNutrition.Calories,
                        foodNutrition.Cholestrol,
                        foodNutrition.Sugars,
                        foodNutrition.SaturatedFat,
                        foodNutrition.TotalFat,
                        foodNutrition.TotalCarbohydrate,
                        foodNutrition.Sodium,
                        foodNutrition.Protien,
                        foodNutrition.Potassium
                    };
            }

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
