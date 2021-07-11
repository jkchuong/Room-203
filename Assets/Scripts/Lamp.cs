using System;
using System.Collections;
using System.Collections.Generic;
using Interactions;
using Inventory;
using Managers;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform newPosition;

    private Collider2D collider2d;

    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void Start()
    {
        collider2d.enabled = GameManager.Instance.QuestProgressions.Contains(QuestProgression.FoundLetter);
    }

    public void Interact()
    {
        transform.position = newPosition.position;
        GameManager.Instance.QuestProgressions.Add(QuestProgression.MovedLamp);
    }
}
