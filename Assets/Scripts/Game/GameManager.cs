using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GGJ.Crimes;
using GGJ.Data;
using GGJ.FSM;
using GGJ.Items;
using GGJ.UI;
using UnityEngine;

namespace GGJ
{
    [RequireComponent(typeof(GameStateMachine))]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public MainGameInterface UserInterface;
        public GameStateMachine StateMachine;

        public CrimeData CorrectCrime => crime;
        public CrimeData[] FakeCrimes;

        public int TimeLeft;
        public Action<CrimeTypes.Rooms> OnRoomEnter;

        [Header("Gameplay")]
        [SerializeField] public int GameLimitTime = 30;

        [Header("Crime Data")]
        [SerializeField] private List<Room.Room> rooms;

        private CrimeData crime;
        private Room.Room crimeRoom;

        [Header("Prefabs")]
        [SerializeField] public GameObject ItemPrefab;
        [SerializeField] public GameObject VictimPrefab;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                StateMachine = GetComponent<GameStateMachine>();
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
        }

        public void InitCrime()
        {
            CrimeData[] crimes = Resources.LoadAll<CrimeData>("CrimeData/");
            Debug.Log($"Crimes found: {crimes.Length}");
            int selectedCrime = UnityEngine.Random.Range(0, crimes.Length);

            crime = crimes[selectedCrime];

            FakeCrimes = GenerateFakeCrimes(crime);

            List<Room.Room> newGameRooms = new List<Room.Room>(rooms);
            InitCrimeScene(newGameRooms);

            GenerateRooms(newGameRooms);
        }

        public void ClearCrime()
        {
            foreach (Room.Room room in rooms)
            {
                room.ClearCrimeScene();
            }
        }

        private void InitCrimeScene(List<Room.Room> _rooms)
        {
            crimeRoom = _rooms.First(room => room.RoomType == crime.Room);
            _rooms.Remove(crimeRoom);

            Debug.Log($"Initialized crime in {crimeRoom.RoomType.ToString()}");

            crimeRoom.InitCrime(GetVictim(crime.VictimGenre, crime.VictimHairColor));
        }

        private Victim GetVictim(CrimeTypes.Genre victimGenre, CrimeTypes.HairColor hairColor)
        {
            VictimSpriteData[] victimSprites = Resources.LoadAll<VictimSpriteData>("SpriteData/VictimData/");
            Debug.Log($"Victims found for selection: {victimSprites.Length}");
            GameObject go = UnityEngine.MonoBehaviour.Instantiate(GameManager.Instance.VictimPrefab);
            Victim victim = go.GetComponent<Victim>();
            victim.DressVictim(victimSprites.First(data => data.genre == victimGenre && data.hairColor == hairColor).sprite);

            return victim;
        }

        private void GenerateRooms(List<Room.Room> _rooms)
        {
            Clue[] crimeClues = GetCluesFromTypes(crime.Clues);

            int randomRoom = 0;

            // Place clues in rooms
            for (int i = 0; i < crimeClues.Length; i++)
            {
                randomRoom = UnityEngine.Random.Range(0, _rooms.Count);
                _rooms[randomRoom].InitRoom(crimeClues[i]);
                _rooms.Remove(_rooms[randomRoom]);
            }

            // Place weapon in a room
            randomRoom = UnityEngine.Random.Range(0, _rooms.Count);
            _rooms[randomRoom].InitRoom(ClueFactory.GetClueByType(crime.Weapon));
            _rooms.Remove(_rooms[randomRoom]);

            // Place criminal clues in a room
            randomRoom = UnityEngine.Random.Range(0, _rooms.Count);
            _rooms[randomRoom].InitRoom(ClueFactory.GetClueByType(crime.VictimGenre, crime.VictimHairColor));
            _rooms.Remove(_rooms[randomRoom]);
        }

        private Clue[] GetCluesFromTypes(CrimeTypes.Clues[] cluesTypes)
        {
            Clue[] clues = new Clue[cluesTypes.Length];

            for (int i = 0; i < clues.Length; i++)
            {
                clues[i] = ClueFactory.GetClueByType(cluesTypes[i]);
            }

            return clues;
        }

        private CrimeData[] GenerateFakeCrimes (CrimeData correctCrime)
        {
            CrimeData secondCrime = new CrimeData();
            secondCrime.Room = correctCrime.Room;
            secondCrime.VictimHairColor = correctCrime.VictimHairColor;

            secondCrime.Weapon = (CrimeTypes.Weapons) ExcludeCorrectSelected(
                UnityEngine.Random.Range(0, GlobalSettings.MAX_WEAPONS),
                (int) correctCrime.Weapon,
                GlobalSettings.MAX_WEAPONS);

            secondCrime.VictimGenre = (CrimeTypes.Genre) UnityEngine.Random.Range(0, 2);
            secondCrime.CriminalGenre = (CrimeTypes.Genre) UnityEngine.Random.Range(0, 2);
            secondCrime.CriminalHairColor = (CrimeTypes.HairColor) UnityEngine.Random.Range(0, GlobalSettings.MAX_COLOR_HAIRS);


            CrimeData thirdCrime = new CrimeData();
            thirdCrime.Weapon = correctCrime.Weapon;

            thirdCrime.Room = (CrimeTypes.Rooms) ExcludeCorrectSelected(
                UnityEngine.Random.Range(0, GlobalSettings.MAX_ROOMS),
                (int)correctCrime.Room,
                GlobalSettings.MAX_ROOMS);

            thirdCrime.VictimGenre = (CrimeTypes.Genre)UnityEngine.Random.Range(0, 2);
            thirdCrime.VictimHairColor = (CrimeTypes.HairColor)UnityEngine.Random.Range(0, GlobalSettings.MAX_COLOR_HAIRS);
            thirdCrime.CriminalGenre = (CrimeTypes.Genre)UnityEngine.Random.Range(0, 2);
            thirdCrime.CriminalHairColor = (CrimeTypes.HairColor)UnityEngine.Random.Range(0, GlobalSettings.MAX_COLOR_HAIRS);

            return new[] {secondCrime, thirdCrime};
        }

        private int ExcludeCorrectSelected (int selected, int correct, int maxPossible)
        {
            if (selected == correct)
            {
                int selectionFixed = (selected < maxPossible) ? selected + 1 : 0;
                selectionFixed = ExcludeCorrectSelected(selectionFixed, correct, maxPossible);

                return selectionFixed;
            }

            return selected;
        }
    }
}
