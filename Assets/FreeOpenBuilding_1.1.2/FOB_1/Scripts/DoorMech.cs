using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMech : MonoBehaviour 
{
	public Vector3 OpenRotation, CloseRotation;
	AudioSource sound;
	public Slider sliderVolume;
	public AudioClip[] clips;
	float rotSpeed = 0.5f;
	public bool doorBool;

	void Start()
	{
		doorBool = false;
		sound = GetComponent<AudioSource>();
	}

	IEnumerator ChangeBool()
    {
		yield return new WaitForSeconds(1f);
		doorBool = !doorBool;
		if (doorBool == true)
		{
			sound.clip = clips[0];
			sound.Play();
			yield return new WaitForSeconds(2f);
			sound.clip = clips[1];
			sound.Play();
		}
		else
		{
			sound.clip = clips[1];
			sound.Play();
			yield return new WaitForSeconds(2f);
			sound.clip = clips[2];
			sound.Play();
		}
    }

    void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Bullet Hole") StartCoroutine(ChangeBool());
		if (collision.gameObject.tag == "Enemy") StartCoroutine(OpenCloseDoor());

	}

	IEnumerator OpenCloseDoor()
    {
		doorBool = true;
		yield return new WaitForSeconds(3f);
		doorBool = false;
	}

	void Update()
	{
		sound.volume = sliderVolume.value;

		if (doorBool)
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (OpenRotation), rotSpeed * Time.deltaTime);
		else
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (CloseRotation), rotSpeed * Time.deltaTime);	
	}

}

