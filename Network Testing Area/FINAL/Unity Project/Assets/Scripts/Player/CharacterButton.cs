using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public GameObject character;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r")) {
            character.GetComponent<Animator>().Play("Mma Kick");
        }
    }
}
