using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movment;

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
        rb.MovePosition(rb.position + movment * MoveSpeed * Time.deltaTime);
    }
}
