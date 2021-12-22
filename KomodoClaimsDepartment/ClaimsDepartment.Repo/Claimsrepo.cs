using KClaimsDepartment.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDepartment.Repo
{
    public class Claimsrepo
    {
        private readonly Queue<Claims> _listOfClaims = new Queue<Claims>();
        private int _count = 1;

        //Create

        public bool CreateClaim(Claims claim)
        {
            if (claim == null)
            {
                return false;
            }
            _count++;
            claim.ClaimID = _count;
            _listOfClaims.Enqueue(claim);
            return true;
        }

        //Read
        public Queue<Claims> GetClaimList()
        {
            return _listOfClaims;
        }


        //public Claims GetClaimById(int id)
        //{
        //    foreach (Claims claim in _listOfClaims)
        //    {
        //        if (id == claim.ClaimID)
        //        {
        //            return claim;
        //        }
        //    }
        //    return null;
        //}
        //Update
        //public bool UpdateClaimByID(int id, Claims newClaimData)

        //{
        //    Claims oldClaimData = GetClaimById(id);
        //    if (oldClaimData != null)
        //    {
        //        oldClaimData.ClaimID = newClaimData.ClaimID;
        //        oldClaimData.ClaimType = newClaimData.ClaimType;
        //        oldClaimData.Description = newClaimData.Description;
        //        oldClaimData.ClaimAmount = newClaimData.ClaimAmount;
        //        oldClaimData.DateOfIncident = newClaimData.DateOfIncident;
        //        oldClaimData.DateOfClaim = newClaimData.DateOfClaim;
        //        oldClaimData.IsValid = newClaimData.IsValid;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //Delete
        public bool RemoveClaimFromList()
        {
            _listOfClaims.Dequeue();
            return true;

        }

    }
}
