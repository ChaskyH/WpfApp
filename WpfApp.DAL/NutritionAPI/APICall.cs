using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp.DataProtocol;

namespace WpfApp.DAL.NutritionAPI
{
    public class APICall
    {
        public APICall()
        {
            AppId = "4dee33c2";
            AppKey = "36cb12421bd2a80021d97412abb6df4d";
            BaseUri = new Uri(@"https://trackapi.nutritionix.com/v2/");

            client = new HttpClient();
            client.BaseAddress = BaseUri;
            client.DefaultRequestHeaders.Add("x-app-id", AppId);
            client.DefaultRequestHeaders.Add("x-app-key", AppKey);
        }

        public String AppId { get; set; }
        public String AppKey { get; set; }
        public Uri BaseUri { get; set; }
        public HttpClient client { get; set; }

        public async Task<List<InstantObject>> GetFoods(String query)
        {
            HttpResponseMessage response = await client.GetAsync("search/instant?query=" + query);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                try
                {
                    var res = new List<InstantObject>();
                    JObject obj = JsonConvert.DeserializeObject(result) as JObject;

                    foreach (var item in obj["common"].ToList())
                    {
                        res.Add(InstantObject.FromJson(item.ToString()));
                    }

                    return res;
                }
                catch (Exception)
                {
                    return new List<InstantObject>();
                }
            }

            return new List<InstantObject>();
        }

        public async Task<NutritionsObject> GetNutritions(String query)
        {
            var json = new JObject();
            json["query"] = query;
            
            HttpResponseMessage response = await client.PostAsync("natural/nutrients", new StringContent(json.ToString(), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                try
                {
                    JObject obj = JsonConvert.DeserializeObject(result) as JObject;

                    var j = obj["foods"].ToList().FirstOrDefault();
                    return NutritionsObject.FromJson(j.ToString());
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return null;
        }

        public async Task<Meal> GetMealAsync(String query)
        {
            Meal meal = new Meal();

            var json = new JObject();
            json["query"] = query;

            HttpResponseMessage response = await client.PostAsync("natural/nutrients", new StringContent(json.ToString(), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                try
                {
                    JObject obj = JsonConvert.DeserializeObject(result) as JObject;

                    foreach (var food in  obj["foods"].ToList())
                    {
                        var no = NutritionsObject.FromJson(food.ToString());
                        if (no != null)
                        {
                            meal.Foods.Add(new FoodNutritions()
                            {
                                FoodName = no.FoodName,
                                ServingQuantity = (int)no.ServingQty,
                                ServingUnit = no.ServingUnit,
                                ServingWeight = no.ServingWeightGrams.ToString(),
                                Calories = no.NfCalories,
                                TotalFat = no.NfTotalFat,
                                SaturatedFat = no.NfSaturatedFat,
                                Cholestrol = no.NfCholesterol,
                                Sodium = no.NfSodium,
                                TotalCarbohydrate = no.NfTotalCarbohydrate,
                                DietaryFiber = no.NfDietaryFiber,
                                Sugars = no.NfSugars,
                                Protien = no.NfProtein,
                                Potassium = no.NfPotassium,
                                Photo = no.Photo.Highres
                            });
                        }
                    }

                    return meal;
                }
                catch (Exception)
                {
                    return meal;
                }
            }

            return meal;
        }
    }
}
