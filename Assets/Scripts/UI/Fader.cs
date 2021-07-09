using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Sprite faderImage;
        [SerializeField] private Image imageComponent;
        private CanvasGroup canvasGroup;

        public static Fader Instance;

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
            
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            imageComponent.sprite = faderImage;
        }

        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }
}
