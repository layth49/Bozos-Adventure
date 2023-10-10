using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatLogic : MonoBehaviour
{

    public float speed = 10;


    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        StartCoroutine(Timer());
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
