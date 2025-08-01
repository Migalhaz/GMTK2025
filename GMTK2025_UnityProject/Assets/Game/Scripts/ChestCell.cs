using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ChestCell : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
    {
        [SerializeField] ItemData m_itemData;
        [SerializeField] UnityEngine.UI.Image m_foregroundImage;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!m_itemData) return;
            Player.PlayerInventoryManager.Instance.AddItem(m_itemData);
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ItemNameShower.Instance.EnableRoot(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            ItemNameShower.Instance.EnableRoot(true);
            ItemNameShower.Instance.ShowItemName(m_itemData.m_name, eventData.position);
        }

        private void OnEnable()
        {
            if (!m_itemData) return;
            m_foregroundImage.sprite = m_itemData.m_ItemSprite;
        }
    }
}
