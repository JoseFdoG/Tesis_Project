using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataManager : MonoBehaviour
{

    public IEnumerator WriteFile_CSV(string file_name, string data_)
    {
        string path = Application.persistentDataPath + "/" + file_name + ".json";
        data_ += '\n';
        //File.AppendAllText(path, data_);
        File.WriteAllText(path, data_);
        //Debug.Log(Application.persistentDataPath);
        yield return new WaitForSeconds(0.5f);

        Application.OpenURL(path);
    }

    public IEnumerator ReadFile_Json(string file_name)
    {
        string path = Application.persistentDataPath + "/" + file_name + ".json";

        string Data = File.ReadAllText(path);
        players = JsonUtility.FromJson<Players>(Data);

        //Debug.Log(players.participant[0].performance[0].distances);
        Debug.Log("Puto el que lo lea");
        yield return new WaitForSeconds(0.5f);
    }

    public Players players;

    private void Start()
    {

        players = new Players();
        players.participant.Add(new Player(players.participant.Count));

        for (int j = 0; j < 6; j++)
        {
            players.participant[players.participant.Count-1].performance.Add(new Performance());

            for (int d=0; d<18 ; d++)
            {
                players.participant[players.participant.Count-1].performance[j].distances.Add(0f);
            }
        }
    }

    [Serializable]
    public class Players
    {
        public List<Player> participant = new List<Player>();
    }

    [Serializable]
    public class Player
    {
        public int id;
        public List<Performance> performance = new List<Performance>();

        public Player(int aId)
        {
            id = aId;
        }
    }

    [Serializable]
    public class Performance
    {
        public List<float> distances = new List<float>();
    }

    private void Awake()
    {
        StartCoroutine(ReadFile_Json("Data"));
    }
}