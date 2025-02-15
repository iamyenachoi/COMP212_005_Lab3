using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Models
{
    public class FoodItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string DisplayProp { get { return this.Name + "\t" + this.Price + "($)"; } }
    }
    public static class FoodItemInitializer
    {

        public static List<FoodItem> Beverages;
        public static List<FoodItem> Dessert;
        public static List<FoodItem> Appetizer;
        public static List<FoodItem> MainCourse;

        //Initialize and fill data in constructor
        static FoodItemInitializer()
        {
            //Initialize and fill beverage
            Beverages = new List<FoodItem> {
                new FoodItem{Name="Soda",Price=1.95,Category=Constants.FoodBeverage},
                new FoodItem{Name="Tea",Price=1.50,Category=Constants.FoodBeverage},
                new FoodItem{Name="Coffee",Price=1.25,Category=Constants.FoodBeverage},
                new FoodItem{Name="Mineral Water",Price=2.95,Category=Constants.FoodBeverage},
                new FoodItem{Name="Juice",Price=2.50,Category=Constants.FoodBeverage},
                new FoodItem{Name="Milk",Price=1.50,Category=Constants.FoodBeverage}
            };

            //Initialize and fill beverage
            Appetizer = new List<FoodItem> {
                new FoodItem{Name="Buffalo Wings",Price=5.95,Category=Constants.FoodAppetizer},
                new FoodItem{Name="Buffalo Fingers",Price=6.95,Category=Constants.FoodAppetizer},
                new FoodItem{Name="Potato Skins",Price=8.95,Category=Constants.FoodAppetizer},
                new FoodItem{Name="Nachos",Price=8.95,Category=Constants.FoodAppetizer},
                new FoodItem{Name="Mushroom caps",Price=10.95,Category=Constants.FoodAppetizer},
                new FoodItem{Name="shrimp Cocktail",Price=12.95,Category=Constants.FoodAppetizer},
                new FoodItem{Name="Chips and Salsa",Price=6.95,Category=Constants.FoodAppetizer}
            };

            //Initialize and fill main course
            MainCourse = new List<FoodItem> {
                new FoodItem{Name="Seafood Alfredo",Price=15.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Chicken Alfredo",Price=13.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Chicken Pickatta",Price=13.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Turkey Club",Price=11.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Lobster Pie",Price=19.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Prime Rib",Price=20.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Shrimp Scampi",Price=18.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Turkey Dinner",Price=13.95,Category=Constants.FoodMainCourse},
                new FoodItem{Name="Stuffed Chicken",Price=14.95,Category=Constants.FoodMainCourse}
            };

            //Initialize and fill dessert
            Dessert = new List<FoodItem> {
                new FoodItem{Name="Apple Pie",Price=5.95,Category=Constants.FoodDessert},
                new FoodItem{Name="Sundae",Price=3.95,Category=Constants.FoodDessert},
                new FoodItem{Name="Carrot Cake",Price=5.95,Category=Constants.FoodDessert},
                new FoodItem{Name="Mud Pie",Price=4.95,Category=Constants.FoodDessert},
                new FoodItem{Name="Apple Crisp",Price=5.95,Category=Constants.FoodDessert}
            };
        }
    }
}
