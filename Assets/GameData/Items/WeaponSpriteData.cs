using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ.Data
{
    [CreateAssetMenu(fileName = "WeaponSpriteData", menuName = "ScriptableObjects/WeaponSpriteData", order = 5)]
    public class WeaponSpriteData : SpriteData
    {
        public CrimeTypes.Weapons weapon;
    }
}
