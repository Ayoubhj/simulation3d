using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followCamera;
   
    
    private Vector3 offset;
    

    // Start is called before the first frame update
    void  Start()
    {
        offset = followCamera.position - transform.position;
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (followCamera)
        {
          
            transform.position = followCamera.position - offset;
   
        }
    }
}
