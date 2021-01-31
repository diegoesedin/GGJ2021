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
            Bat,
            Poison,
            Hands
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
            Brown,
            Red,
            Orange,
            Purple,
            Blue,
            Green
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
            BloodSpot,
            BloodHand,
            BloodFeet,
            BulletsHoles,
            PoisonSpot,
        }
    }
}