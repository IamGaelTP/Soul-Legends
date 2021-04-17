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

    public eGameProjection gameProjection = eGameProjection.orto;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
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
            }
            else
            {
                cam.orthographic = false;
                gameProjection = eGameProjection.pers;
            } 
            
        }
    }
}
