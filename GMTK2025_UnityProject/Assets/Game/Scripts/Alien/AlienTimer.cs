using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AlienTimer : MonoBehaviour
    {
        [SerializeField, Min(0)] float m_minTimeToSpawn;
        [SerializeField, Min(0)] float m_maxTimeToSpawn;
        float m_currentTime;

        [SerializeField] List<AlienLogic> m_alienLogics;


        private void Update()
        {
            m_currentTime -= Time.deltaTime;
            if (m_currentTime <= 0)
            {
                SpawnAlien();
                StartTime();
            }
        }

        void SpawnAlien()
        {
            AlienLogic alienLogic = m_alienLogics.GetRandom();
            if (alienLogic.gameObject.activeSelf)
            {
                return;
            }

            alienLogic.gameObject.SetActive(true);
        }

        void StartTime()
        {
            m_currentTime = Random.Range(m_minTimeToSpawn, m_maxTimeToSpawn);
        }
    }
}
