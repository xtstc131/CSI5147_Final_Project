using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTrap : MonoBehaviour
{

    public Rigidbody[] Cylinder;
    // Start is called before the first frame update
    private bool isFinish;

    public Rigidbody Plate;
    private Transform trans;
    public float speed = 1f;
    private float dir = 1f;
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
        trans = Plate.transform;
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
            trans.position += Vector3.up * speed * Time.deltaTime * dir;
            // Plate.velocity = Vector3.up * speed;
            if (trans.position.y >= 2.8 || trans.position.y <= -2.8)
                dir = -dir;
        }
    }
}
