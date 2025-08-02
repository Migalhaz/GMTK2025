using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class CookInventoryCell : InventoryCellVisual, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
    {
        ItemNameShower m_itemNameShower => ItemNameShower.Instance;

        private void Start()
        {
            if (m_inventoryManager)
            {
                if (m_cellIndex >= m_inventoryManager.m_MaxItemCount)
                {
                    gameObject.SetActive(false);
                    return;
                }
                //if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
                //{
                //    gameObject.SetActive(false);
                //    return;
                //}
                //if (m_inventoryManager.m_PlayerItems[m_cellIndex] == null)
                //{
                //    gameObject.SetActive(false);
                //    return;
                //}
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                return;
            }
            PlayerHandObserver.RequestSetItemInHand(m_inventoryManager.m_PlayerItems[m_cellIndex]);
            OnPointerMove(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_itemNameShower?.EnableRoot(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                m_itemNameShower?.EnableRoot(false);
                return;
            }

            m_itemNameShower?.EnableRoot(true);
            m_itemNameShower?.ShowItemName(m_inventoryManager.m_PlayerItems[m_cellIndex].m_name, eventData.position);
        }
    }
}
