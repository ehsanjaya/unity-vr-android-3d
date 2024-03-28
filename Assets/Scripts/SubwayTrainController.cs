using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayTrainController : MonoBehaviour
{
    public bool isEnabled = true;
    public Animator subwayTrainsAnimator;
    public GameObject subwayTrains;
    public AudioSource audio;
    public float timeComing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled == true)
        {
            isEnabled = false;
            StartCoroutine(WaitAnimation());
        }
    }

    IEnumerator WaitAnimation()
    {
        audio.enabled = true;
        audio.Play();
        audio.pitch = 1f;
        subwayTrainsAnimator.SetTrigger("Move");
        subwayTrains.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => AnimationMove() == true);
        subwayTrains.SetActive(false);
        yield return new WaitForSeconds(timeComing);
        subwayTrains.SetActive(true);
        isEnabled = true;
    }

    public bool AnimationMove() 
    {
        if (subwayTrains.transform.position.x == 350f)
            return true;
        else
            return false;
    }
}
