using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 7;

    public TextMeshProUGUI nameText;
    PlayerInput playerInput;
    InputAction moveAction;
    private ColorController colorManager;

    public AudioSource correctAudioSource; 
    public AudioSource incorrectAudioSource; 

    private Spawner spawner;
    void Start()
    {
        //assign rigidity and player action components
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

        //set the player name text to the value from input field in main menu
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        nameText.text = playerName;

        //create instances from color manager and spawner
        colorManager = FindObjectOfType<ColorController>();
        spawner = FindObjectOfType<Spawner>();

    }
    private void Update()
    {
        MovePlayer();
    }
    //player input movement
    void MovePlayer()
    {
        moveAction.ReadValue<Vector2>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            //compare prefab color with the winning color assigned
            if (renderer.sharedMaterial == colorManager.CurrentWinningMaterial)
            {
                //on collision with correct color, gain one point and play correct sound
                ScoreController.Instance.AddScore(1);
                correctAudioSource.Play();
            }
            else
            {
                //on collision with incorrect color, lose one point and play incorrect sound
                ScoreController.Instance.AddScore(-1);
                incorrectAudioSource.Play();
            }
            Destroy(other.gameObject);
            // spawn new prefab when one is destroyed
            spawner.SpawnPickups();
        }
    }
}