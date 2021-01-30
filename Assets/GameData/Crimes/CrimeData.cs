using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Crimes
{
    [CreateAssetMenu(fileName = "CrimeData", menuName = "ScriptableObjects/CrimeData", order = 1)]
    public class CrimeData : ScriptableObject
    {
        public CrimeTypes.Weapons Weapon;
        public CrimeTypes.Rooms Room;
        public CrimeTypes.Clues[] Clues;
        public CrimeTypes.Genre CriminalGenre;
        public CrimeTypes.Genre VictimGenre;
        public CrimeTypes.HairColor CriminalHairColor;
        public CrimeTypes.HairColor VictimHairColor;
    }
}
