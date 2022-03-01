using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public float playerSpeed;
    //private Vector3 movePlayer;
    public float gravity = 9.8f;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        player = GetComponent<CharacterController>();   
    }
   
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(-horizontalMove, 0, -verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        //camDirection();
        
        //movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + playerInput);

        setGravity();

        player.Move(playerInput * playerSpeed * Time.deltaTime);

    }

    /*void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camForward = camRight.normalized;
    }*/

    void setGravity()
    {
        playerInput.y = -gravity * Time.deltaTime;
    }

    
}
