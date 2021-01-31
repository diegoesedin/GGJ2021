using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ.Data
{
    [CreateAssetMenu(fileName = "VictimSpriteData", menuName = "ScriptableObjects/VictimSpriteData", order = 2)]
    public class VictimSpriteData : SpriteData
    {
        public CrimeTypes.HairColor hairColor;
        public CrimeTypes.Genre genre;
    }
}
