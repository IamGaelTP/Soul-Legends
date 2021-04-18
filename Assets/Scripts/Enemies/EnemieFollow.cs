using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieFollow : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public GameObject target;
    float timer;
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 10.0f)
        {
            navMeshAgent.destination = target.transform.position;
            this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        
    }
}
