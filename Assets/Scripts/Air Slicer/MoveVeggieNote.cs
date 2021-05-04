using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVeggieNote : MonoBehaviour
{
    public Transform cubeTransform;
    public Material cubeMaterial;
    //public GameObject note;
    //public GameObject cutVeggie;
    public Vector3[] wayPoints; 

    void Start()
    {
        // static DOTween.Init(bool recycleAllByDefault = false, bool useSafeMode = true, LogBehaviour = LogBehaviour.ErrorsOnly)
        // initializes DOTween
        DOTween.Init(false, true, LogBehaviour.Default);

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

        // GameManager.ValidHit += SuccessfulHit;
        // GameManager.MissedHit += UnSuccessfulHit;
        cubeMaterial.DOColor(Color.white, 1);
        cubeTransform.DOLocalPath(wayPoints, AirSlicer.animationDuration, PathType.CatmullRom);
    }

    void Update()
    {
        //if (cubeTransform.position.y > 0.95 && note != null)
        //{
          //  StartCoroutine("DeleteNote");
        //}
    }

    //private void OnDisable()
    //{
        //GameManager.ValidHit -= SuccessfulHit;
        //GameManager.MissedHit -= UnSuccessfulHit;
    //}
    /*
    private void SuccessfulHit()
    {
        if (note != null)
        {
            
            cubeMaterial.DOColor(Color.green, 1);
            GameObject currentVeggieNote = GameObject.Find("VeggieNote(Clone)");
            Destroy(Instantiate(cutVeggie, new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity), 1f);
            
            DOTween.Kill(currentVeggieNote); 
            Destroy(currentVeggieNote);
            Debug.Log("This should have removed the oldest clone");

            //Debug.Log("Making a function call to DestroyVeggieNote()");
            //AirSlicer.DestroyVeggieNote();
            //Destroy(Instantiate(this.cutVeggie, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity), 2f);
            //Instantiate(cutVeggie, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);     
        }
    }

    private void UnSuccessfulHit()
    {
        if (note != null)
        {
            cubeMaterial.DOColor(Color.red, 1);
            GameObject currentVeggieNote = GameObject.Find("VeggieNote(Clone)");
            //Instantiate(cutVeggie, new Vector3(currentVeggieNote.transform.position.x, currentVeggieNote.transform.position.y, 0f), Quaternion.identity);
            Destroy(currentVeggieNote);
        }
    }
    */

    // Waits a bit to ensure cube has reached it's final destination before being deleted, otherwise generates DOTween warnings. 
    //IEnumerator DeleteNote()
   // {
     //   yield return new WaitForSeconds(0.1f);
     //   Destroy(note);
   // }
}
