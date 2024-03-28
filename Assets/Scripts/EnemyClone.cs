using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClone : MonoBehaviour
{
    public GameObject enemy;
    public int countClone;
    public int yFloor;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        if (yFloor == 1) y = 1.2f;
        else if (yFloor == 2) y = 5.1f;
        else if (yFloor == 3) y = 9f;
        else if (yFloor == 4) y = 12.9f;

        for (int i = 0; i < countClone - 1; i++)
        {
            Instantiate(enemy, new Vector3(transform.position.x, y, transform.position.z), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
