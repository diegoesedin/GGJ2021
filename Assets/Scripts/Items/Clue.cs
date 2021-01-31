using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace GGJ.Items
{
    public class Clue : MonoBehaviour
    {
        public string description;

        private bool isShowed;
        public virtual void Showed()
        {
            GameManager.Instance.UserInterface.GameTooltip.ShowTooltip(description, transform.position);
            if (!isShowed)
            {
                DOVirtual.DelayedCall(1f, () =>
                {
                    GameManager.Instance.UserInterface.GameTooltip.HideTooltip();
                    isShowed = false;
                });
                isShowed = true;
            }
        }
    }
}
