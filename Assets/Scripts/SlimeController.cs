using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public AudioClip[] slimeSFX;

    private Rigidbody2D rb;
    public GameObject l49;
    public GameObject slime;
    public GameObject aa;
    private AudioSource audioSource;

    public float speed;
    private float horizontalInput;
    public float jumpForce;
    public float doubleJumpForce;

    public bool isGrounded = true;
    public bool doubleJumpUsed = false;
    public bool flipped;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        //Jumping and Double Jumping
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

        //Switch to AA once 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(false);
            slime.SetActive(false);
            aa.SetActive(true);
        }
    }

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

    void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        flipped = !flipped;
    }

    void RandomSFX()
    {
        audioSource.clip = slimeSFX[Random.Range(0, slimeSFX.Length)];
        audioSource.Play();
    }

}
