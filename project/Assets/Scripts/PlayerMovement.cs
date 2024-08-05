using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    public float movementSpeed = 5f;
    float horizontalMovement;
    bool facingRight = true;

    [Header("Jumping")]
    public float jumpPower = 10f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled) return; // Prevent any movement if the script is disabled

        rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);

        if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalMovement == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!enabled) return; // Prevent movement input if the script is disabled

        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!enabled) return; // Prevent jump input if the script is disabled

        if (context.performed)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetTrigger("jumpKey");
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
}