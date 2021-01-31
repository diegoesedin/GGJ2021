using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GGJ.UI
{
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private RectTransform canvasRect;

        private TextMeshProUGUI tooltipText;

        void Awake()
        {
            tooltipText = GetComponentInChildren<TextMeshProUGUI>();
        }
        public void ShowTooltip(string message, Vector3 position)
        {
            if (gameObject.activeInHierarchy || string.IsNullOrEmpty(message))
                return;

            float offsetPosY = position.y + 1.5f;
            Vector3 offsetPos = new Vector3(position.x, offsetPosY, position.z);
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);

            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

            gameObject.SetActive(true);
            transform.localPosition = canvasPos;
            tooltipText.text = message;
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }

    }

}
