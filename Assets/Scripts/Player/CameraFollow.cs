using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerPostion;

    public float SmoothSpeed = 0.125f;
    public Vector3 Offset;

    private void LateUpdate()
    {
        transform.position = PlayerPostion.position + Offset;
    }
}
