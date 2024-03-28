using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointControl : MonoBehaviour
{
    public NavMeshAgentControl navMeshAgentControl;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        navMeshAgentControl.walkPointSet = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floors")
            navMeshAgentControl.walkPointSet = false;
        if (other.tag == "Enemy Character")
            navMeshAgentControl.walkPointSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
