using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Chase Player
    private Rigidbody2D rb;

    public Transform Player;
    public float moveSpeed = 5f;

    public RaycastHit2D hitinfo;
    

    private Vector2 movment;

    //Detection Variablem
    public float distance;

    
    private void Start()
    {

        //Chase Player
        rb = this.GetComponent<Rigidbody2D>();

        //enemy detaction
        Physics2D.queriesStartInColliders = false;

    }
    private void Update()
    {
        
        //enemy detaction
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitinfo.collider.CompareTag("Player"))
        {
            bool inRange = false;
            moveSpeed = 2;

            while (!inRange)
            {
                if (Vector2.Distance(Player.position, Player.position) <= 1.25)
                {
                    
                    inRange = true;
                }
                else
                {
                    ChasePalyer();
                    moveSpeed++;
                }
            }
        }
        else
        {
            
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }
    }

    public void ChasePalyer()
    {

        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movment = direction;
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
