using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AlienAudio : MonoBehaviour
    {
        [SerializeField] List<AudioClip> m_allAlienSounds;

        public void PlayerRandomSound()
        {
            AudioClip clip = m_allAlienSounds.GetRandom();

            Camera cam = Camera.main;
            AudioSource.PlayClipAtPoint(clip, cam.transform.position);
        }
    }

}
