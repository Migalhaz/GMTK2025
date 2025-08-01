using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class InventoryCell : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
    {
        [SerializeField, Min(0)] int m_cellIndex;
        [SerializeField] UnityEngine.UI.Image m_foregroundItemImage;
        PlayerInventoryManager m_inventoryManager => PlayerInventoryManager.Instance;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                return;
            }

            m_inventoryManager.m_PlayerItems.RemoveAt(m_cellIndex);
            OnPointerMove(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ItemNameShower.Instance.EnableRoot(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                ItemNameShower.Instance.EnableRoot(false);
                return;
            }

            ItemNameShower.Instance.EnableRoot(true);
            ItemNameShower.Instance.ShowItemName(m_inventoryManager.m_PlayerItems[m_cellIndex].m_name, eventData.position);
        }

        private void OnEnable()
        {
            UpdateVisual();
        }
        private void Update()
        {
            UpdateVisual();
        }

        void UpdateVisual()
        {
            if (m_inventoryManager == null) return;
            
            if (m_cellIndex >= m_inventoryManager.m_MaxItemCount)
            {
                gameObject.SetActive(false);
                return;
            }

            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                m_foregroundItemImage.enabled = false;
                m_foregroundItemImage.sprite = null;
            }
            else
            {
                m_foregroundItemImage.enabled = true;
                m_foregroundItemImage.sprite = m_inventoryManager.m_PlayerItems[m_cellIndex].m_ItemSprite;
            }
        }
    }
}
