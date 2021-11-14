using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // changes this (camera) position to match car's position
    void LateUpdate()
    {
        float cameraDistance = transform.position.z;
        transform.position = thingToFollow.transform.position + new Vector3(0,0,cameraDistance);
    }
}
