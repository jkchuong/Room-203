using System;
using Interactions;
using Inventory;
using Managers;
using UI;
using UnityEngine;

public class RecordPlayer : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite spriteBefore;
    [SerializeField] private Sprite spriteAfter;

    [SerializeField] private GameObject itemToShow;
    [SerializeField] private string message;
    
    private SpriteRenderer spriteRenderer;
    private DialogueBox dialogueBox;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        dialogueBox = FindObjectOfType<DialogueBox>();
        spriteRenderer.sprite = spriteBefore;
    }

    public void Interact()
    {
        if (!GameManager.Instance.QuestProgressions.Contains(QuestProgression.PlayedRecord) && GameManager.Instance.QuestProgressions.Contains(QuestProgression.FoundRecord))
        {
            StartCoroutine(AudioManager.Instance.PlayAudio());
            GameManager.Instance.QuestProgressions.Add(QuestProgression.PlayedRecord);

            spriteRenderer.sprite = spriteAfter;
            
            if (itemToShow)
            {
                itemToShow.SetActive(true);
            }

            StartCoroutine(dialogueBox.ShowDialogue(message, 3f));
        }
    }
}
