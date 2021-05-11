using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVeggieNote : MonoBehaviour
{
    public Transform noteTransform;
    //public GameObject note;
    //public GameObject cutVeggie;
    public Vector3[] wayPoints;
    void Start()
    {
        // static DOTween.Init(bool recycleAllByDefault = false, bool useSafeMode = true, LogBehaviour = LogBehaviour.ErrorsOnly)
        // initializes DOTween
        DOTween.Init(false, true, LogBehaviour.Default);

        //wayPoints = new Vector3[9];
        //wayPoints.SetValue((-5.32f, -6.03f, 0f), 0);
        //wayPoints.SetValue((-4.9f, -5.03f, 0f), 1);
        //wayPoints.SetValue((-3.5f, -1.99f, 0f), 2);
        //wayPoints.SetValue((-2f, 0.01f, 0f), 3);
        // GameManager.ValidHit += SuccessfulHit;
        // GameManager.MissedHit += UnSuccessfulHit;
        noteTransform.DOLocalPath(wayPoints, AirSlicer.animationDuration, PathType.CatmullRom);
    }

    void Update()
    {

    }

}
