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

        public void InitRoom(Clue clue)
        {
            int randomPlacement = UnityEngine.Random.Range(0, objectPlaces.Length);

            clue.gameObject.transform.SetParent(objectPlaces[randomPlacement]);
        }

        public void InitCrime(CrimeTypes.Genre victimGenre, CrimeTypes.HairColor victimHair)
        {

        }
    }
}
