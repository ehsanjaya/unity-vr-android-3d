using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public ControlPlayerDesktop controlPlayerDesktop = new ControlPlayerDesktop();
    public Transform gloveRight;
    public Transform basketball;
    public Transform basketballPosition;
    public Transform head;
    public SphereCollider basketballCollision;
    public Animator animator;
    public Rigidbody rb;
    public string nameObject;
    public bool isPickedUp = false;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsDribble", false);
        basketballCollision.enabled = true;
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nameObject == "Basketball")
        {
            if (controlPlayerDesktop.isPushingBasketball == false)
            {
                animator.SetBool("IsDribble", true);
                basketball.parent = basketballPosition.transform;
                isPickedUp = true;
                controlPlayerDesktop.isHolding = true;
                basketballCollision.enabled = false;
                basketball.localPosition = new Vector3(0f, 0f, 0f);
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            else if (controlPlayerDesktop.isPushingBasketball == true)
            {
                nameObject = "";
                animator.SetBool("IsDribble", false);
                basketball.position = new Vector3(head.position.x, head.position.y, head.position.z + 2f);
                isPickedUp = false;
                controlPlayerDesktop.isHolding = false;
                basketballCollision.enabled = true;
                basketball.transform.parent = null;
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(camera.transform.forward * controlPlayerDesktop.ballThrowingForce * 2);
            }
        }

        if (Input.GetMouseButtonDown(0) && isPickedUp == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    nameObject = hit.transform.gameObject.name;
                }
            }
        }
    }


}
