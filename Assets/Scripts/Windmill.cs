using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    private Rigidbody rigid;

    public float speed = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigid.angularVelocity = Vector3.up * speed;
    }
}
