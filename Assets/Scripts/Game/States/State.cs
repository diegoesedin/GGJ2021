using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.FSM
{
    public abstract class State
    {
        public abstract void Init();
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
    }
}
