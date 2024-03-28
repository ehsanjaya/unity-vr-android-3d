using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    public Image healthBar;
    public NavMeshAgentControl navMeshAgentControl;
    public PlayerCharacterControl playerCharacterControl;
    public Color[] color;
    public int healthEnemy;
    public int healthPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (navMeshAgentControl != null)
            healthEnemy = navMeshAgentControl.currentHealth;
        if(playerCharacterControl != null)
            healthPlayer = playerCharacterControl.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgentControl != null)
            healthEnemy = navMeshAgentControl.currentHealth;
        if (playerCharacterControl != null)
            healthPlayer = playerCharacterControl.currentHealth;

        if (healthEnemy <= 100 && healthEnemy > 50 || healthPlayer <= 100 && healthPlayer > 50)
            healthBar.color = color[0];
        else if (healthEnemy <= 50 && healthEnemy > 20 || healthPlayer <= 50 && healthPlayer > 20)
            healthBar.color = color[1];
        else if (healthEnemy <= 20 || healthPlayer <= 20)
            healthBar.color = color[2];
    }

    public void UpdateHealth(float fraction)
    {
        healthBar.fillAmount = fraction;
    }
}
