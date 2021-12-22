using Cafe.POCO;
using Cafe.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.UI
{
    class ProgramUI
    {
        private readonly Menurepo _menurepo = new Menurepo();

        public object RemoveMenuItem { get; private set; }

        public void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Hey create Items on the Menu\n" +
                "1. Create Menu Item\n" +
                "2. Get All Menu Item List\n" +
                "3. Remove Menu Item\n" +
                "4. Close out App");
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                         CreateMenuItem();
                        break;
                    case "2":
                        GetAllMenuItems();
                        break;
                    case "3":
                        RemoveItemOffMenu();
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Thanks for creating menu items.");
                        break;
                    default:
                        break;
                }
            }
        }

        private void RemoveItemOffMenu()
        {
            Console.Clear();
            Console.WriteLine("Which item are you wanting to remove from the Menu?\n" +
                "press anykey to pull up menu item");
            Console.ReadKey();
            GetAllMenuItems();
            Console.WriteLine("Type the ID of the item you want to remove from your Menu:");
            int userInputForRemoval = int.Parse(Console.ReadLine());
            _menurepo.RemoveItemOffMenu(userInputForRemoval);
            Console.WriteLine($"{userInputForRemoval} has been removed from the Menu");
            Console.ReadLine();
        }//FIN

        private void GetAllMenuItems()
        {
            Console.Clear();
            List<Menu> getMenuItems = _menurepo.GetMenuItems();
            foreach (Menu menu in getMenuItems)
            {
                DisplayMenuItem(menu);
            }
            Console.ReadKey();
        } //FIN

        private void DisplayMenuItem(Menu menu) //FIN helper
        {
            Console.WriteLine($"{menu.MealNumber}\n" +
                $"{menu.MealName}\n" +
                $"{menu.MealDescription}\n" +
                $"{menu.MealPrice}");
            Console.WriteLine("**********************************");
        }

        private void CreateMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please input the menu item number");
            int userInputMealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input the menu item name");
            string userInputMealName = Console.ReadLine();

            Console.WriteLine("Please input the menu item description");
            string userInputMealDescription = Console.ReadLine();

            Console.WriteLine("Please input the menu item list of ingredients");
            String input = Console.ReadLine();
            List<String> addIngredients = new List<String>();
            addIngredients.Add(input);
            String inputNewIngredient = Console.ReadLine();
            addIngredients.Add(inputNewIngredient);
            foreach (var ingredient in addIngredients)
                Console.ReadKey();

            Console.WriteLine("Please input the menu item price");
            double userInputMealPrice = double.Parse(Console.ReadLine());

            Menu menunew = new Menu(userInputMealNumber, userInputMealName, userInputMealDescription, addIngredients, userInputMealPrice);

            bool isSuccesful = _menurepo.CreateMenuItem(menunew);
            if (isSuccesful)
            {
                Console.WriteLine($"Menu item number {userInputMealNumber}, {userInputMealName} was succesfully added to the Menu.");
            }
            else
            {
                Console.WriteLine($"{userInputMealNumber} {userInputMealName} was NOT succesfully added to the Menu.");
            }
            Console.WriteLine("Press enter to go back to Menu");
            Console.ReadLine();
            
        }//FIN
        
           
        }
    }

