using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private Transform trans;

    private Rigidbody rigid;


    private int dir = 1;
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        trans = this.transform;
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trans.position.x >= 2 && dir < 0)
           {
                dir = 1;
           }
        else if(trans.position.x <= -5 && dir > 0)
        {
            dir = -1;
        }
    }

    void FixedUpdate(){
        rigid.MovePosition(trans.position + trans.right* dir * speed * Time.fixedDeltaTime);
    }
}
