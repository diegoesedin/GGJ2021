using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ.Data
{
    [CreateAssetMenu(fileName = "HairSpriteData", menuName = "ScriptableObjects/HairSpriteData", order = 3)]
    public class HairSpriteData : SpriteData
    {
        public CrimeTypes.HairColor hairColor;
        public CrimeTypes.Genre genre;
    }
}
