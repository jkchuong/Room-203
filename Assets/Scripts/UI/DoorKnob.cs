using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DoorKnob : MonoBehaviour
    {
        [SerializeField] private AudioClip lockedDoorClip;
        [SerializeField] private AudioClip openedDoorClip;

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
            audioSource.PlayOneShot(GameManager.Instance.QuestProgressions.Contains(QuestProgression.Key)
                ? openedDoorClip
                : lockedDoorClip);
        }
    }
}