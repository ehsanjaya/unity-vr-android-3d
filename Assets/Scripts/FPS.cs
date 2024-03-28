using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class FPS : MonoBehaviour
{
    public Text text;
    public float pollingTime;
    private float time;
    private int frameCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        frameCount += 1;
        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            text.text = "FPS: " + frameRate.ToString();
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
