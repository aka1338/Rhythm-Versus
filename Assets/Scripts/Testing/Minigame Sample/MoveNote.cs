using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveNote : MonoBehaviour
{
    public Transform cubeTransform;
    public Material cubeMaterial;
    public GameObject note;
    private void OnDisable()
    {
        GameManager.ValidHit -= SuccessfulHit;
        GameManager.MissedHit -= UnSuccessfulHit;
    }

    private void Start()
    {
        GameManager.ValidHit += SuccessfulHit;
        GameManager.MissedHit += UnSuccessfulHit;
        cubeMaterial.DOColor(Color.white, 1);
        cubeTransform.DOMoveX(9, MinigameSample.animationDuration); 
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
        if (cubeTransform.position.x == 9 && note != null) 
        {
            StartCoroutine("DeleteNote"); 
        }
    }

    private void SuccessfulHit()
    {
        if (note != null)
        cubeMaterial.DOColor(Color.green, 1);
    }
}
