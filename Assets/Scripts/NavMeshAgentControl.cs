using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavMeshAgentControl : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int farDistance;
    public Transform wayPoint;
    public HealthBarControl healthBarControl;
    public AudioSource sound;
    public Slider sliderVolume;
    public Transform player;
    public bool isAssignToClone;
    Rigidbody rb;
    NavMeshAgent agent;
    public bool walkPointSet;
    public bool isFollowingTarget;
    public bool isStop;
    public float rangeX, rangeZ;
    [SerializeField] int startY, endY;
    int yRandom;
    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        walkPointSet = false;
        isStop = false;
        isFollowingTarget = false;
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Door") StartCoroutine(WaitDoor());
        if (collision.gameObject.tag == "Way Point") walkPointSet = false;
        if (collision.gameObject.tag == "Bullet Hole")
        {
            TakeDamage(7);
            sound.Play();
        }
    }

    IEnumerator WaitDoor()
    {
        isStop = true;
        yield return new WaitForSeconds(3.5f);
        isStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = sliderVolume.value;

        healthBarControl.UpdateHealth((float)currentHealth / (float)maxHealth);

        if (isStop == false)
        {
            if (!walkPointSet) SearchForDest();
            if (walkPointSet && isFollowingTarget == false) agent.SetDestination(wayPoint.position);
            if (walkPointSet && isFollowingTarget == true) agent.SetDestination(new Vector3(player.position.x - farDistance, player.position.y, player.position.z - farDistance));
        }
    }

    void SearchForDest()
    {
        walkPointSet = false;
        x = Random.Range(-rangeX, rangeX);
        yRandom = Random.Range(startY, endY);
        z = Random.Range(-rangeZ, rangeZ);

        // Get y position
        if (yRandom == 1) y = 1.2f;
        else if (yRandom == 2) y = 5.1f;
        else if (yRandom == 3) y = 9f;
        else if (yRandom == 4) y = 12.9f;

        wayPoint.localPosition = new Vector3(x, y, z);
        walkPointSet = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarControl.UpdateHealth((float)currentHealth / (float)maxHealth);
    }
}
