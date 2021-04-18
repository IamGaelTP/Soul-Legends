using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    internal int healthPoints;
    internal int maxHealthPoints = 200;

    public PlayerSpawn spawn;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
    }
    
    public int TakeDamage(int damageRecieved)
    {
        return healthPoints - damageRecieved;
    }

    public bool isAlive()
    {
        return healthPoints <= 0;
    }

    public void Death()
    {
        //Play Audio
        AudioManager.instance.Play("Death");
        this.gameObject.SetActive(false);

        //Revive
        spawn.Revive();
    }
}
