using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("ArmHit"))
        {
            Destroy(this.gameObject);
        }
    }
}
