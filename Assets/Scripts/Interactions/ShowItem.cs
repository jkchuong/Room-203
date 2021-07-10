using System;
using Inventory;
using Managers;
using UI;
using UnityEngine;

namespace Interactions
{
    public class ShowItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private QuestProgression quest;
        
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
            
            if (!itemToShow) return;
            itemToShow.SetActive(false);
        }

        public void Interact()
        {
            if (GameManager.Instance.QuestProgressions.Contains(quest))
            {
                StartCoroutine(dialogueBox.ShowDialogue(dialogueAfter, duration));
            }
            else
            {
                GameManager.Instance.QuestProgressions.Add(quest);
                StartCoroutine(dialogueBox.ShowDialogue(dialogueBefore, duration));

                if (!itemToShow) return;
                itemToShow.SetActive(true);
            }

        }
    }
}
