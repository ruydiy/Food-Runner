using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5.0f;
    public float sprintSpeedMultiplier = 2.0f;
    public float mouseSensitivity = 100.0f;
    public float jumpForce = 5.0f;
    public Transform playerCamera;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private CharacterController characterController;
    private float xRotation = 0f;
    private Vector3 velocity;
    private bool isGrounded;
    private float groundCheckDistance = 0.1f;
    private float gravity = -60f;

    //Respawn 
    public float threshold;
    private int br = 0;

    public Image heartImage;
    public Sprite fullBurger;
    public Sprite halfBurger;
    public Sprite bitenBurger;
    public Sprite noBurger;

   
    private void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            //fixed Respawn position
            transform.position = new Vector3(0.1f, 0.1f, 0.1f);
            br++;
            Debug.Log(br);
            switch (br)
            {
                case 0: heartImage.sprite = fullBurger; break;
                case 1: heartImage.sprite = halfBurger; break;
                case 2: heartImage.sprite = bitenBurger; break;
                case 3: heartImage.sprite = noBurger; break;
                case 4:
                    {
                        SceneManager.LoadScene("MainMenu");
                        Cursor.lockState = CursorLockMode.None;
                    }
                    break;
                default:
                    break;
            }
            /*
            if(br == 1)
            {
                heartImage.sprite = heartSprite;
            }
            */
            //Destroy(heartImage.gameObject);
        }
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // Camera rotation
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

            // Character movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            // Sprinting
            if (Input.GetKey(KeyCode.LeftShift))
            {
                move *= sprintSpeedMultiplier;
            }

            characterController.Move(move * speed * Time.deltaTime);

            // Jumping
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, LayerMask.GetMask("Ground"));

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }

            // Apply gravity
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}