using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutVeggie : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {

        StartCoroutine("DeleteNote");

    }

    IEnumerator DeleteNote()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this);
    }
}
