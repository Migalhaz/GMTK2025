using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PreparationSceneLogic : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI m_title;
        [SerializeField, TextArea(3, 10)] string m_startText;
        [SerializeField, TextArea(3, 10)] string m_endText;

        void Start()
        {
            
            string strikesValue = PlayerInventoryManager.Instance.m_StrikeCount.ToString();
            m_title.text = $"{m_startText} {strikesValue} {m_endText}";
        }

    }
}
