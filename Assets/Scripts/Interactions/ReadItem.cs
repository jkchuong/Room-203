using Inventory;
using UI;
using UnityEngine;

namespace Interactions
{
    public class ReadItem : MonoBehaviour, IInteractable
    {
        [TextArea(5, 12)]
        [SerializeField] private string dialogue;

        [SerializeField] private float duration = 5f;
        
        private DialogueBox dialogueBox;

        private void Awake()
        {
            dialogueBox = FindObjectOfType<DialogueBox>();
        }
        
        public void Interact()
        {
            StartCoroutine(dialogueBox.ShowDialogue(dialogue, duration));
        }
    }
}
