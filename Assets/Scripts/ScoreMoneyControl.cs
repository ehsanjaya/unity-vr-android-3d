using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMoneyControl : MonoBehaviour
{
    public int Score;
    public Text textScoreMoney;
    public Text textAddScoreMoney;
    public GameObject addScoreMoney;
    public Animator canvasAnimator;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        addScoreMoney.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textScoreMoney.text = "$" + Score;
    }

    public void AddScore(int add)
    {
        sound.Play();
        Score += add;
        textAddScoreMoney.text = "+ $" + add;
        addScoreMoney.SetActive(true);
        canvasAnimator.SetTrigger("AddScore");
    }
}
