using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class SimpleCubeAnimation : MonoBehaviour
{

    public Transform cubeTransform;
    private BeatSystem bS;
    private FMOD.Studio.EventInstance instance;


    private float animDuration = BeatSystem.secPerBeat;
    public Ease animEase;
    private bool hasSwitched = false;

    private void Start()
    {
        bS = GetComponent<BeatSystem>();
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/animationtest");
        bS.AssignBeatEvent(instance);
        Debug.Log("Should assign cube here."); 
        BeatSystem.onBeat += BumpCube;
        instance.start();
    }

    private void OnDisable()
    {
        BeatSystem.onBeat += BumpCube; 
    }

    void BumpCube()
    {
        Debug.Log("Callback Triggered!"); 
        if (hasSwitched)
        {
            cubeTransform
           .DOMoveX(3f, animDuration)
           .SetEase(animEase);
        }
        else
        {
            hasSwitched = true; 
            cubeTransform
           .DOMoveX(-3f, animDuration)
           .SetEase(animEase);
        }
    }
}
