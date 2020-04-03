using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTrap : MonoBehaviour
{

    public Rigidbody[] Cylinder;
    // Start is called before the first frame update
    private bool isFinish;

    public Rigidbody Plate;
    public float speed = 2f;
    private bool SpeedEnough

    {
        get
        {
            for (int i = 0; i < Cylinder.Length; ++i)
            {
                if (Cylinder[i].angularVelocity.y > 5)
                    return true;
            }
            return false;
        }
    }

    public GameObject Land;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedEnough && !isFinish)
        {
            isFinish = true;
            for (int i = 0; i < Cylinder.Length; ++i)
            {
                Cylinder[i].gameObject.SetActive(false);
            }
            Land.SetActive(true);
            Plate.isKinematic = false;

        }
        if (isFinish)
        {
            Plate.velocity = Vector3.up * speed;
        }
    }
}
