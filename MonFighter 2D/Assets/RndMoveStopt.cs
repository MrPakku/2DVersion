using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RndMoveStopt : MonoBehaviour
{

    public Transform moveSpot;
    
    Vector3 newSpot;

    private float SpotX;
    private float SpotY;
    private float SpotZ;

    public float StartwaitTime;
    private float waitTime;
    

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    bool moved = false;

    private void Start()
    {
        waitTime = StartwaitTime;

        SpotX = Random.Range(minX, maxX);
        SpotY = Random.Range(minY, maxY);
        SpotZ = moveSpot.position.z;

        newSpot.x = SpotX;
        newSpot.y = SpotY;

        //moveSpot.position = newSpot;
    }

    public void Update()
    {
        moved = false;

        while (!moved)
        {
            if(moveSpot.position == newSpot)
            {
                newSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                moved = true;
            }
            else
            {
                StartCoroutine(move());
            }
        }
    }

    IEnumerator move()
    {
        moveSpot.position = newSpot;
        yield return new WaitForSeconds(waitTime);
        moved = false;
    }
}

