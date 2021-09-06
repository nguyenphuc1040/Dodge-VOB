using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Follower;
    public void _GetPlayer(GameObject x){
        Follower = x;
    }
    void FixedUpdate()
    {
        if (Follower!=null) _CameraFollow();
    }
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;

    public void _CameraFollow(){
      
        Vector3 targetPosition = Follower.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}