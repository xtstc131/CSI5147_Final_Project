using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigid;

    public float Force = 5f;
    private Vector3 dir;

    private bool brake;

    private int spin;
    public int Torque = 10;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }


    // Update is called once per frame

    void Update()
    {
        dir = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        brake = Input.GetKey(KeyCode.Space);
        if(Input.GetKey(KeyCode.Q))
        {
            spin = -1;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            spin = 1;
        }
        else
        {
            spin = 0;
        }
    }

    void FixedUpdate()
    {
        if (!brake)
        {
            rigid.AddForce(dir * Force, ForceMode.Force);
            rigid.AddTorque(Vector3.up * spin * Torque);
        }
        else
        {
            rigid.velocity = Vector3.Lerp(rigid.velocity, new Vector3(0, rigid.velocity.y, 0), 0.2f);
        }
    }
}
