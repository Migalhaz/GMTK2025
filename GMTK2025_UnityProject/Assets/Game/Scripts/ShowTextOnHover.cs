using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ShowTextOnHover : MonoBehaviour, IPointerExitHandler, IPointerMoveHandler
    {
        [SerializeField] string m_showText;
        public void OnPointerExit(PointerEventData eventData)
        {
            ItemNameShower.Instance?.EnableRoot(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {

            ItemNameShower.Instance?.EnableRoot(true);
            ItemNameShower.Instance.ShowItemName(m_showText, eventData.position);
        }
    }
}
