using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int healthPoints;
    private int maxHealthPoints = 100;

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
        this.gameObject.SetActive(false);
    }
}
