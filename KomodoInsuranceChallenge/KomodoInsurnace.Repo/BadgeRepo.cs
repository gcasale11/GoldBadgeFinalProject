using KomodoInsurnace.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurnace.Repo
{

    public class BadgeRepo
    {
        private Dictionary<int, Badge> _listOfbadges = new Dictionary<int, Badge>();

        
        public void CreateBadge(Badge badge)
        {
            badge.BadgeID = _listOfbadges.Count();

            _listOfbadges.Add(badge.BadgeID, badge);
        }

        //Read
        public Dictionary<int, Badge> GetBadgeList()
        {
            return _listOfbadges;
        }

        //Update
        public bool UpdateExistingBadge(int id, Badge newBadgeData)
        {
            //find badge
            Badge oldBadgeData = GetBadgeByID(id);

            //update badge
            if (oldBadgeData != null)
            {
                oldBadgeData.BadgeID = newBadgeData.BadgeID;
                oldBadgeData.BadgeFirstName = newBadgeData.BadgeFirstName;
                oldBadgeData.BadgeLastName = newBadgeData.BadgeLastName;
                oldBadgeData.DoorNames = newBadgeData.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveBadgeFromList(int id)
        {
            Badge badge = GetBadgeByID(id);

            if (badge == null)
            {
                return false;
            }

            int initialCount = _listOfbadges.Count;
            _listOfbadges.Remove(id);
            return true;
        }

        //helper method
        public Badge GetBadgeByID(int id)
        {
            foreach (KeyValuePair<int, Badge> badges in _listOfbadges)
            {
                if (_listOfbadges.TryGetValue(id, out Badge badge))
                {
                    return badge;
                }
                else
                    return null;
            }
            return null;


            //Delete all doors from an existing badge


        }
    }
}