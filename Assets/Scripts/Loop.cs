using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class Loop : MonoBehaviour
{
    public Transform begin;
    public Enemy_Move enem;
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
            transform.position = new Vector3(begin.position.x,begin.position.y,0);
        }
    }
}
