using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform Player;

    public float speed;
    public float distance;
    public float radius;

    public float StartwaitTime;
    private float waitTime;
    public float MoveSpeed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform Enemy;
    public Transform Spot;

    private void Start()
    {
        waitTime = StartwaitTime;

        Spot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {
        
        //enemy detaction
        RaycastHit2D hitinfo = Physics2D.CircleCast(Enemy.position, radius, Enemy.position, distance);
        Debug.Log(hitinfo.collider.CompareTag("Player"));
        
        if (hitinfo.collider.CompareTag("Player"))
        {

            Enemy.position = Vector2.MoveTowards(Enemy.position, Player.position, speed * Time.deltaTime);

            
          
            if (Vector2.Distance(Enemy.position, Player.position) <= 1)
            {
                Destroy(hitinfo.collider.gameObject);
            }
            else
            {
                Enemy.position = Vector2.MoveTowards(Enemy.position, Player.position, speed * Time.deltaTime);

            }
            
        }
        else if (!hitinfo.collider.CompareTag("Player"))
        {
            Enemy.position = Vector2.MoveTowards(Enemy.position, Spot.position, MoveSpeed * Time.deltaTime);


            if (Vector2.Distance(Enemy.position, Spot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    Spot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = StartwaitTime;

                }
                else { waitTime -= Time.deltaTime; }
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(Enemy.position, Enemy.position, radius);
    }
}
