using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.DAL.NutritionAPI;
using WpfApp.DataProtocol;

namespace WpfApp.BLL.Foods
{
    public class FoodLogic
    {
        public async Task<List<BasicFood>> GetFoods(String keyWord)
        {
            APICall apiCall = new APICall();

            List<InstantObject> list = await apiCall.GetFoods(keyWord);

            List<BasicFood> res = new List<BasicFood>();
            foreach (var item in list)
            {
                res.Add(new BasicFood()
                {
                    Id=item.TagId,
                    Name=item.FoodName,
                    ServingUnits=item.ServingUnit,
                    Photo=item.Photo.Thumb
                });
            }

            return res;
        }

        public async Task<FoodNutritions> GetNutritions(String keyWord)
        {
            APICall apiCall = new APICall();

            NutritionsObject obj = await apiCall.GetNutritions(keyWord);

            FoodNutritions res = null;

            if (obj != null)
            {
                res = new FoodNutritions()
                {
                    FoodName = obj.FoodName,
                    ServingQuantity = (int)obj.ServingQty,
                    ServingUnit = obj.ServingUnit,
                    ServingWeight = obj.ServingWeightGrams.ToString(),
                    Calories = obj.NfCalories,
                    TotalFat = obj.NfTotalFat,
                    SaturatedFat = obj.NfSaturatedFat,
                    Cholestrol = obj.NfCholesterol,
                    Sodium = obj.NfSodium,
                    TotalCarbohydrate = obj.NfTotalCarbohydrate,
                    DietaryFiber = obj.NfDietaryFiber,
                    Sugars = obj.NfSugars,
                    Protien = obj.NfProtein,
                    Potassium = obj.NfPotassium,
                    Photo = obj.Photo.Highres
                };
            }

            return res;
        }
    }
}
