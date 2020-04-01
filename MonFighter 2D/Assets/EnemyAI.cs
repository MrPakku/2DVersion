using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Movement Variablen
    private Rigidbody2D rb;

    public Transform moveSpot;
    public Transform Player;
    public float moveSpeed = 5f;

    private Vector2 movment;

    //Detection Variablem
    public float distance;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();


    }
    private void Update()
    {
        //Enemy Movement
        Vector3 direction = moveSpot.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        direction.Normalize();
        movment = direction;

        //enemy detaction
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitinfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitinfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }
    }

    private void FixedUpdate()
    {
        moveEnemy(movment);
    }

    void moveEnemy (Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
