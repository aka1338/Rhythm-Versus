using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCalibrationOffset : MonoBehaviour
{
    public InputField iField;

    public void SetOffset() 
    {
        string offsetValue = iField.text;
        GameManager.SetOffset(float.Parse(offsetValue)); 
    }
}
