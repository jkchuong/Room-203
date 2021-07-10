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

        public static SceneLoader Instance;

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
        }

        public void FadeSceneLoad(string sceneName)
        {
            StartCoroutine(Transition(sceneName));
        }

        private IEnumerator Transition(string sceneName)
        {
            yield return Fader.Instance.FadeOut(fadingTime);
            
            yield return SceneManager.LoadSceneAsync(sceneName);

            InventoryUI.Instance.ShowUI(false);
            DoorUI.Instance.ShowUI(false);
            
            yield return new WaitForSeconds(fadeWaitTime);
            
            yield return Fader.Instance.FadeIn(fadingTime);
        }
    }
}
