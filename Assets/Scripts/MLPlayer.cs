using UnityEngine;
using Unity.MLAgents;
using UnityEngine.InputSystem;

public class MLPlayer : Agent
{
    [Header("Movement")]
    public float jumpForce;
    public float jumpCooldown;
    private bool readyToJump;

    [Header("Input Actions")]
    public InputActionAsset inputActions;
    private InputAction jumpAction;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    private bool grounded;

    [Header("Obstacle")]
    public string obstacleTag;

    private Rigidbody rb = null;

    private void OnDestroy()
    {
        // Clean up jump action subscription
        jumpAction.performed -= OnJump;
    }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        jumpAction = InputSystem.actions.FindAction("Jump");
        // Set up jump action callback
        jumpAction.performed += OnJump;
        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
