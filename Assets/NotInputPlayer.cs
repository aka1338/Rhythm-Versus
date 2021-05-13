using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotInputPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AirSlicer>().isInputPlayer = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
