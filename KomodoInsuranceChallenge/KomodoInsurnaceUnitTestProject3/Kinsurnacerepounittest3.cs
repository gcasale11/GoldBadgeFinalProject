using KomodoInsurnace.POCO;
using KomodoInsurnace.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsurnaceUnitTestProject3
{
    [TestClass]
    public class Kinsurnacerepounittest3
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        private Badge _badge = new Badge();

        public void SeedData()
        {
            List<string> doors = new List<string>();

            doors.Add("a1");
            doors.Add("apple");
            doors.Add("pineapple");


            Badge badge1 = new Badge(246,  new List<string> { "Grey", "Cameo" }, "Grace", "Casale");
            Badge badge2 = new Badge(346, new List<string> { "Apple", "Pie" }, "Grace", "Cats");
            Badge badge3 = new Badge(456, doors, "Diamond", "Pear");
            _badgeRepo.CreateBadge(badge1);
            _badgeRepo.CreateBadge(badge2);
            _badgeRepo.CreateBadge(badge3);

        }
        [TestMethod]
        public void CreateBadge_ShouldReturnTrue()
        {
            _badgeRepo.CreateBadge
        }

        [TestMethod]
        public void GetBadgeList_ShouldREturnNotNUll()
        {
            SeedData();

            var isTrue = _badgeRepo.GetBadgeList();

            Assert.IsNotNull(isTrue);
        }

        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            Badge badge1 = new Badge(246, new List<string> { "Grey", "Cameo" }, "Grace", "Casale");

            bool expected = true;

            bool actual = _badgeRepo.UpdateExistingBadge(246, badge1);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void RemoveBadge_ResultInTrue()
        {
            SeedData();
            var expected = 2;


            bool removed = _badgeRepo.RemoveBadgeFromList(1);
            var actual = 2;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(removed);

        }
    }
}
