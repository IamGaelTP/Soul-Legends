using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
    }
}
