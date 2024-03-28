using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Image imageOn;
    public Image imageOff;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn == true)
        {
            imageOn.gameObject.SetActive(true);
            imageOff.gameObject.SetActive(false);
        }
        if (toggle.isOn == false)
        {
            imageOff.gameObject.SetActive(true);
            imageOn.gameObject.SetActive(false);
        }
    }
}
