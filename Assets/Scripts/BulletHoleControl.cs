using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleControl : MonoBehaviour
{
    AudioSource sound;
    public AudioClip[] clips;
    public GameObject findObject;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Iron"))
        {
            Destroy(this.gameObject, 4f);
            sound.clip = clips[1];
            sound.Play();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Brick"))
        {
            Destroy(this.gameObject, 4f);
            sound.clip = clips[0];
            sound.Play();
        }

        if (collision.gameObject.name == "Dirt")
        {
            Destroy(this.gameObject, 4f);
            sound.clip = clips[2];
            sound.Play();
        }

        if (collision.gameObject.tag == "Enemy" ||
            collision.gameObject.name == "Floors")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 4f);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Wood"))
        {
            Destroy(this.gameObject, 4f);
            var randomSoundWood = Random.Range(3, 4);
            sound.clip = clips[randomSoundWood];
            sound.Play();
        }

        findObject = GameObject.Find(collision.gameObject.name);
        transform.parent = findObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
