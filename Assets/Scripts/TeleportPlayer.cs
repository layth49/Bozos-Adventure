using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject tP;
    AudioSource audioSource;
    public ParticleSystem bTeleport;
    public ParticleSystem pTeleport;
    public AudioClip teleportAudio;
    PlayerController controller;
    public bool coolDownOver = true;
    public float coolDownSeconds;

    Vector2 mousePosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        tP.transform.position = mousePosition;

        //teleportLocation = tP.transform.position;


        if (coolDownOver && Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameObject.transform.position = mousePosition;
            controller.isGrounded = false;
            audioSource.PlayOneShot(teleportAudio, 1);
            bTeleport.Play();
            pTeleport.Play();
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        coolDownOver = false;
        yield return new WaitForSeconds(coolDownSeconds);
        coolDownOver = true;
    }
}
