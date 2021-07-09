using UI;
using UnityEngine;

namespace Inventory
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemScriptable itemScriptable;

        private DialogueBox dialogueBox;
        private Collider2D collider2d;
        private InventoryUI inventoryUI;
        private ParticleSystem particles;

        private void Awake()
        {
            dialogueBox = FindObjectOfType<DialogueBox>();
            inventoryUI = FindObjectOfType<InventoryUI>();

            particles = GetComponent<ParticleSystem>();
            collider2d = GetComponent<Collider2D>();
        }

        public void Interact()
        {
            inventoryUI.AddItem(itemScriptable);
            collider2d.enabled = false;
            particles.Stop();
            StartCoroutine(dialogueBox.ShowPickupText(itemScriptable));
        }
    }
}
