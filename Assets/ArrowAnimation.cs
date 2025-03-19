using System;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{   
    [SerializeField] float animationSpeed = 0.3f;

    Vector3 currRotation;
    float currX;
    float currY;
    float currZ;
    int direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currRotation = transform.rotation.eulerAngles;
        currY = transform.position.y;
        currZ = transform.position.z;
        currX = transform.position.x;
        Debug.Log(currX.ToString()+ currY.ToString()+ currZ.ToString() +currRotation.ToString());
    }  

    // Update is called once per frame
    void Update()
    {   
        if(currX <= -13.17f){ 
            direction = 1;
            }
        else if(currX >= -12.8507f){ 
            direction = -1;
            }
        
        currX += direction * animationSpeed;
        //Debug.Log(currX.ToString());
       transform.SetPositionAndRotation(new Vector3(currX, currY, currZ),Quaternion.Euler(currRotation));
    }
}

//Vector3(11135,68,-510)
//Vector3(11406,240,-688)

//-13.16533 -3.335123 -44.42489 (359.75, 28.84, 213.75)
//-12.8507 -3.095144 -44.59968(359.75, 28.84, 213.75)
