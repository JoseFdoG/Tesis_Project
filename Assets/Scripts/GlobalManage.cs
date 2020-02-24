using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class GlobalManage : MonoBehaviour
    {
        public static GlobalManage Instance { get; private set;}

        [SerializeField]
        private float m_speed;

        public float speed { get { return m_speed; } set { m_speed = value; } }

        private void Awake()
        {
            if(Instance==null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
