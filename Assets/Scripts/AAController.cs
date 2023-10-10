using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AAController : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject l49;
    public GameObject slime;
    public GameObject aa;
    public GameObject hat;

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

        //Switch to 49 once 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(true);
            slime.SetActive(false);
            aa.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowHat();
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

    public void ThrowHat()
    {
        var offset = new Vector3(0, 0.5f, 0);
        Instantiate(hat, transform.position + offset, hat.transform.rotation);
    }


}
