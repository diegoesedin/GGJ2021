using System.Collections;
using System.Collections.Generic;
using GGJ;
using GGJ.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startGameBtn;
        [SerializeField] private Button exitGameBtn;

        void Start()
        {
            startGameBtn.onClick.AddListener(StartGame);
            exitGameBtn.onClick.AddListener(ExitGame);
        }

        private void StartGame()
        {
            GameManager.Instance.StateMachine.ChangeState(GameStateMachine.StateEnum.Game);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}