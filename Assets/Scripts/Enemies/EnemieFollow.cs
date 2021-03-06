using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieFollow : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer render;
    public NavMeshAgent navMeshAgent;
    public GameObject target;
    float timer;
    public float timetoWait = 10.0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timetoWait)
        {
            navMeshAgent.destination = target.transform.position;
            this.gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

            if(this.gameObject.transform.position.x > 0)
            {
                render.flipX = false;

            }
            else if (this.gameObject.transform.position.x < 0)
            {
                render.flipX = true;

            }

            //Play Animation
            anim.SetBool("isRunning", true);
        }
        
    }
}
