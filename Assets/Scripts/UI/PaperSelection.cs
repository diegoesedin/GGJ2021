using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GGJ.UI
{
    public class PaperSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerEnter(PointerEventData eventData)
        {
            this.transform.DOScale(1.2f, 0.5f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.transform.DOScale(1f, 0.5f);
        }
    }
}
