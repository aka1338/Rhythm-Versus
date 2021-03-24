using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class SimpleCubeAnimation : MonoBehaviour
{

    public Transform cubeTransform;
    public Material cubeMaterial;

    private BeatSystem bS;
    private FMOD.Studio.EventInstance instance;


    private float animDuration = BeatSystem.secPerBeat;
    public Ease animEase;

    private bool hasSwitched = false;
    private bool hasSwitchedAlt = false;

    private void Start()
    {
        bS = GetComponent<BeatSystem>();
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/animationtest");
        bS.AssignBeatEvent(instance);
        instance.start();

        Debug.Log(BeatSystem.secPerBeat);

        cubeMaterial.DOColor(Color.white, 1);

        BeatSystem.onBeat += ChangeMaterial;
        BeatSystem.onOffBeat += BumpCube; 
    }

    private void OnDisable()
    {
        BeatSystem.onBeat -= ChangeMaterial;
        BeatSystem.onOffBeat -= BumpCube; 
    }

    void BumpCube()
    {
        Debug.Log("BumpCube()");
        if (hasSwitched)
        {
            cubeTransform
           .DOMoveX(6, .5f)
           .SetEase(animEase);
            hasSwitched = false;
        }
        else
        {
            cubeTransform
           .DOMoveX(-6, .5f)
           .SetEase(animEase);
            hasSwitched = true;

        }
    }

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
