using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CheckPoints : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] holes;
    public GameObject[] enemySpawn;
    public GameObject[] enemies;

    public float timer=3;
    private bool activationT=false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hole")
        {
            GlobalManage.Instance.timer_flag = false;
            for (int i = 0; i < spawners.Length; i++)
            {
                if (collision.name == holes[i].name)
                {
                    transform.position = spawners[i].transform.position;
                }
            }
        }
        if (collision.tag == "Enemy")
        {
            GlobalManage.Instance.timer_flag = false;
            for (int i = 0; i < enemySpawn.Length; i++)
            {
                if (collision.name == enemies[i].name)
                {
                    transform.position = enemySpawn[i].transform.position;
                }
            }
        }
    }
}
