using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.FSM
{
    public class MenuState : State
    {
        public override void Init()
        {
        }

        public override void Enter()
        {
            GameManager.Instance.UserInterface.MenuUI.SetActive(true);
        }

        public override void Exit()
        {
            GameManager.Instance.UserInterface.MenuUI.SetActive(false);
            GameManager.Instance.InitCrime();
        }

        public override void Update()
        {
        }
    }
}