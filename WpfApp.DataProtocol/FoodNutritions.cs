using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataProtocol
{
    public class FoodNutritions
    {
        public FoodNutritions()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public String FoodName { get; set; }

        public int ServingQuantity { get; set; }
        public String ServingUnit { get; set; }
        public String ServingWeight { get; set; }

        public double Calories { get; set; }
        public double TotalFat { get; set; }
        public double SaturatedFat { get; set; }
        public double Cholestrol { get; set; }
        public double Sodium { get; set; }
        public double TotalCarbohydrate { get; set; }
        public double DietaryFiber { get; set; }
        public double Sugars { get; set; }
        public double Protien { get; set; }
        public double Potassium { get; set; }

        [NotMapped]
        public Uri Photo { get; set; }

        public String DBPhoto
        {
            get { return Photo != null && Photo.IsAbsoluteUri ? Photo.AbsoluteUri : ""; }
            set { if (!string.IsNullOrEmpty(value)) { Photo = new Uri(value); } }
        }
    }
}
