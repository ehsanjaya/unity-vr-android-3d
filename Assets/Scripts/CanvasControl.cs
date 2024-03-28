using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    public GameObject addScoreMoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideAddScoreMoney()
    {
        addScoreMoney.SetActive(false);
    }
}
