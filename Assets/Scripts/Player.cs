using Interactions;
using UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constants
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private AudioClip[] footstepsClips;
    
    // Components
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private AudioSource audioSource;
    
    // Cache    
    private float horizontal;
    private float vertical;
    public bool isPaused;

    private IInteractable interactableObject;

    private Vector2 lookDirection = new Vector2(1, 0);

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();


        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        Interact();
        OpenInventory();

        if (isPaused) return;
        Move();
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryUI.Instance.SetUI();
            isPaused = !isPaused;
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
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }
    
    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x += moveSpeed * horizontal * Time.deltaTime;
        position.y += moveSpeed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    private void OnTriggerStay2D(Collider2D other)
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

    public void PlayFootsteps()
    {
        AudioClip footstep = footstepsClips[Random.Range(0, footstepsClips.Length - 1)];
        audioSource.PlayOneShot(footstep);
    }

}
