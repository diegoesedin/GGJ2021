using System.Collections;
using System.Collections.Generic;
using GGJ;
using TMPro;
using UnityEngine;

namespace GGJ.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        void Update()
        {
            timerText.text = $"00:{GameManager.Instance.TimeLeft:00}";
        }
    }
}