using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorBehavior : MonoBehaviour
{

    bool doorTriggerToOpen = false;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerInput playerInput = collider.GetComponent<PlayerInput>();
        if (playerInput)
        {
            doorTriggerToOpen = true;
            animator.SetBool("triggerOpen", doorTriggerToOpen);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        PlayerInput playerInput = collider.GetComponent<PlayerInput>();
        if (playerInput)
        {
            doorTriggerToOpen = false;
            animator.SetBool("triggerOpen", doorTriggerToOpen);
        }
    }
}
