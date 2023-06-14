using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaraController : MonoBehaviour
{
    public AudioClip[] slimeSFX;

    public Rigidbody2D rb;
    public GameObject l49;
    public GameObject bara;
    AudioSource audioSource;
    public float speed;
    private float horizontalInput;
    public float jumpForce;
    public float doubleJumpForce;

    public bool isGrounded = true;
    public bool doubleJumpUsed = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            RandomSFX();
            doubleJumpUsed = false;
        }
        else if (!isGrounded && !doubleJumpUsed && Input.GetKeyDown(KeyCode.Space))
        {
            doubleJumpUsed = true;
            RandomSFX();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        //Switch to 49 once 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(true);
            bara.SetActive(false);
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

    void RandomSFX()
    {
        audioSource.clip = slimeSFX[Random.Range(0, slimeSFX.Length)];
        audioSource.Play();
    }

}
