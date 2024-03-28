using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingControl : MonoBehaviour
{
    [SerializeField] int length;
    int index = 0;
    public Vector3[] position;
    public Rigidbody rb;
    public float speedMove;
    public Quaternion[] rotation;
    public float speedRotation;
    float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;

        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation[index], Time.deltaTime * speedRotation);

        if (transform.rotation == rotation[index])
        {
            transform.position = Vector3.MoveTowards(transform.position, position[index], speedMove);
            rb.useGravity = true;
        }

        if (transform.position == position[index])
            index++;
    }
}
