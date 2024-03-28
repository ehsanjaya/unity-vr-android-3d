using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterControl : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider sliderVolume;
    public HealthBarControl healthBarControl;
    public AudioSource sound;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(5);
            sound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = sliderVolume.value;

        healthBarControl.UpdateHealth((float)currentHealth / (float)maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarControl.UpdateHealth((float)currentHealth / (float)maxHealth);
    }
}
