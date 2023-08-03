using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 5f; // Adjust this value to control the movement speed
    [SerializeField] public float jumpStrength = 8f;
    private Rigidbody2D body;
    private Animator animator;
    private bool isWalking;
    public bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // Get the horizontal input
        float moveHorizontal = 0f;

        if (Input.GetKey("a"))
            moveHorizontal = -1f;
        else if (Input.GetKey("d"))
            moveHorizontal = 1f;

        // Calculate the movement direction
        Vector2 movement = new Vector2(moveHorizontal, 0f);

        // Flip character
        if (moveHorizontal < 0f)
            transform.localScale = new Vector3(-1, 1, 1);
         
        if (moveHorizontal > 0f)
            transform.localScale = new Vector3(1, 1, 1);

        // Move the character
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Jump
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }


        // Animator condition
        if (moveHorizontal == 0)
            isWalking = false;
        else
            isWalking = true;

        animator.SetBool("walk", isWalking);
        animator.SetBool("grounded", grounded);

    }

    private void Jump()
    {
        body.velocity = new Vector2(transform.localScale.x, moveSpeed * jumpStrength);
        grounded = false;
        animator.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }






}

