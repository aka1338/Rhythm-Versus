using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("q"))
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x + 1.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (Input.GetKey("e"))
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x - 1.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
