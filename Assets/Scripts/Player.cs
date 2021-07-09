﻿using UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constants
    [SerializeField] private float moveSpeed = 5f;
    
    // Components
    private Rigidbody2D rigidbody2d;
    
    // Cache    
    private float horizontal;
    private float vertical;
    private bool isPaused;

    private IInteractable interactableObject;

    private Vector2 lookDirection = new Vector2(1, 0);

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();


        // animator = GetComponent<Animator>();
        // audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        Move();

        Interact();

        OpenInventory();
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.Instance.SetUI();
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableObject != null)
        {
            interactableObject.Interact();
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        // animator.SetFloat("Look X", lookDirection.x);
        // animator.SetFloat("Look Y", lookDirection.y);
        // animator.SetFloat("Speed", move.magnitude);
    }
    
    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x += moveSpeed * horizontal * Time.deltaTime;
        position.y += moveSpeed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactableObject = other.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            interactableObject = null;
        }
    }

}
