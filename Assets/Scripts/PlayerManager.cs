using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // charactoer  controller
    CharacterController characterController;

    public GameManager gameManager;
    public SoundEffectManager soundEffectManager;

    Vector3 moveDirection = new Vector3(0, 0, 0);

    public float gravity = 0.002f;
    public float JumpPower = 0.1f;
    public float Speed = 0.03f;

    // animator components
    Animator animator;

    // Start is called before the first frame update 
    void Start() 
    { 
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        // when tap display 
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        characterController.Move(moveDirection);

        // add gravity 
        moveDirection.y -= gravity;
    }

    private bool IsStun()
    {
        return Speed <= 0;
    }

    // player jump
    void Jump() 
    {
        if  (IsStun()) {
            return;
        }
        moveDirection.y = JumpPower;

        // sound jump
        soundEffectManager.MakeJumpSound();
    }
     
    void Walk()
    {
        // animation
        animator.SetBool("walk", moveDirection.z > 0);
        moveDirection.z = Speed;
    }

    void Stun() 
    {
        animator.SetTrigger("stun");
        Speed = 0;
        // sound stun
        soundEffectManager.MakeStunSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            gameManager.AddScore();
            Destroy(other.gameObject);
            // sound item
            soundEffectManager.MakeItemSound(); 
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Trap")
        {
            Stun();
            gameManager.DisplayGameOverCanvas();
        }
    } 
}
