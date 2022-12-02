using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mvt : MonoBehaviour
{
    private float moveSpeed;
    CharacterController ch;

    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        ch.Move(new Vector3(x, 0, z));
    }
}
