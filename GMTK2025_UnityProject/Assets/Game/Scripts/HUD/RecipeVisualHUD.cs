using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RecipeVisualHUD : MonoBehaviour
    {
        [SerializeField] GameObject m_rootObject;
        [SerializeField] TMPro.TextMeshProUGUI m_recipeTitle;
        [SerializeField] List<TMPro.TextMeshProUGUI> m_alienNames;

        private void OnEnable()
        {
            RecipeTargetObserver.OnRandomizeRecipe += SetupCanvas;
        }

        private void OnDisable()
        {
            RecipeTargetObserver.OnRandomizeRecipe -= SetupCanvas;
        }

        void SetupCanvas(RecipeTarget target)
        {
            m_rootObject.gameObject.SetActive(true);
            m_recipeTitle.text = target.m_CurrentRecipe.m_name;
            
            int alienCount = target.m_CurrentAliensData.Count;
            for (int i = 0; i < m_alienNames.Count; ++i)
            {
                bool inAlienCount = i < alienCount;
                m_alienNames[i].gameObject.SetActive(inAlienCount);
                if (!inAlienCount) continue;
                m_alienNames[i].text = target.m_CurrentAliensData[i].m_name;
            }
        }

        public void SwitchRootEnable()
        {
            m_rootObject.SetActive(!m_rootObject.activeSelf);
        }
    }
}
