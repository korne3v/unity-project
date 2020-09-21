using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Entity entity;

    public float walkSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float runSpeed = 8.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public float fallDistance = 0;
    public float fallY = 0;

    void Update()
    {

        if (controller.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= Input.GetKey(KeyCode.LeftShift) ? walkSpeed / 3 : walkSpeed;

            if (fallDistance > 10)
            {
                int damage = (int)fallDistance;
                Debug.Log("You getting damage in " + damage);
                entity.damage(damage, Entity.DamageCause.FALL);
            }

            fallDistance = 0;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                fallDistance = -8;
            }

        }
        else {
            fallDistance += gravity * Time.deltaTime;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    public void setFallDistance(int value) {
        this.fallDistance = value;
    }

}
