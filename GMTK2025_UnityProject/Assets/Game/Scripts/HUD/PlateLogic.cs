using DG.Tweening;
using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PlateLogic : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Recipe m_currentRecipe;
        [SerializeField] UnityEngine.UI.Image m_plateVisual;
        [SerializeField] Sprite m_plateSprite;

        [SerializeField] GameObject m_textBackground;
        [SerializeField] TMPro.TextMeshProUGUI m_ingredientsText;
        [SerializeField] AudioSource m_audioSource;

        bool m_showIngredients = false;
        Tween m_currentTween;
        [SerializeField] Vector3 m_finalScale = new Vector3(1.1f, 1.1f, 1.1f);
        [SerializeField] float m_animationDuration = 0.3f;
        private void Awake()
        {
            m_showIngredients = false;
            m_audioSource ??= GetComponent<AudioSource>();
        }

        public void OnPointerEnter(PointerEventData eventData) => OnPointerMove(eventData);

        public void OnPointerExit(PointerEventData eventData)
        {
            m_showIngredients = false;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            m_showIngredients = true;
        }

        void ShowIngredients()
        {
            if (m_currentRecipe?.m_RecipeIngredients == null || m_currentRecipe?.m_RecipeIngredients.Count <= 0 || !m_showIngredients)
            {
                m_textBackground.SetActive(false);
                m_ingredientsText.text = string.Empty;
                return;
            }
            m_showIngredients = true;
            m_textBackground.SetActive(true);
            m_ingredientsText.text = string.Empty;
            foreach (ItemData item in m_currentRecipe.m_RecipeIngredients)
            {
                m_ingredientsText.text += $". {item.m_name}\n";
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (m_currentRecipe == null || m_currentRecipe.m_RecipeIngredients.Count <= 0)
            {
                return;
            }

            Recipe recipeInHand = PlayerHandObserver.GetRecipeInHand();
            if (recipeInHand != null && recipeInHand.m_RecipeIngredients.Count > 0)
            {
                return;
            }

            PlayerHandObserver.RequestSetRecipeInHand(m_currentRecipe);
            m_currentRecipe = null;
        }

        public bool TrySetRecipe(Recipe recipe)
        {
            if (HasRecipe()) return false;
            m_audioSource.Play();
            m_currentRecipe = recipe;
            return true;
        }

        bool HasRecipe()
        {
            if (m_currentRecipe == null) return false;
            if (m_currentRecipe.m_RecipeIngredients.Count <= 0) return false;
            return true;
        }

        private void Update()
        {
            UpdateVisual();
            ShowIngredients();
        }

        void UpdateVisual()
        {
            RecipeData recipeData = RecipeTarget.Instance.m_CurrentRecipe;
            Sprite currentSprite = HasRecipe()? recipeData.m_RecipeImage : m_plateSprite;
            m_plateVisual.sprite = currentSprite;

            if (HasRecipe())
            {
                m_currentTween ??= transform.DOScale(m_finalScale, m_animationDuration).SetLoops(-1, LoopType.Yoyo);
            }
            else
            {
                m_currentTween?.Kill();
                m_currentTween = null;
                transform.localScale = Vector3.one;
            }
        }
    }
}
