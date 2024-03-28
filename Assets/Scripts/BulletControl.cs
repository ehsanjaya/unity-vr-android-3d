using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, 0.05f);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
