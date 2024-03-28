using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    private DoorMech doorMech = new DoorMech();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
            }
        }
    }
}
