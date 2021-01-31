using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Crimes
{
    public class Victim : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer clothesPlace;
        public void DressVictim(Sprite clothes)
        {
            clothesPlace.sprite = clothes;
        }
    }
}
