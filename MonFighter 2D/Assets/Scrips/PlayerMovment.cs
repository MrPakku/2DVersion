using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RunSpeed = 8f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movment;
    Vector2 position;

    void Start()
    {
        PlayerData data = SavingSystem.LoadPlayer();

        position.x = data.position[0];
        position.y = data.position[1];

        rb.position = position;
    }
    void Update()
    {
        movment.y = Input.GetAxisRaw("Vertical");
        movment.x = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", movment.x);
        animator.SetFloat("Vertical", movment.y);
        animator.SetFloat("Speed", movment.sqrMagnitude);


    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + movment * RunSpeed * Time.deltaTime);
        }
        else
        { 
            rb.MovePosition(rb.position + movment * MoveSpeed * Time.deltaTime);
        }
    }
}
