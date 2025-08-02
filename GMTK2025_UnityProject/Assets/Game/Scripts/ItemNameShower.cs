using MigalhaSystem.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ItemNameShower : Singleton<ItemNameShower>
    {
        [SerializeField] GameObject m_root;
        RectTransform m_rootRectTransform;
        [SerializeField] RectTransform m_canvasRectTransform;    

        [SerializeField] TextMeshProUGUI m_itemNameText;
        [SerializeField] Vector2 m_offset;

        protected override void Awake()
        {
            base.Awake();
            m_rootRectTransform = m_root.GetComponent<RectTransform>();
        }

        public void ShowItemName(string itemName, Vector2 screenPosition)
        {
            m_itemNameText.text = itemName;

            // Converte a posi��o da tela (mouse) para a posi��o local do Canvas.
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                m_canvasRectTransform,
                screenPosition,
                null, // Use a c�mera do canvas se for 'Screen Space - Camera'
                out Vector2 localPoint
            );

            // Define a posi��o ancorada do RectTransform com o offset.
            m_rootRectTransform.anchoredPosition = localPoint + m_offset;
        }

        public void EnableRoot(bool enabled)
        {
            m_root.SetActive(enabled);
        }
    }
}
