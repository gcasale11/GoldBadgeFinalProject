using Cafe.POCO;
using Cafe.REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeUnitTestProject1
{
    [TestClass]
    public class CafeRepoUnitTest1
    {
        private readonly Menurepo _menurepo = new Menurepo();
        List<Menu> _menuItem = new List<Menu>();

        public void SeedData()
        {
            Menu mealNum1 = new Menu(1, "Western Burger", "yee-haw flavor", new List<string> { "Lettuce, bbq sauce, Cheese, Pickles, Beef patty" }, 8.50);
            Menu mealNum2 = new Menu(2, "Hawaiin Burger", "super tasty", new List<string> { "Lettuce, Ketchup, Mustard, Cheese, Pickles, Beef patty" }, 8.50);
           

            _menurepo.CreateMenuItem(mealNum1);
            _menurepo.CreateMenuItem(mealNum2);
            
        }



            [TestMethod]
            public void CreateMenuItem_ShouldReturnTrue()
            {
                Menu mealNum1 = new Menu(1, "Western Burger", "super tasty", new List<string> { "Lettuce, Ketchup, Mustard, Cheese, Pickles, Beef patty" }, 8.50);
                bool expected = true;

                bool actual = _menurepo.CreateMenuItem(mealNum1);

                Assert.AreEqual(expected, actual);
             
            }

            [TestMethod]
            public void GetMenuItem_ShouldREturnNotNUll()
            {
                SeedData();

                var isTrue = _menurepo.GetMenuItems();

                Assert.IsNotNull(isTrue);
            }

            [TestMethod]

            public void RemoveItemFromMenu_ResultInTrue()
            {
                SeedData();
                var expected = 2;
            

                bool removed = _menurepo.RemoveItemOffMenu(1);
                var actual = 2;

            Assert.AreEqual(expected, actual);
                Assert.IsTrue(removed);

            }
        }
    }

