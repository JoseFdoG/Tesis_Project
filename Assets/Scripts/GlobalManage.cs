using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class GlobalManage : MonoBehaviour
    {
        public static GlobalManage Instance { get; private set;}

        [SerializeField]
        private int m_speed;
        [SerializeField]
        private bool m_timer_flag = true;
        [SerializeField]
        private float[] m_distances;



        public int speed { get { return m_speed; } set { m_speed = value; } }
        public bool timer_flag { get { return m_timer_flag; } set { m_timer_flag = value; } }
        public float [] distance_Enem { get { return m_distances; }set { m_distances = value; } }


        private DataManager dataManager; 

        private void Awake()
        {
            if(Instance==null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                dataManager = GetComponent<DataManager>();
            }
            else
            {
                Destroy(gameObject);
            }

        }

        public DataManager GetDataManager()
        {
            return dataManager;
        }
    }
}
