using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class SceneManager : MonoBehaviour
{
    private float[] distances_write;
    //public GameObject player;
    public GameObject final_enemy;
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
        if(collision.tag=="Gate" || collision.name==final_enemy.name)
        {
            for (int i = 0; i < GlobalManage.Instance.distance_Enem.Length; i++)
            {
                GlobalManage.Instance.GetDataManager().players.participant[GlobalManage.Instance.GetDataManager().players.participant.Count-1].performance[GlobalManage.Instance.speed-1].distances[i] = GlobalManage.Instance.distance_Enem[i];
                GlobalManage.Instance.distance_Enem[i] = 100f;
            }

            string json = JsonUtility.ToJson(GlobalManage.Instance.GetDataManager().players);

            StartCoroutine(GlobalManage.Instance.GetDataManager().WriteFile_CSV("Data", json));

            GlobalManage.Instance.speed += 1;
        }
    }
}
