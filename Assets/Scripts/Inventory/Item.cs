using System;
using Interactions;
using UI;
using UnityEngine;

namespace Inventory
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemScriptable itemScriptable;

        private DialogueBox dialogueBox;
        private Collider2D collider2d;
        private ParticleSystem particles;

        private void Awake()
        {
            dialogueBox = FindObjectOfType<DialogueBox>();

            particles = GetComponent<ParticleSystem>();
            collider2d = GetComponent<Collider2D>();
        }

        private void Start()
        {
            if (InventoryUI.Instance.ContainsItem(itemScriptable))
            {
                Destroy(gameObject);
            }
        }

        public void Interact()
        {
            InventoryUI.Instance.AddItem(itemScriptable);
            collider2d.enabled = false;
            particles.Stop();
            StartCoroutine(dialogueBox.ShowPickupText(itemScriptable));
        }
    }
}
