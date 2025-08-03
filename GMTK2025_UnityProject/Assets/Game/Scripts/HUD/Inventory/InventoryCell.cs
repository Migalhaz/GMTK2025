using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class InventoryCell : InventoryCellVisual, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                return;
            }

            m_audioManager.PlayClickSound();
            m_inventoryManager.m_PlayerItems.RemoveAt(m_cellIndex);
            OnPointerMove(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ItemNameShower.Instance?.EnableRoot(false);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                ItemNameShower.Instance?.EnableRoot(false);
                return;
            }

            ItemNameShower.Instance?.EnableRoot(true);
            ItemNameShower.Instance.ShowItemName(m_inventoryManager.m_PlayerItems[m_cellIndex].m_name, eventData.position);
        }
    }
}
