using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CameraTrace : MonoBehaviour
{

    private Transform trans;

    public Transform Target;

    public Vector3 dis =  new Vector3(0,2,-5);
    // Start is called before the first frame update
    void Start()
    {
         trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = Target.position + dis;
        trans.LookAt(Target);
    }
}
