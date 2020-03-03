using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class SceneManager : MonoBehaviour
{
    private float[] distances_write;
    public GameObject player;
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
        if(collision.tag=="Gate")
        {
            string data_dist="";
            for (int i = 0; i < GlobalManage.Instance.distance_Enem.Length; i++)
            {
                data_dist += GlobalManage.Instance.distance_Enem[i] + " ";
            }
            Debug.Log(data_dist);
            Debug.Log(Application.persistentDataPath);
            StartCoroutine(GlobalManage.Instance.GetDataManager().WriteFile_CSV("Data", "Jugador1" + " " + data_dist));

        }
    }
}
