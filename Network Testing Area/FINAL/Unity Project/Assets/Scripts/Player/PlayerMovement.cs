using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tf;

    public float forwardForce = 2000f;
    public float sideWayForce = 500f;

    public float jumpForce = 100f;
    
    public SphereCollider bc;

    // Start is called before the first frame update
    /*void Start()
    {
        rb.AddForce(0, 200, 500);
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        //add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //add 2000s force on z axis

        if (Input.GetKey("d"))
        {
            rb.AddForce(sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideWayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        }

        if(rb.position.y < -1f || rb.position.y > 100f)
        {
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

}
