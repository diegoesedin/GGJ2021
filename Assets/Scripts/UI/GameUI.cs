using System.Collections;
using System.Collections.Generic;
using GGJ;
using GGJ.Crimes;
using TMPro;
using UnityEngine;

namespace GGJ.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI locationText;

        void Start()
        {
            GameManager.Instance.OnRoomEnter += ChangeLocation;
        }

        void Update()
        {
            timerText.text = $"00:{GameManager.Instance.TimeLeft:00}";
        }

        private void ChangeLocation(CrimeTypes.Rooms room)
        {
            locationText.text = room.ToString();
        }
    }
}