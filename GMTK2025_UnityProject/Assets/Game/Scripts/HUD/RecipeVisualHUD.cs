using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RecipeVisualHUD : MonoBehaviour
    {
        [SerializeField] GameObject m_rootObject;
        [SerializeField] TMPro.TextMeshProUGUI m_recipeTitle;
        [SerializeField] TMPro.TextMeshProUGUI m_guestListText;
        [SerializeField] string m_guestListBaseText = "GUEST LIST:\n";
        private void OnEnable()
        {
            RecipeTargetObserver.OnRandomizeRecipe += SetupCanvas;

            SetupCanvas(RecipeTarget.Instance);
        }

        private void OnDisable()
        {
            RecipeTargetObserver.OnRandomizeRecipe -= SetupCanvas;
        }

        void SetupCanvas(RecipeTarget target)
        {
            m_recipeTitle.text = target.m_CurrentRecipe.m_name;
            m_guestListText.text = m_guestListBaseText;
            foreach (AlienData alien in target.m_CurrentAliensData)
            {
                m_guestListText.text += alien.m_name + '\n';
            }
        }
    }
}
