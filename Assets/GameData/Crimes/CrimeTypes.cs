using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Crimes
{
    public class CrimeTypes
    {
        public enum Weapons
        {
            Knife,
            Pistol,
            Shotgun
        }

        public enum Genre
        {
            Man,
            Woman
        }

        public enum HairColor
        {
            Blonde,
            Black,
            Red
        }

        public enum Rooms
        {
            Kitchen,
            Bathroom,
            Bedroom,
            Playroom,
            Library,
            Office,
            LivingRoom,
            DiningRoom,
            Hall,
        }

        public enum Clues
        {
            BloodLine,
            BloodWall,
            Scratches,
            Spots,
        }
    }
}