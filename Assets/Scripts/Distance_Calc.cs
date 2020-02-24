using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Calc : MonoBehaviour
{
    public Transform[] enemiesPos;
    public float[] distances;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(enemiesPos.Length);
        for (int i = 0; i < enemiesPos.Length; i++)
        {
            distances[i] = 1000;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemiesPos.Length; i++)
        {
            float magnitude= Vector2.Distance(gameObject.transform.position, enemiesPos[i].position);
            if (distances[i] > magnitude) distances[i] = magnitude;
        }
    }
}
