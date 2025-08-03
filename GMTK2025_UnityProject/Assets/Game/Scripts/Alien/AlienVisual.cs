using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AlienVisual : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] UnityEngine.UI.Image m_headImage;
        [SerializeField] UnityEngine.UI.Image m_bodyImage;
        [SerializeField] UnityEngine.UI.Image m_eyeImage;
        [SerializeField] UnityEngine.UI.Image m_mouthImage;
        [SerializeField] UnityEngine.UI.Image m_headAddon;
        [SerializeField] UnityEngine.UI.Image m_accessory;
        [SerializeField] UnityEngine.UI.Image m_fillBar;
        [SerializeField] Color m_startValue = Color.green;
        [SerializeField] Color m_endValue = Color.red;


        [SerializeField] List<Sprite> m_accessoriesSprites;
        [SerializeField, Range(0, 100)] float m_accessoryChance = 50; 
        
        public void SetVisual(AlienData currentData)
        {
            m_headImage.sprite = currentData?.m_HeadSprite;
            m_bodyImage.sprite = currentData?.m_BodySprite;
            m_headAddon.sprite = currentData?.m_HeadAddonSprite;
            m_eyeImage.sprite = currentData?.m_EyeSprite;
            m_mouthImage.sprite = currentData?.m_MouthSprite;

            m_headImage.color = currentData?.m_SkinColor ?? Color.white;
            m_bodyImage.color = currentData?.m_SkinColor ?? Color.white;
            m_headAddon.color = currentData?.m_SkinColor ?? Color.white;
            

            m_headImage.enabled = m_headImage.sprite;
            m_bodyImage.enabled = m_bodyImage.sprite;
            m_eyeImage.enabled = m_eyeImage.sprite;
            m_mouthImage.enabled = m_mouthImage.sprite;
            m_headAddon.enabled = m_headAddon.sprite;

            bool useAccessory = UseAccessory();

            m_accessory.enabled = useAccessory;

            if (!useAccessory) return;
            if (m_accessoriesSprites == null || m_accessoriesSprites.Count <= 0) return;
            m_accessory.sprite = m_accessoriesSprites?.GetRandom();
        }

        bool UseAccessory() => Random.value * 100 < m_accessoryChance;

        public void UpdateFill(float fillAmount)
        {
            m_fillBar.color = Color.Lerp(m_startValue, m_endValue, fillAmount);
            m_fillBar.fillAmount = fillAmount;
        }
    }
}
