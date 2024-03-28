using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    public NavMeshAgentControl navMeshAgentControl;
    public ScoreMoneyControl scoreMoneyControl;
    public NavMeshAgent navMeshAgent;
    public GunControl gunControl;
    public Slider sliderVolume;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgentControl.enabled = true;
        navMeshAgent.enabled = true;
        gunControl.enabled = true;
        sound = GetComponent<AudioSource>();
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.1f);
        navMeshAgentControl.enabled = true;
        navMeshAgent.enabled = true;
        gunControl.enabled = true;
        yield return new WaitUntil(() => IsDestroyObject() == true);
        sound.Play();
        navMeshAgentControl.enabled = false;
        navMeshAgent.enabled = false;
        gunControl.enabled = false;
        Destroy(this.gameObject, 10f);
    }
    private bool IsDestroyObject()
    {
        if (navMeshAgentControl.currentHealth < 1)
        {
            scoreMoneyControl.AddScore(100);
            return true;
        }
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = sliderVolume.value;
    }
}
