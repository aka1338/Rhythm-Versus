using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveNote : MonoBehaviour
{
    public Transform cubeTransform;
    public Material cubeMaterial;
    public GameObject note;

    // Each minigame needs to have a referene to the player playing the game. 

    private void Start()
    {
        cubeMaterial.DOColor(Color.white, 1);
        cubeTransform.DOMoveX(transform.localPosition.x+18, MinigameSample.animationDuration);
        BeatSystem.OnMarker += CheckHit;
    }

    private void OnDisable()
    {
        BeatSystem.OnMarker -= CheckHit;

    }

    private void UnSuccessfulHit()
    {
        if (note != null)
        cubeMaterial.DOColor(Color.red, 1);
    }

    // Waits a bit to ensure cube has reached it's final destination before being deleted, otherwise generates DOTween warnings. 
    IEnumerator DeleteNote()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (cubeTransform.localPosition.x >= 9 && note != null) 
        {
            StartCoroutine("DeleteNote"); 
        }
    }

    private void SuccessfulHit()
    {
        if (note != null)
        cubeMaterial.DOColor(Color.green, 1);
    }

    private void CheckHit()
    {
        if (InputController.CheckForValidHit(KeyCode.F))
        {
            SuccessfulHit();
        }
        else
        {
            UnSuccessfulHit(); 
        }

    }
}
