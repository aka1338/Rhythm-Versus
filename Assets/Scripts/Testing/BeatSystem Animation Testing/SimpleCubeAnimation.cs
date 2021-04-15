using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class SimpleCubeAnimation : MonoBehaviour
{

    public Transform cubeTransform;
    public Material cubeMaterial;

    private float animDuration = 0;
    public Ease animEase;

    private bool hasSwitched = false;
    private bool hasSwitchedAlt = false;

    private void Start()
    {
        cubeMaterial.DOColor(Color.white, 1);

        BeatSystem.OnBeat += ChangeMaterial;
        BeatSystem.OnOtherBeat += BumpCube; 
    }

    private void OnDisable()
    {
        BeatSystem.OnBeat -= ChangeMaterial;
        BeatSystem.OnOtherBeat -= BumpCube; 
    }

    // Bumps the cube either left or right. 
    void BumpCube()
    {
        animDuration = BeatSystem.secPerBeat; 

        if (hasSwitched)
        {
            cubeTransform
           .DOMoveX(6, animDuration)
           .SetEase(animEase);
            hasSwitched = false;
        }
        else
        {
            cubeTransform
           .DOMoveX(-6, animDuration)
           .SetEase(animEase);
            hasSwitched = true;

        }
    }

    // Changes the cube's material to either red or green. 
    void ChangeMaterial()
    {
        if (hasSwitchedAlt)
        {
            hasSwitchedAlt = false;
            cubeMaterial.DOColor(Color.green, .2f);
        }
        else
        {
            hasSwitchedAlt = true;
            cubeMaterial.DOColor(Color.red, .2f);
        }
    }

}
