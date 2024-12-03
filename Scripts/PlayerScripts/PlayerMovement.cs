using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 10f;
    [SerializeField] private float runSpeed = 20f;
    [SerializeField] private float blockSpeed = 5f;
    [SerializeField] private float idleAnimationSpeed = 1f;
    [SerializeField] private float acceleratedIdleAnimationSpeed = 2f;

    private float moveSpeed;
    private Rigidbody2D rigidBodyPlayer;
    private bool isTouchingBlock = false;
    private Animator playerAnimator;

    private void Start()
    {
        QualitySettings.vSyncCount = 1;

        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        moveSpeed = normalSpeed;
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // ���������� ������� �������� ��������
        if (isTouchingBlock)
        {
            moveSpeed = blockSpeed; // ����������, ���� ����� �������� �����
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed; // ��������� ��� ����������� Shift
            playerAnimator.speed = acceleratedIdleAnimationSpeed;
        }
        else
        {
            moveSpeed = normalSpeed; // ������� ��������
            playerAnimator.speed = idleAnimationSpeed;
        }

        // ��������� �������� � Rigidbody2D
        Vector2 move = new Vector2(moveX, moveY).normalized * moveSpeed;
        rigidBodyPlayer.linearVelocity = move;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ���� �������, � ������� ���������� ������������
        if (other.CompareTag("Wall") || other.CompareTag("Bush"))
        {
            isTouchingBlock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ��������� ���� �������, � ������� ������������� ������������
        if (other.CompareTag("Wall") || other.CompareTag("Bush"))
        {
            isTouchingBlock = false;
        }
    }
}
