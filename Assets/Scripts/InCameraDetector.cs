using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    public NavMeshAgentControl navMeshAgentControl;
    public GunControl gunControl;
    public GameObject target;
    public Camera camera;

    public bool playerShighted = false;

    Plane[] cameraFrustum;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = target.GetComponent<Collider>();
        navMeshAgentControl.isFollowingTarget = false;
        gunControl.isShootingTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            playerShighted = true;
            CheckForPlayer();
        }
        else
        {
            playerShighted = false;
            navMeshAgentControl.isFollowingTarget = false;
            if (gunControl.isFollowingTarget == false) gunControl.isShootingTarget = false;
        }
    }

    void CheckForPlayer()
    {
        RaycastHit hit;
        Debug.DrawRay(camera.transform.position, transform.forward * 10f, Color.green);
        if (Physics.Raycast(camera.transform.position, transform.forward, out hit, 10))
        {
            navMeshAgentControl.isFollowingTarget = true;
            if (gunControl.isFollowingTarget == true) gunControl.isShootingTarget = true;
        }
    }
}
