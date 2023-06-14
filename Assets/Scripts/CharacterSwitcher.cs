using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject l49;
    public GameObject bara;
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            l49.SetActive(false);
            bara.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            bara.SetActive(false);
            l49.SetActive(true);
        }

    }
}
