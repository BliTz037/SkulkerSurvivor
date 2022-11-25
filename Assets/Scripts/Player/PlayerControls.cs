using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController CharacterController;
    public Player Player;

    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        Player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        CharacterController.Move(move * Time.deltaTime * Player.Speed);
    }
}
