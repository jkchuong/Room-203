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
        
        private DialogueBox dialogueBox;
        
        private void Start()
        {

            dialogueBox = FindObjectOfType<DialogueBox>();
            
            if (interactImmediate)
            {
                Interact();
            }
            
            if (!itemToShow) return;
            itemToShow.SetActive(false);
        }

        public void Interact()
        {
            if (GameManager.Instance.QuestProgressions.Contains(questAfter))
            {
                if (destroyAfterUse)
                {
                    Destroy(gameObject);
                }
                
                StartCoroutine(dialogueBox.ShowDialogue(dialogueAfter, duration));
            }
            else if (GameManager.Instance.QuestProgressions.Contains(questBefore))
            {
                StartCoroutine(dialogueBox.ShowDialogue(dialogueBefore, duration));
                GameManager.Instance.QuestProgressions.Add(questAfter);
                
                if (!itemToShow) return;
                itemToShow.SetActive(true);
            }
        }
    }
}
