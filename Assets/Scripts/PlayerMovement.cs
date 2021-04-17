using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    CameraChange cameraChange;

    Vector3 movement;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        cameraChange = FindObjectOfType<CameraChange>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
        if(cameraChange.gameProjection == eGameProjection.pers)
        {
            MoveZ();
        }
    }

    void MoveX()
    {
        //Move
        float inputX = Input.GetAxis("Horizontal");
        movement = new Vector3(inputX * speed, 0,0);
        movement *= Time.deltaTime;

        //Translate
        transform.Translate(movement);
    }

    void MoveZ()
    {
        //Move
        float inputZ = Input.GetAxis("Vertical");
        movement = new Vector3(0, 0, inputZ * speed);
        movement *= Time.deltaTime;

        //Translate
        transform.Translate(movement);
    }


}
