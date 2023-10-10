using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject l49;
    public GameObject bara;

    public float speed;
    public float jumpForce;
    private float horizontalInput;

    public bool isGrounded;
    private bool flipped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Moving Horizontally
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        if (horizontalInput < 0 && !flipped)
        {
            Flip();
        }
        else if (horizontalInput > 0 && flipped)
        {
            Flip();
        }
    }

    private void Update()
    {
        //Jummping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //Switch to Slime once 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(false);
            bara.SetActive(true);
        }
    }

    //Flipping the Sprite
    void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        flipped = !flipped;
    }
    
    //Ground Checking
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
