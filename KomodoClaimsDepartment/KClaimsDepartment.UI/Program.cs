using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaimsDepartment.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI UI = new ProgramUI();
            UI.Run();

            //Queue claimListings = new Queue();
            //claimListings.Enqueue(1);
            //claimListings.Enqueue(2);
            //claimListings.Enqueue(3);

            //foreach (Claim claim in claimListings)
            //{
            //    Console.WriteLine(claim);
            //}
            //Console.WriteLine("The number of elements in the Queue" + claimListings.Count);
        }
    }
}
