using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float time;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetButton("RotateY+"))
        {
             transform.RotateAround(target.position, Vector3.up, 90 * Time.deltaTime);      
        }
        if (Input.GetButton("RotateY-"))
        {
            transform.RotateAround(target.position, Vector3.up, -90 * Time.deltaTime);
        }



    }
}
