using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GGJ.Crimes;
using UnityEngine;

namespace GGJ
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Gameplay")]
        [SerializeField] private int gameLimitTime;

        public int TimeLeft;

        private float timer;
        private bool timeRunning;

        [Header("Crime Data")]
        [SerializeField] private List<Room.Room> rooms;

        private CrimeData crime;
        private Room.Room crimeRoom;

        public Action GameEnded;

        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }

            StartTimer();

            CrimeData[] crimes = Resources.LoadAll<CrimeData>("/");
            //Debug.Log($"Crimes found: {crimes.Length}");

            int selectedCrime = UnityEngine.Random.Range(0, crimes.Length);
            InitCrime(crimes[selectedCrime]);
        }

        void Update()
        {
            if (timeRunning)
            {
                timer -= Time.deltaTime;
                TimeLeft = (int)(timer % 60f);

                if (timer <= 0)
                {
                    GameEnded?.Invoke();
                    timeRunning = false;
                }
            }
        }

        public void InitCrime(CrimeData _crime)
        {
            crime = _crime;

            InitCrimeScene();

            GenerateRooms();
        }

        private void InitCrimeScene()
        {
            crimeRoom = rooms.First(room => room.RoomType == crime.Room);
            rooms.Remove(crimeRoom);

            crimeRoom.InitCrime(crime.VictimGenre, crime.VictimHairColor);
        }

        private void GenerateRooms()
        {
            /*foreach (Room.Room room in rooms)
            {
                room.InitRoom();
            }*/

            int randomRoom = UnityEngine.Random.Range(0, rooms.Count);
            rooms[randomRoom].InitRoom(GetCluesFromTypes(crime.Clues));
            rooms.Remove(rooms[randomRoom]);
        }

        private Clue GetCluesFromTypes(CrimeTypes.Clues[] cluesTypes)
        {
            Clue[] clues = new Clue[cluesTypes.Length];

            for (int i = 0; i < clues.Length; i++)
            {
                // todo init clues
                //clues[i]
            }

            return clues[0];
        }

        private void StartTimer()
        {
            timer = gameLimitTime * 60;
            TimeLeft = gameLimitTime;
            timeRunning = true;
        }
    }
}
