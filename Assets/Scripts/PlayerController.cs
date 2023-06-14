using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject l49;
    public GameObject bara;
    public float speed;
    private float horizontalInput;
    public float jumpForce;
    public bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        //Switch to Slime once 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(false);
            bara.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
