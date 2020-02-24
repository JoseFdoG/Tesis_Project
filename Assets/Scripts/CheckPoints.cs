using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] holes;
    public GameObject[] enemies;


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
            for (int i = 0; i < spawners.Length; i++)
            {
                if (collision.name == holes[i].name)
                {
                    transform.position = spawners[i].transform.position;
                    Debug.Log("Hole" + spawners[i]);
                }
            }
        }
        if (collision.tag == "Enemy")
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (collision.name == enemies[i].name)
                {
                    transform.position = spawners[i].transform.position;
                    Debug.Log("Enemy" + spawners[i]);
                }
            }
        }
    }
}
