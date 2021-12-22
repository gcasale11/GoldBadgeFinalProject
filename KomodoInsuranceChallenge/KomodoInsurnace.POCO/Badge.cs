using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurnace.POCO
{
    
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }

        public string BadgeFirstName { get; set; }

        public string BadgeLastName { get; set; }

        public Badge() { }
        public Badge(int badgeid, List<string> doorNames, string badgeFirstName, string badgeLastName)
        {
            BadgeID = badgeid;
            DoorNames = doorNames;
            BadgeFirstName = badgeFirstName;
            BadgeLastName = badgeLastName;
        }
    }
}
