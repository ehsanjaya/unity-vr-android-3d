using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{
    public GameObject bulletHole;
    public GameObject bullet;
    AudioSource sound;
    public Slider sliderVolume;
    public bool isFollowingTarget;
    public bool isShootingTarget;
    public bool isKilling;
    public Transform target;
    public Transform bulletSpawnPoint;
    public float speedTurn;
    public float speedMove;
    private Quaternion rotationGoal;
    private Vector3 direction;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isShootingTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = sliderVolume.value;
        if (isKilling == true && isFollowingTarget == true)
            TargetRotation();
        if(isKilling == false)
        {
            StartCoroutine(ProcessShot());
        }
    }

    void FixedUpdate()
    {
        if (isShootingTarget == true)
        {
            if (timer > 0.5f)
            {
                sound.Play();
                var bulletClone = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                bulletClone.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * 5f;
                timer = 0f;
            }
            else timer+=1 * Time.deltaTime;
        }
    }

    IEnumerator ProcessShot()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray , out hit, float.PositiveInfinity))
            {
                sound.Play();
                yield return new WaitForSeconds(0.01f);
                Instantiate(bulletHole, hit.point + (hit.normal * 0.01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }

    void TargetRotation()
    {
        direction = (target.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, speedTurn);
    }

    void PositionAndRotation()
    {
        transform.position = Vector3.Slerp(transform.position, target.position, speedMove);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speedTurn);
    }
}
