using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Global;

public class Enemy_Move : MonoBehaviour
{
    public int speed;
    public float length;
    public float divider;
    public Transform[] moveSpots; //Just Valid for the  move n7
    private float waitTime;
    public float startWaitTime;
    private int randomSpot; //Just Valid for the  move n7
    private float counter;
    private Vector2 startPosition;

    private Vector2 actualPosition;
    private Vector2 lastPosition;

    public string type;

    private float distance2Points;

    // Start is called before the first frame update
    void Start()
    {
        Random.seed = 42;
        startPosition = transform.position;
        randomSpot = Random.Range(0, moveSpots.Length);

        distance2Points = Vector2.Distance(startPosition, startPosition - new Vector2(2,2));
    }

    // Update is called once per frame
    void Update()
    {
        speed = GlobalManage.Instance.speed;
        counter += Time.deltaTime * speed;
        if (type == "Enemy1") move1();
        if (type == "Enemy2") move2();
        if (type == "Enemy3") move3();
        if (type == "Enemy4") move4();
        if (type == "Enemy5") move5();
        if (type == "Enemy6") move6();
        if (type == "Enemy7") move7();

        actualPosition = transform.position;
        if (actualPosition.x <= lastPosition.x) transform.localScale = new Vector2(3.15f, 3.15f);
        if (actualPosition.x > lastPosition.x) transform.localScale = new Vector2(-3.15f, 3.15f);
        lastPosition = transform.position;
    }

    private void move1()
    {
        transform.position = new Vector2(transform.position.x, Mathf.PingPong(counter, length) + startPosition.y);
        actualPosition = transform.position;
    }

    private void move2()
    {
        transform.position = new Vector2(Mathf.PingPong(counter, length) + startPosition.x, transform.position.y);
    }

    private void move3()
    {
        float ultimatePos = counter / distance2Points;
        transform.position = Vector2.Lerp(startPosition, startPosition - new Vector2(2, -2),Mathf.PingPong(ultimatePos,1));
    }

    private void move4()
    {
        float ultimatePos = counter / distance2Points;
        transform.position = Vector2.Lerp(startPosition, startPosition - new Vector2(-2, -2), Mathf.PingPong(ultimatePos, 1));
    }

    private void move5()
    {
        float x = Mathf.Sin(counter);
        float y = Mathf.Cos(counter);
        transform.position = new Vector2(x+startPosition.x,y+startPosition.y);
    }

    private void move6()
    {
        transform.position = new Vector2(Mathf.PingPong(counter, length) + startPosition.x, Mathf.PingPong(counter, length/divider) + startPosition.y);
    }

    private void move7()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed *Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position)<0.2f)
        {
            if(waitTime <=0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
