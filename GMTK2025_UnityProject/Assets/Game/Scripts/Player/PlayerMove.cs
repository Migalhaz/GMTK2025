using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField, Min(0)] float m_moveSpeed;
        Vector2 m_moveDirection;
        [SerializeField] Rigidbody2D m_rig;
        [SerializeField] PlayerAnimation m_playerAnimation;

        void Update()
        {
            InputListener();
        }

        private void FixedUpdate()
        {
            Move();
        }

        void InputListener()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            m_moveDirection.Set(x, y);
            m_moveDirection.Normalize();

            m_playerAnimation.SetMoveDirection(m_moveDirection);
        }

        void Move()
        {
            float finalSpeed = m_moveSpeed;
            m_rig.velocity = finalSpeed * m_moveDirection;
        }

        private void Reset()
        {
            TryGetComponent(out m_rig);
        }
    }
}
