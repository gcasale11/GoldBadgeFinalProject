using Cafe.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.REPO
{
    public class Menurepo
    {
        //List of Business Objects
        private readonly List<Menu> _menuitem = new List<Menu>(); //this is a field
        private int _count = 1; //seting field
        
        
        //Creating NEW Menu-Items to be on CAFE MENU
        public bool CreateMenuItem(Menu menu)
        {
            if (menu == null)
                _count++;
            menu.MealNumber = _count;
            _menuitem.Add(menu);
            return true;
        }

        //R ead
        //Get Menu?
        public List<Menu> GetMenuItems()
        {
            return _menuitem;
        }

       // Get menu by ID?
        public Menu GetMenuItemsByNumber(int ItemNumber)
        {
            foreach (Menu menu in _menuitem)
            {
                if (ItemNumber == menu.MealNumber)
                {
                    return menu;
                }
            }
            return null;
        }


        //D elete
        //Menu-Item off CAFE MENU
        public bool RemoveItemOffMenu(int ItemNumber)
        {
            Menu menuItemToBeRemoved = GetMenuItemsByNumber(ItemNumber);
            if (menuItemToBeRemoved == null)
            {
                return false;
            }
            else
            {
                _menuitem.Remove(menuItemToBeRemoved);
                return true;
            }
        }

       
    }
}
