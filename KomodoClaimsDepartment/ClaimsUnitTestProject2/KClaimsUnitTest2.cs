using ClaimsDepartment.Repo;
using KClaimsDepartment.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimsUnitTestProject2
{
    [TestClass]
    public class KClaimsUnitTest2
    {
        private readonly Claimsrepo _claimsrepo = new Claimsrepo();
        private readonly Claims _claims = new Claims();
        public void SeedData()
        {

  
            Claims claim1 = new Claims(1, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

        }

       
        [TestMethod]
        public void CreateMenuItem_ShouldReturnTrue()
        {

            Claims claim1 = new Claims(1, ClaimType.Car, "Car accident on 465", 400, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);

            bool expected = true;

            bool actual = _claimsrepo.CreateClaim(claim1);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetClaimList_ShouldREturnNotNUll()
        {
            SeedData();

            var isTrue = _claimsrepo.GetClaimList();

            Assert.IsNotNull(isTrue);
        }

        [TestMethod]

        public void RemoveClaim_ResultInTrue()
        {
            SeedData();
            var expected = 2;


            bool removed = _claimsrepo.RemoveClaimFromList();
            var actual = 2;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(removed);

        }
    }
}
