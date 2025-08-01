using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] Animator m_playerAnimator;
        [SerializeField] SpriteRenderer m_spriteRenderer;
        Vector2 m_moveDirection;

        public void SetMoveDirection(Vector2 newMoveDirection) => m_moveDirection = newMoveDirection;

        private void Update()
        {
            bool isMoving = m_moveDirection.sqrMagnitude != 0;
            if (isMoving)
            {
                m_playerAnimator.SetFloat("xMoveDirection", m_moveDirection.x);
                m_playerAnimator.SetFloat("yMoveDirection", m_moveDirection.y);

                m_spriteRenderer.flipX = m_moveDirection.x < 0;
            }
            m_playerAnimator.SetBool("isMoving", isMoving);
        }

    }
}
