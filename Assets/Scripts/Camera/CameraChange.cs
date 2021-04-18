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
    internal Camera cam;
    PlayerMovement playerMov;
    public GameObject persObjects;
    public static bool canChange = true;

    public eGameProjection gameProjection = eGameProjection.orto;


    void Awake()
    {
        cam = GetComponent<Camera>();
        playerMov = FindObjectOfType<PlayerMovement>();

        persObjects.SetActive(false);
    }

    void Start()
    {
        if(gameProjection == eGameProjection.pers)
        {
            cam.orthographic = false;
            persObjects.SetActive(true);
        }
        else
        {
            cam.orthographic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && canChange)
        {
            if (cam.orthographic == false)
            {
                cam.orthographic = true;
                cam.nearClipPlane = -15f;
                gameProjection = eGameProjection.orto;
                persObjects.SetActive(false);

                Vector3 trans = playerMov.GetComponent<Transform>().position;
                playerMov.GetComponent<Transform>().position = new Vector3(trans.x, trans.y, -3.82f);
            }
            else
            {
                cam.orthographic = false;
                cam.nearClipPlane = 0.01f;
                gameProjection = eGameProjection.pers;
                persObjects.SetActive(true);
            } 
            
        }
    }
}
