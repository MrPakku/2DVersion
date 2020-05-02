using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Levelloader level;

    public Transform Player;
    

    public float speed;
    public float ChallangeDistance;
    public float ChaseDistance;

    public float StartwaitTime;
    private float waitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Vector2 Spot;

    public bool spotted;
    private void Start()
    {
        waitTime = StartwaitTime;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Spot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        

    }
    private void Update()
    {
        
        if (Vector2.Distance(transform.position, Player.position) <= ChaseDistance)
        {
            if (Vector2.Distance(transform.position, Player.position) <= ChallangeDistance)
            {
                //StartCoroutine(LoadLevel());
                level.BattleHUD();
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Spot, speed * Time.deltaTime);


            if (Vector2.Distance(transform.position, Spot) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    Spot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = StartwaitTime;

                }
                else { waitTime -= Time.deltaTime; }
            }

        }
    }

    IEnumerator LoadLevel()
    {
        level.BattleHUD();

        yield return new WaitForSeconds(level.transitionTime);

        Destroy(transform);
    }
}
