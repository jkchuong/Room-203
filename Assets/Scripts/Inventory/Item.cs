using System;
using Interactions;
using Managers;
using UI;
using UnityEngine;

namespace Inventory
{
    public class Item : MonoBehaviour, IInteractable
    {
        [Tooltip("The quest needed to be completed before being able to do this quest")]
        [SerializeField] private QuestProgression questBefore = QuestProgression.Default;
        
        [Tooltip("The quest that collecting this item will complete")]
        [SerializeField] private QuestProgression questAfter = QuestProgression.Default;
        
        [SerializeField] private ItemScriptable itemScriptable;
        [SerializeField] private AudioClip audioClip;

        private AudioSource audioSource;
        private DialogueBox dialogueBox;
        private Collider2D collider2d;
        private ParticleSystem particles;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            particles = GetComponent<ParticleSystem>();
            collider2d = GetComponent<Collider2D>();
        }

        private void Start()
        {
            dialogueBox = FindObjectOfType<DialogueBox>();

            if (InventoryUI.Instance.ContainsItem(itemScriptable))
            {
                Destroy(gameObject);
            }

            if (questBefore != QuestProgression.Default)
            {
                gameObject.SetActive(GameManager.Instance.QuestProgressions.Contains(questBefore));
            }
        }

        public void Interact()
        {
            InventoryUI.Instance.AddItem(itemScriptable);
            GameManager.Instance.QuestProgressions.Add(questAfter);
            audioSource.PlayOneShot(audioClip);
            
            collider2d.enabled = false;
            particles.Stop();
            StartCoroutine(dialogueBox.ShowPickupText(itemScriptable));
        }
    }
}
