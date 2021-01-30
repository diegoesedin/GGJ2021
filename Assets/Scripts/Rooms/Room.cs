using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ.Room
{
    public class Room : MonoBehaviour
    {
        [SerializeField] public CrimeTypes.Rooms RoomType;
        [SerializeField] private Transform[] objectPlaces;

        public void InitRoom(Clue[] clues)
        {

        }
    }
}
