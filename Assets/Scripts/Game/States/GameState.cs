using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.FSM
{
    public class GameState : State
    {
        private float timer;
        private bool timeRunning;

        private GameObject player;
        private Vector3 startPosition;

        public override void Init()
        {
            player = GameObject.Find("Player");
            startPosition = player.transform.position;
        }

        public override void Enter()
        {
            GameManager.Instance.UserInterface.GameUI.SetActive(true);
            player.transform.position = startPosition;
            StartTimer();
        }

        public override void Exit()
        {
            timeRunning = false;
            GameManager.Instance.UserInterface.GameUI.SetActive(false);
        }

        public override void Update()
        {
            if (timeRunning)
            {
                timer -= Time.deltaTime;
                //Debug.Log($"Time running: {timer} .Left: {(int)(timer % GameManager.Instance.GameLimitTime)}");
                GameManager.Instance.TimeLeft = (int)(timer % GameManager.Instance.GameLimitTime);

                if (GameManager.Instance.TimeLeft == 0)
                {
                    //GameManager.Instance.GameEnded?.Invoke();
                    Debug.Log($"Time finished.");
                    GameManager.Instance.StateMachine.ChangeState(GameStateMachine.StateEnum.Final);
                    timeRunning = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Escape))
                GameManager.Instance.StateMachine.ChangeState(GameStateMachine.StateEnum.Menu);
        }

        private void StartTimer()
        {
            timer = GameManager.Instance.GameLimitTime * 60;
            Debug.Log($"Timer defined: {timer} from {GameManager.Instance.GameLimitTime} ");
            GameManager.Instance.TimeLeft = GameManager.Instance.GameLimitTime;
            Debug.Log($"Time left: {GameManager.Instance.TimeLeft}");
            timeRunning = true;
        }

    }
}
