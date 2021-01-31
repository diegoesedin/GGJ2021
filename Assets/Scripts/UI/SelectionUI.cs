using System;
using System.Collections;
using System.Collections.Generic;
using GGJ;
using GGJ.Crimes;
using GGJ.FSM;
using GGJ.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GJJ.UI
{
    public class SelectionUI : MonoBehaviour
    {
        [SerializeField] private Button option1Btn;
        [SerializeField] private Button option2Btn;
        [SerializeField] private Button option3Btn;

        [SerializeField] private FinalResult result;

        private List<CrimeData> crimeList;

        private string correctCrimeTitle;

        void Start()
        {
            option1Btn.onClick.AddListener(() => SelectOption(0));
            option2Btn.onClick.AddListener(() => SelectOption(1));
            option3Btn.onClick.AddListener(() => SelectOption(2));
            result.HideAll();
        }

        private void SelectOption(int selectedOption)
        {
            CrimeData selectedCrime = crimeList[selectedOption];

            if (selectedCrime == GameManager.Instance.CorrectCrime)
            {
                //GameManager.Instance.StateMachine.ChangeState(GameStateMachine.StateEnum.Menu);
                Debug.Log("Selection");
                result.ShowVictory(correctCrimeTitle);
            }
            else
            {
                result.ShowDefeat(correctCrimeTitle);
            }
        }

        public void InitSelectionUI(Dictionary<CrimeData, string> crimes)
        {
            result.HideAll();
            correctCrimeTitle = crimes[GameManager.Instance.CorrectCrime];
            List<CrimeData> crimesData = new List<CrimeData>();
            foreach (KeyValuePair<CrimeData, string> valuePair in crimes)
            {
                crimesData.Add(valuePair.Key);
            }
            crimesData.Shuffle();

            crimeList = crimesData;

            option1Btn.GetComponentInChildren<Text>().text = crimes[crimesData[0]];
            option2Btn.GetComponentInChildren<Text>().text = crimes[crimesData[1]];
            option3Btn.GetComponentInChildren<Text>().text = crimes[crimesData[2]];
        }
    }

}