using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class l49Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject l49;
    public GameObject slime;
    public GameObject aa;

    private AudioSource audioSource;
    public AudioClip teleportAudio;

    public ParticleSystem bTeleport;
    public ParticleSystem pTeleport;
    public GameObject tP;

    public float speed;
    public float jumpForce;
    private float horizontalInput;

    public bool isGrounded;
    private bool flipped;
    public bool coolDownOver = true;
    public float coolDownSeconds;

    private Vector2 mousePosition;

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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tP.transform.position = mousePosition;

        if (coolDownOver && Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameObject.transform.position = mousePosition;
            isGrounded = false;
            audioSource.PlayOneShot(teleportAudio, 1);
            bTeleport.Play();
            pTeleport.Play();
            StartCoroutine(CoolDown());
        }

        //Jummping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //Switch to Slime once 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(false);
            slime.SetActive(true);
            aa.SetActive(false);
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

    IEnumerator CoolDown()
    {
        coolDownOver = false;
        yield return new WaitForSeconds(coolDownSeconds);
        coolDownOver = true;
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
