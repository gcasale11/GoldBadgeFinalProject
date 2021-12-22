using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.POCO
{
    public enum Ingredients { }

    public class Menu
    {
    //meal number, ID[so customers can say "I'll have the #5"]
    //meal name,
    //description,
    //list of ingredients,
    //price


        public List<String> Ingredients { get; set; }
    
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }


        public Menu(int mealNumber, string mealName, string mealDescription, List<String> ingredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            MealPrice = mealPrice;
        }
    }
}