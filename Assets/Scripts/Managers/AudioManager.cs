using System;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        private AudioSource audioSource;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayClipRepeat(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.loop = true;
        }
    }
}
