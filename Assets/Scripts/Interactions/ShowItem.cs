using System;
using Inventory;
using Managers;
using UI;
using UnityEngine;

namespace Interactions
{
    public class ShowItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool interactImmediate;
        [SerializeField] private bool destroyAfterUse;
        [SerializeField] private AudioClip audioClip;

        [Tooltip("The quest needed to be completed before doing this.")]
        [SerializeField] private QuestProgression questBefore = QuestProgression.Default;
        
        [Tooltip("The quest that this will complete")]
        [SerializeField] private QuestProgression questAfter;
        
        [SerializeField] private GameObject itemToShow;

        [TextArea(5, 12)]
        [SerializeField] private string dialogueBefore;
        
        [TextArea(5, 12)]
        [SerializeField] private string dialogueAfter;

        [SerializeField] private float duration = 5f;

        [Header("Before and After interacting")]
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite beforeSprite;
        [SerializeField] private Sprite afterSprite;
        
        private DialogueBox dialogueBox;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            dialogueBox = FindObjectOfType<DialogueBox>();
            
            if (beforeSprite)
            {
                spriteRenderer.sprite = beforeSprite;
            }

            if (itemToShow)
            {
                itemToShow.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && interactImmediate)
            {
                Interact();
            }
        }

        public void Interact()
        {
            // if this quest has already been done
            if (GameManager.Instance.QuestProgressions.Contains(questAfter))
            {
                if (destroyAfterUse)
                {
                    Destroy(gameObject);
                }

                if (!string.IsNullOrEmpty(dialogueAfter))
                {
                    StartCoroutine(dialogueBox.ShowDialogue(dialogueAfter, duration));
                }
            }
            // if quest has the correct prerequisites
            else if (GameManager.Instance.QuestProgressions.Contains(questBefore))
            {
                if (!string.IsNullOrEmpty(dialogueBefore))
                {
                    StartCoroutine(dialogueBox.ShowDialogue(dialogueBefore, duration));
                }
                
                GameManager.Instance.QuestProgressions.Add(questAfter);

                if (afterSprite)
                {
                    spriteRenderer.sprite = afterSprite;
                }

                if (itemToShow)
                {
                    itemToShow.SetActive(true);
                }
            }
            
            if (audioClip)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
