using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace WpfApp.DAL.NutritionAPI
{

    public partial class NutritionsObject
    {
        [JsonProperty("food_name")]
        public string FoodName { get; set; }

        [JsonProperty("serving_qty")]
        public long ServingQty { get; set; }

        [JsonProperty("serving_unit")]
        public string ServingUnit { get; set; }

        [JsonProperty("serving_weight_grams")]
        public long ServingWeightGrams { get; set; }

        [JsonProperty("nf_calories")]
        public double NfCalories { get; set; }

        [JsonProperty("nf_total_fat")]
        public double NfTotalFat { get; set; }

        [JsonProperty("nf_saturated_fat")]
        public double NfSaturatedFat { get; set; }

        [JsonProperty("nf_cholesterol")]
        public long NfCholesterol { get; set; }

        [JsonProperty("nf_sodium")]
        public double NfSodium { get; set; }

        [JsonProperty("nf_total_carbohydrate")]
        public double NfTotalCarbohydrate { get; set; }

        [JsonProperty("nf_dietary_fiber")]
        public double NfDietaryFiber { get; set; }

        [JsonProperty("nf_sugars")]
        public double NfSugars { get; set; }

        [JsonProperty("nf_protein")]
        public double NfProtein { get; set; }

        [JsonProperty("nf_potassium")]
        public double NfPotassium { get; set; }

        [JsonProperty("nf_p")]
        public double NfP { get; set; }

        [JsonProperty("source")]
        public long Source { get; set; }

        [JsonProperty("ndb_no")]
        public long NdbNo { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("highres")]
        public Uri Highres { get; set; }

        [JsonProperty("is_user_uploaded")]
        public bool IsUserUploaded { get; set; }
    }

    public partial class NutritionsObject
    {
        public static NutritionsObject FromJson(string json) => JsonConvert.DeserializeObject<NutritionsObject>(json, NutritionAPI.Converter.Settings);
    }

    public static partial class Serialize
    {
        public static string ToJson(this NutritionsObject self) => JsonConvert.SerializeObject(self, NutritionAPI.Converter.Settings);
    }
}
