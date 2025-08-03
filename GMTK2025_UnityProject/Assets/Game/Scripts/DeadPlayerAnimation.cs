using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Game
{
    public class DeadPlayerAnimation : MonoBehaviour
    {
        [SerializeField] Vector3 m_finalPosition;
        [SerializeField] float m_moveDuration;
        [SerializeField] Ease m_moveEase;

        [SerializeField] float m_rotationSpeed;
        [SerializeField] Vector3 m_finalRotation;
        [SerializeField] Ease m_rotationEase;
        void Start()
        {
            transform.DOMove(m_finalPosition, m_moveDuration).SetEase(m_moveEase);
            transform.DORotate(m_finalRotation, m_rotationSpeed).
                SetEase(m_rotationEase).
                SetLoops(-1, LoopType.Incremental);
        }
    }
}
