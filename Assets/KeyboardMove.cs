using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour, IMover
{
    float IMover.DirectionX => moveDirection.x;
    public float speed = 3;
    public Vector3 moveDirection;
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) moveDirection.z = 1;
        if (Input.GetKey(KeyCode.S)) moveDirection.z = -1;
        if (Input.GetKey(KeyCode.D)) moveDirection.x = 1;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1;


        if (moveDirection.sqrMagnitude > 0)
        {
            moveDirection.Normalize();
            transform.Translate(
                moveDirection * Time.deltaTime * speed);
        }

        //animator.SetBool("move", moveDirection.sqrMagnitude > 0);
    }
}
