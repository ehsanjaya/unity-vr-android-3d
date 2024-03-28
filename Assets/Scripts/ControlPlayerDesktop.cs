using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayerDesktop : MonoBehaviour
{
    public float jumpForce;
    public Transform controller;
    public Rigidbody rb;
    public Transform head;
    public Transform body;
    public float speedRotation;
    public float speedMove;
    public Vector2 turn;
    public ParticleSystem particleSystem;
    public AudioSource audio;
    public string movementAxis = "All Axis";
    public string rotationAxis = "All Axis";
    public Animator animator;
    public bool isJumping = false;
    public bool isClicking = true;
    public bool isHolding = false;
    public bool isPushingBasketball = false;
    public Text speedForceText;
    public Camera camera;
    public float ballThrowingForce = 0f;
    public bool isForce = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            float xMouse = turn.x += Input.GetAxis("Mouse X") * speedRotation;
            float yMouse = turn.y += Input.GetAxis("Mouse Y") * speedRotation;
            float x = Input.GetAxis("Horizontal") * speedMove;
            float z = Input.GetAxis("Vertical") * speedMove;

            if (movementAxis == "All Axis") transform.Translate(x, 0, z);
            else if (movementAxis == "X Axis") transform.Translate(x, 0, 0);
            else if (movementAxis == "Y Axis") transform.Translate(0, 0, z);

            if (rotationAxis == "All Axis")
            {
                head.localRotation = Quaternion.Euler(-yMouse, 0, 0);
                controller.localRotation = Quaternion.Euler(0, xMouse, 0);
            }
            else if (rotationAxis == "X Axis") controller.localRotation = Quaternion.Euler(-turn.y, 0, 0);
            else if (rotationAxis == "Y Axis") controller.localRotation = Quaternion.Euler(0, turn.x, 0);

            if (Input.anyKey)
            {
                if (isClicking == true && Input.GetMouseButtonDown(0))
                {
                    if (x != 0 || z != 0)
                        StartCoroutine(ClickWithWalk());
                    else
                        StartCoroutine(Click());
                }

                if (isJumping == true && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    animator.SetFloat("Speed", 0);
                    animator.SetBool("IsJumping", true);
                    animator.SetBool("IsClicking", false);
                    animator.SetBool("IsClickingWithWalk", false);
                }
                else
                {
                    if (x != 0 || z != 0)
                    {
                        rb.constraints = RigidbodyConstraints.None;
                        animator.SetFloat("Speed", 1);
                        animator.SetBool("IsJumping", false);
                        animator.SetBool("IsClicking", false);
                        animator.SetBool("IsClickingWithWalk", false);
                    }
                }
                particleSystem.Play();
                audio.pitch = 1f;
            }
            else
            {
                animator.SetFloat("Speed", 0);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsClicking", false);
                animator.SetBool("IsClickingWithWalk", false);
                particleSystem.Stop();
                audio.pitch = 0f;
            }

            if (isForce == false) speedForceText.enabled = false;
            StartCoroutine(PickOrThrowBasketball());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
    public void MouseSensivity(float speed)
    {
        //Change the speed rotation
        speedRotation = speed;
    }
    public void SpeedMove(float speed)
    {
        //Change the speed move
        speedMove = speed;
    }
    public void ResetRotation()
    {
        //Reset the rotation
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    IEnumerator PickOrThrowBasketball()
    {
        if (Input.GetButton("Fire1") && isHolding == true && isForce == false)
        {
            if (isForce == false)
            {
                animator.SetBool("IsThrowing", false);
                animator.SetBool("IsClicking", false);
                animator.SetBool("IsClickingWithWalk", false);
                camera.fieldOfView = 60;
                speedForceText.enabled = false;
                if (ballThrowingForce > 2) isForce = true;
                else ballThrowingForce += 0.1f;
            }
        }
        else if (ballThrowingForce < 1 && isForce == false && isHolding == true)
        {
            isForce = false;
            isPushingBasketball = false;
            ballThrowingForce = 0f;
            camera.fieldOfView = 60;
            animator.SetBool("IsThrowing", false);
        }

        if (isForce == true)
        {
            isPushingBasketball = false;

            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("IsThrowing", false);
                animator.SetBool("IsClicking", false);
                animator.SetBool("IsClickingWithWalk", false);
                speedForceText.enabled = true;
                speedForceText.text = "Speed Force: " + ballThrowingForce;
                isForce = true;
                if (ballThrowingForce < 500)
                {
                    ballThrowingForce += 5f;
                    camera.fieldOfView += 0.3f;
                }
            }
            else
            {
                isForce = false;
                speedForceText.enabled = false;
                animator.SetFloat("Speed", 0);
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsClicking", false);
                animator.SetBool("IsClickingWithWalk", false);
                animator.SetBool("IsThrowing", true);
                yield return new WaitForSeconds(0.5f);
                camera.fieldOfView = 60;
                animator.SetBool("IsThrowing", false);
                ballThrowingForce = 0f;
                isPushingBasketball = false;
            }
        }
    }

    IEnumerator Click()
    {
        animator.SetFloat("Speed", 0);
        animator.SetBool("IsJumping", false);
        isClicking = true;
        yield return new WaitForSeconds(0.02f);
        for (int i = 0; i < 20; i++)
        {
            animator.SetFloat("Speed", 0);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsClicking", true);
            isClicking = false;
            yield return new WaitForSeconds(0.001f);
        }
        isClicking = true;
    }

    IEnumerator ClickWithWalk()
    {
        animator.SetFloat("Speed", 0);
        animator.SetBool("IsJumping", false);
        isClicking = true;
        yield return new WaitForSeconds(0.02f);
        for (int i = 0; i < 20; i++)
        {
            animator.SetFloat("Speed", 0);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsClickingWithWalk", true);
            isClicking = false;
            yield return new WaitForSeconds(0.001f);
        }
        isClicking = true;
    }

    public void ThrowingBasketBall()
    {
        isPushingBasketball = true;
    }
}
