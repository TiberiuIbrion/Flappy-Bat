using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Script : MonoBehaviour
{
    public Transform subject;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void LateUpdate()
    {
        transform.position = subject.position + offset;
    }
}
