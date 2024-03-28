using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerationControl : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public CharacterController characterController;
    public Camera camera;
    public bool isMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.acceleration.x * speed * Time.deltaTime, 0f, -Input.acceleration.z * speed * Time.deltaTime);
        Vector3 rotationMovement = camera.transform.TransformDirection(move);

        camera.fieldOfView = Input.acceleration.y + 100f;

        if (isMoving == true)
        {
            rb.useGravity = true;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints.None;
            characterController.enabled = true;
            characterController.Move(rotationMovement);
        }
        else
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            characterController.enabled = false;
        }
    }        

    public void IsMoving(Toggle toggle)
    {
        isMoving = toggle.isOn;
    }
}
