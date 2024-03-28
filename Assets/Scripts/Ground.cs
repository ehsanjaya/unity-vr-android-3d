using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    public GameObject prefab;
    public float XLong;
    public float ZLong;
    // Start is called before the first frame update
    void Awake()
    {
        for (int z = 0; z < ZLong; z+=2)
        {
            for (int x = 0; x < XLong; x+=2)
            {
                Instantiate(prefab, new Vector3(x, 0f, z), Quaternion.identity);
                prefab.transform.SetParent(null);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
