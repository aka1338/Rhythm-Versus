using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVeggieNote : MonoBehaviour
{
    public Transform cubeTransform;
    public Material cubeMaterial;
    public GameObject note;

    public Vector3[] wayPoints;

    void Start()
    {
        // static DOTween.Init(bool recycleAllByDefault = false, bool useSafeMode = true, LogBehaviour = LogBehaviour.ErrorsOnly)
        // initializes DOTween
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        //wayPoints = new Vector3[9];
        // set the positions for each index for path that veggieObject will travel
        /* wayPoints.SetValue((-5.32f, -6.03f, 0f), 0);
        wayPoints.SetValue((-4.9f, -5.03f, 0f), 1);
        wayPoints.SetValue((-3.5f, -1.99f, 0f), 2);
        wayPoints.SetValue((-2f, 0.01f, 0f), 3);
        wayPoints.SetValue((0f, 0.97f, 0f), 4);
        wayPoints.SetValue((2f, 0.01f, 0f), 5);
        wayPoints.SetValue((3.5f, -1.99f, 0f), 6);
        wayPoints.SetValue((4.9f, -5.03f, 0f), 7);
        wayPoints.SetValue((5.32f, -6.03f, 0f), 8); */

        GameManager.ValidHit += SuccessfulHit;
        GameManager.MissedHit += UnSuccessfulHit;
        cubeMaterial.DOColor(Color.white, 1);
        cubeTransform.DOPath(wayPoints, AirSlicer.animationDuration, PathType.CatmullRom);
    }

    void Update()
    {
        if (cubeTransform.position.x == 5.32 && note != null)
        {
            StartCoroutine("DeleteNote");
        }
    }

    private void OnDisable()
    {
        GameManager.ValidHit -= SuccessfulHit;
        GameManager.MissedHit -= UnSuccessfulHit;
    }

    private void SuccessfulHit()
    {
        if (note != null)
            cubeMaterial.DOColor(Color.green, 1);
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
        Destroy(note);
    }
}
