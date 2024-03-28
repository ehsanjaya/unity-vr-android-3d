using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    public GameObject cameraContainer;
    private Quaternion rot;
    public float speedTurn;

    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = EnableGyro();    
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, gyro.attitude * rot, speedTurn);
        }
    }

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }

        return false;
    }
}
