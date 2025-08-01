using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ShowItemName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] ItemData m_data;

        public void SetData(ItemData newData) => m_data = newData;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (m_data == null) return;
            if (ItemNameShower.Instance == null) return;
            ItemNameShower.Instance.EnableRoot(true);
            ItemNameShower.Instance.ShowItemName(m_data.m_name, eventData.position);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (m_data == null) return;
            if (ItemNameShower.Instance == null) return;
            ItemNameShower.Instance.EnableRoot(false);
        }
    }
}
