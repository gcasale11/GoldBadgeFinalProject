using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaimsDepartment.POCO
{
    public enum ClaimType { Car = 1, Home, Theft };
    public class Claims
    {
        public int ClaimID { get; set; }

        public ClaimType ClaimType { get; set; }

        public string Description { get; set; }

        public double ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                //find out how many days has been from claim and incident
                TimeSpan daysBetween =  DateOfClaim - DateOfIncident; 
                //set the claim accordingly.
                if (daysBetween.TotalDays < 30)
                {
                    return true;
                }
                return false;
            }
        }

        public Claims() { }
        public Claims(int claimid, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimid;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }
}
