using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Xml.Linq;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator playerAnimator;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2 >();
        Debug.Log(moveInput);


    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x , moveInput.y );
        myRigidbody.velocity = playerVelocity;

        //bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        //bool playerHasHorizontalSpeed2 = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        playerAnimator.SetBool("IsRunningX", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
