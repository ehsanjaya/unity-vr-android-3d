using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerCharacterControl playerCharacterControl;
    public CharacterController characterController;
    public GunControl gunControl;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacterControl.enabled = true;
        characterController.enabled = true;
        gunControl.enabled = true;
        sound = GetComponent<AudioSource>();
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.1f);
        playerCharacterControl.enabled = true;
        characterController.enabled = true;
        gunControl.enabled = true;
        yield return new WaitUntil(() => IsDestroyObject() == true);
        sound.Play();
        playerCharacterControl.enabled = false;
        characterController.enabled = false;
        gunControl.enabled = false;
        Destroy(this.gameObject, 10f);
    }

    private bool IsDestroyObject()
    {
        if (playerCharacterControl.currentHealth < 1)
            return true;
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
