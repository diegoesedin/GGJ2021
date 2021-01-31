using System.Collections;
using System.Collections.Generic;
using GGJ.Crimes;
using GGJ.Items;
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

            while (objectPlaces[randomPlacement].childCount > 0)
            {
                randomPlacement = UnityEngine.Random.Range(0, objectPlaces.Length);
            }

            clue.gameObject.transform.SetParent(objectPlaces[randomPlacement]);
            clue.gameObject.transform.localPosition = Vector3.zero;
        }

        public void InitCrime(Victim victim)
        {
            int randomPlacement = UnityEngine.Random.Range(0, objectPlaces.Length);

            victim.gameObject.transform.SetParent(objectPlaces[randomPlacement]);
            victim.gameObject.transform.localPosition = Vector3.zero;
        }

        public void ClearCrimeScene()
        {
            foreach (Transform objectPlace in objectPlaces)
            {
                if (objectPlace.childCount > 0)
                {
                    for (int i = 0; i < objectPlace.childCount; i++)
                    {
                        Destroy(objectPlace.GetChild(i).gameObject);
                    }
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            GameManager.Instance.OnRoomEnter?.Invoke(RoomType);
        }
    }
}
