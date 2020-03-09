using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class Distance_Calc : MonoBehaviour
{
    public Transform[] enemiesPos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(enemiesPos.Length);
        for (int i = 0; i < enemiesPos.Length; i++)
        {
            GlobalManage.Instance.distance_Enem[i] = 1000;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemiesPos.Length; i++)
        {
            float magnitude= Vector2.Distance(gameObject.transform.position, enemiesPos[i].position);

            if (GlobalManage.Instance.distance_Enem[i] > magnitude)
            {
                GlobalManage.Instance.distance_Enem[i] = magnitude;
            }
        }
    }
}
