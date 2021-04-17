using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eGameProjection
{
    orto,
    pers
};

public class CameraChange : MonoBehaviour
{
    Camera cam;
    PlayerMovement playerMov;

    public eGameProjection gameProjection = eGameProjection.orto;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        playerMov = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (cam.orthographic == false)
            {
                cam.orthographic = true;
                gameProjection = eGameProjection.orto;
                Vector3 trans = playerMov.GetComponent<Transform>().position;
                playerMov.GetComponent<Transform>().position = new Vector3(trans.x, trans.y, -3.82f);
            }
            else
            {
                cam.orthographic = false;
                gameProjection = eGameProjection.pers;
            } 
            
        }
    }
}