using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTrans;
    CameraChange cameraChange;
    public PlayerMovement playerMov;

    public Vector3 _cameraOffset;
    public Vector3 otherOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    [Range(1f, 10f)]
    public float otherSmoothFactor = 3.0f;

    public bool lookAtPlayer = false;

    void Awake()
    {
        cameraChange = FindObjectOfType<CameraChange>();
        playerMov = FindObjectOfType<PlayerMovement>();
    }


    void Start()
    {
        _cameraOffset = transform.position - playerTrans.position;
        _cameraOffset.x = 1;
    }

    void LateUpdate()
    {
        if (cameraChange.gameProjection == eGameProjection.pers)
            FollowOn3D();
        else 
            FollowOn2D();
    }

    void FollowOn3D()
    {
        Vector3 newPos = playerTrans.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (lookAtPlayer)
        {
            transform.LookAt(playerTrans);
        }
    }

    void FollowOn2D()
    {
        Vector3 playerPosition = playerTrans.position + otherOffset;
       
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, otherSmoothFactor * Time.fixedDeltaTime);
        transform.position = playerPosition;
    }

}
