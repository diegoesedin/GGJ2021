using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ.Data
{
    [CreateAssetMenu(fileName = "ClueSpriteData", menuName = "ScriptableObjects/ClueSpriteData", order = 4)]
    public class ClueSpriteData : SpriteData
    {
        public CrimeTypes.Weapons weapon;
        public CrimeTypes.Clues clue;
    }
}
