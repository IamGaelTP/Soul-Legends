using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    private PlayerHealth health;

    void Awake()
    {
        health = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        health.gameObject.transform.position = spawnPoint.position;
    }

    
    public void Revive()
    {
        this.gameObject.transform.position = spawnPoint.position;
        health.healthPoints = health.maxHealthPoints;
        this.gameObject.SetActive(true);
    }
}
