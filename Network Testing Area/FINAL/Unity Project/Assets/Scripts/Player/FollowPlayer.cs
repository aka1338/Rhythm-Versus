using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public Vector3 topDown;
    public float y;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        if (Input.GetKey("z"))
        {
            transform.position = player.position + topDown;
            transform.rotation = Quaternion.Euler(y,0,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
