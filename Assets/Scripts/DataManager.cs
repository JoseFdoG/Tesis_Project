using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
}
