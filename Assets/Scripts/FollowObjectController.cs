using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectController : MonoBehaviour
{
    public GameObject gameObject;
    public float speedTurn;
    public float speedMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, gameObject.transform.rotation, speedTurn);
        transform.position = Vector3.Slerp(transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), speedMove);
    }
}
