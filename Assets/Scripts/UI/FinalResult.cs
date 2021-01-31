using System.Collections;
using System.Collections.Generic;
using GGJ.FSM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ.UI
{
    public class FinalResult : MonoBehaviour
    {
        [SerializeField] private GameObject resultGO;
        [SerializeField] private TextMeshProUGUI textResult;
        [SerializeField] private GameObject victory;
        [SerializeField] private GameObject defeat;

        [SerializeField] private Text paperCorrectText;

        [SerializeField] private Button finishButton;

        void Start()
        {
            finishButton.onClick.AddListener(Finish);
        }

        public void ShowVictory(string correctCrime)
        {
            resultGO.SetActive(true);
            Debug.Log("Victory");
            textResult.text = "Victory";
            paperCorrectText.text = correctCrime;
            this.defeat.SetActive(false);
            this.victory.SetActive(true);
        }

        public void ShowDefeat(string correctCrime)
        {
            resultGO.SetActive(true);
            Debug.Log("Defeat");
            textResult.text = "Defeat";
            paperCorrectText.text = correctCrime;
            this.victory.SetActive(false);
            this.defeat.SetActive(true);
        }

        public void HideAll()
        {
            resultGO.SetActive(false);
            this.victory.SetActive(false);
            this.defeat.SetActive(false);
        }

        private void Finish()
        {
            GameManager.Instance.StateMachine.ChangeState(GameStateMachine.StateEnum.Menu);
        }
    }
}
