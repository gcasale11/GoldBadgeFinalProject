using KomodoInsurnace.POCO;
using KomodoInsurnace.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurnace.UI
{
    class BadgeUI

    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        private readonly Badge _badgelist = new Badge();
        public void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Create yourself badges\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all Badges\n" +
                "4. Remove badge\n" +
                "5. Exit App");
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
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        RemoveBadge();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void EditBadge()
        {
            {
                Console.WriteLine("Which badge id do you want to edit?");
                int id = int.Parse(Console.ReadLine());
                var badge = _badgeRepo.GetBadgeByID(id);
                Console.WriteLine($"Is this the right badge? {badge.BadgeID}{badge.BadgeFirstName}");

                Console.WriteLine("Would you like to change the first name?");
                badge.BadgeFirstName = Console.ReadLine();

                Console.WriteLine("Would you like to change the last name?");
                badge.BadgeLastName = Console.ReadLine();

                Console.WriteLine("Would you like to add, or delete a door? \n" +
                    $"a - add\n" +
                    $"d - delete" +
                    $"k - keep existing door\n" +
                    $"n - move on");
                string userInput = Console.ReadLine();
                List<string> newDoor = new List<string>();

                while (userInput == "a")
                {
                    Console.WriteLine("Please add door");
                    string addedDoor = Console.ReadLine();
                    newDoor.Add(addedDoor);

                    Console.WriteLine("would you like to add another door?\n" +
                        $"a - add\n" +
                        $"d - delete" +
                        $"n - move on");
                    userInput = Console.ReadLine();
                }

                while (userInput == "d")
                {
                    Console.WriteLine("Please remove door");
                    string removeDoor = Console.ReadLine();
                    newDoor.Remove(removeDoor);

                    Console.WriteLine("would you like to remove another?\n" +
                        $"a - add\n" +
                        $"d - delete" +
                        $"n - move on");
                    userInput = Console.ReadLine();
                }
                if (userInput == "k")
                {
                    badge.DoorNames = badge.DoorNames;
                }
                else if (userInput == "n")
                {
                    badge.DoorNames = newDoor;
                }

                _badgeRepo.UpdateExistingBadge(id, badge);
            }
        }//Fin

        private void RemoveBadge()
        {
            Console.Clear();
            Console.WriteLine("Which badge are you wanting to remove from the list?\n" +
                "press anykey to pull up menu item");
            Console.ReadKey();
            _badgeRepo.GetBadgeList();
            Console.WriteLine("Type the ID of the badge you want to remove from your list:");
            int userInputForRemoval = int.Parse(Console.ReadLine());
            _badgeRepo.RemoveBadgeFromList(userInputForRemoval);
            Console.WriteLine($"{userInputForRemoval} has been removed from the List");
            Console.ReadLine();
        }//FIN

        private void ListAllBadges()
        {
            Console.Clear();
            var getBadgeItems = _badgeRepo.GetBadgeList();
            foreach (var badge in getBadgeItems)
            {
                DisplayBadgeItem(badge.Value);
            }
            Console.ReadKey();
        } //FIN

        private void DisplayBadgeItem(Badge badge)
        {
            Console.WriteLine($"{badge.BadgeID}\n" +
            $"{badge.BadgeFirstName}\n" +
     $"{badge.BadgeLastName}\n" +
     $"{badge.DoorNames}");
            Console.WriteLine("**********************************");
        }//FIN
        private void AddBadge()
        {
            Badge newBadge = new Badge();

            //badge firstname
            Console.WriteLine("Enter first name of ");
            newBadge.BadgeFirstName = Console.ReadLine();

            //badge lastname
            Console.WriteLine("Enter last name of ");
            newBadge.BadgeLastName = Console.ReadLine();

            //badge door
            List<string> BadgeDoors = new List<string>();

            Console.WriteLine("Enter door allowed badgeDoor");
            string firstDoor = Console.ReadLine();
            BadgeDoors.Add(firstDoor);

            Console.WriteLine("Do you want to add another door?");
            string userInput = Console.ReadLine();
            while (userInput == "y")
            {
                Console.WriteLine("Enter door allowed badgeDoor");
                string moreDoors = Console.ReadLine();
                BadgeDoors.Add(moreDoors);

                Console.WriteLine("Do you want to add another door?");
                userInput = Console.ReadLine();
            }
            newBadge.DoorNames = BadgeDoors;
            _badgeRepo.CreateBadge(newBadge);
        }//Fin

    }
}
