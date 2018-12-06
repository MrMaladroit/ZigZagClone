using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isWalkingRight = true;
    private bool isGameRunning = false;
    private Animator animationController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isGameRunning = true;
            animationController.SetBool("isGameRunning", isGameRunning);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TurnCharacter();
        }
    }


    private void FixedUpdate()
    {
        if(isGameRunning)
        {
            MoveCharacterForward();
        }
    }

    private void MoveCharacterForward()
    {
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void TurnCharacter()
    {
        isWalkingRight = !isWalkingRight;

        if (isWalkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);

    }
}