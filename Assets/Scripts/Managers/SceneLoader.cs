using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private float fadingTime = 0.8f;
        [SerializeField] private float fadeWaitTime = 0.5f;
        [SerializeField] private AudioClip doorClip;
        
        public static SceneLoader Instance;

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

        public void FadeSceneLoad(string sceneName)
        {
            StartCoroutine(Transition(sceneName));
        }

        private IEnumerator Transition(string sceneName)
        {
            yield return Fader.Instance.FadeOut(fadingTime);
            
            yield return SceneManager.LoadSceneAsync(sceneName);

            audioSource.PlayOneShot(doorClip);

            if (InventoryUI.Instance.isShown)
            {
                InventoryUI.Instance.SetUI();
            }

            if (DoorUI.Instance.isShown)
            {
                DoorUI.Instance.SetUI();
            }
            
            yield return new WaitForSeconds(fadeWaitTime);
            
            yield return Fader.Instance.FadeIn(fadingTime);
        }
    }
}
