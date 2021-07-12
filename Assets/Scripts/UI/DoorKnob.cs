using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DoorKnob : MonoBehaviour
    {
        [SerializeField] private AudioClip lockedDoorClip;
        [SerializeField] private AudioClip openedDoorClip;
        [SerializeField] private AudioClip birdsClip;

        private AudioSource audioSource;
        private Button btn;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            btn = GetComponent<Button>();
        }

        private void Start()
        {
            btn.onClick.AddListener(UnlockDoor);
        }

        private void UnlockDoor()
        {
            if (GameManager.Instance.QuestProgressions.Contains(QuestProgression.Key))
            {
                StartCoroutine(PlayEscapeAudio());
                SceneLoader.Instance.FadeSceneLoad("Menu");
            }
            else
            {
                audioSource.PlayOneShot(lockedDoorClip);
            }
        }

        private IEnumerator PlayEscapeAudio()
        {
            audioSource.PlayOneShot(openedDoorClip);

            yield return new WaitForSeconds(1f);
            
            audioSource.PlayOneShot(birdsClip);
        }
    }
}