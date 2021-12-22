using ClaimsDepartment.Repo;
using KClaimsDepartment.POCO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KClaimsDepartment.UI
{
    class ProgramUI
    {
        private readonly Claimsrepo _claimrepo = new Claimsrepo();



        public void Run()
        {

            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Create yourself a claim\n" +
                "1. See all Claims\n" +
                "2. Take care of Next claim\n" +
                "3. Enter a new claim\n" +
                "4. Exit App");
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
                        SeeAllCLaims();
                        break;
                    case "2":
                        TakeNextClaim();
                        break;
                    case "3":
                        CreateAClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }




        //Claim to be pulled off the top of the queue
        private void TakeNextClaim()
        {
            //view next claim and display info to user.
            var list = _claimrepo.GetClaimList();
           DisplayClaimInfo(list.Peek());

            Console.WriteLine($"Do you want to deal with this claim? y/n?");
            string userInput = Console.ReadLine();
            if (userInput == "y")
                {
                _claimrepo.RemoveClaimFromList();
                Console.WriteLine("No problem, the claim has been removed");
                }
            else
            {
               Menu();

             }

        }






        //View all claims queue listed
        private void SeeAllCLaims()
        {
            Console.Clear();
            Queue<Claims> getClaimItems = _claimrepo.GetClaimList();
            foreach (Claims claim in getClaimItems)
            {
                DisplayClaimInfo(claim);
            }
            Console.ReadKey();


        }



        private void CreateAClaim()
        {
            Claims newClaim = new Claims();

            Console.Clear();
            Console.WriteLine("Enter claim type\n" +
                 "1. Car\n" +
                 "2. Home\n" +
                 "3. Theft\n " +
                 "1-4, then press enter");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = int.Parse(claimTypeAsString);
            newClaim.ClaimType = (ClaimType)claimTypeAsInt;

            Console.WriteLine("Write description of the claim");
            string inputtedDescription = Console.ReadLine();

            Console.WriteLine("How much is the claim");
            string inputtedClaimAmountString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(inputtedClaimAmountString);

            Console.WriteLine("Date of Accident? Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
            DateTime inputtedDateAccident = new DateTime(year, month, day);


            Console.Write("Date of Claim? Enter a year: ");
            int year1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a month: ");
            int month1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day1 = int.Parse(Console.ReadLine());
            DateTime inputtedDateClaim = new DateTime(year1, month1, day1);

            _claimrepo.CreateClaim(newClaim);

            bool isSuccessful = _claimrepo.CreateClaim(newClaim);
            if (isSuccessful)
            {
                Console.WriteLine($"You succesfully added your claim to the database");
            }
            else
            {
                Console.WriteLine($"You did NOT add your claim to the database");
            }


            Console.WriteLine("Press enter to go back to Menu");
            Console.ReadLine();

        }//FIn
        public void DisplayClaimInfo(Claims claim)
        {
            Console.WriteLine($"{claim.ClaimID}\n" +
                $"{claim.ClaimType}\n" +
                $"{claim.Description}\n" +
                $"{claim.ClaimAmount}\n" +
                $"{claim.DateOfIncident}\n" +
                $"{claim.DateOfClaim}\n" +
                $"{claim.IsValid}\n");
            Console.WriteLine("***********");

            //Console.WriteLine("Here is your claim id");
            //int counter = 0;

            //foreach (var claims in _claimrepo.GetClaimList())
            //{
            //    Console.WriteLine($"{counter}:{newClaim.ClaimType},\t{newClaim.Description},\t{newClaim.ClaimAmount},\t {newClaim.DateOfIncident},\t {newClaim.DateOfClaim},\t{newClaim.IsValid}"); counter++;
            //}
        }//FiN

    }
}

