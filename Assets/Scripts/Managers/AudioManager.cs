using System.Collections;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private float volume;
        [SerializeField] private AudioClip audioClip;

        private float time = 0.7f;
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

        private void Start()
        {
            if (audioClip)
            {
                PlayClipRepeat(audioClip);
            }
        }

        public void PlayClipRepeat(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
        }

        public IEnumerator MuteAudio()
        {
            while (audioSource.volume > 0)
            {
                audioSource.volume -= Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator PlayAudio()
        {
            while (audioSource.volume < volume)
            {
                audioSource.volume += Time.deltaTime / time;
                yield return null;
            }
        }
    }
}
