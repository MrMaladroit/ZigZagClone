using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    private Rigidbody rb;
    private bool isWalkingRight = true;
    private bool isGameRunning = false;
    private Animator animationController;
    private Transform rayCastOrigin;
    private float playerSpeed = 2f;
    private int speedIncreaseInvokeRate = 10;
    private static bool isFalling;
    
    public static bool IsFalling { get { return isFalling; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
        rayCastOrigin = GetComponent<Transform>();
        isFalling = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurnCharacter();
        }

        if (transform.position.y < 0.45f)
        {
            isFalling = true;
            animationController.SetBool("isFalling", isFalling);
            Invoke("GameOver", 2);
        }                
    }

    private void StartGame()
    {
        isGameRunning = true;
        animationController.SetBool("isGameRunning", isGameRunning);
        InvokeRepeating("IncreaseSpeed", speedIncreaseInvokeRate, speedIncreaseInvokeRate);
    }

    private void FixedUpdate()
    {
        if(isGameRunning)
        {
            MoveCharacterForward(); 
        }
    }

    private void IncreaseSpeed()
    {
        if(isGameRunning)
        {
            playerSpeed += 0.25f;
        }
    }

    private void MoveCharacterForward()
    {
        rb.transform.position = transform.position + transform.forward * playerSpeed * Time.deltaTime;
    }

    private void TurnCharacter()
    {
        isWalkingRight = !isWalkingRight;

        if (isWalkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);

    }

    private void GameOver()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        GameManager.instance.GameOver();
    }
}