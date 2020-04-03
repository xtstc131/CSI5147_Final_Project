using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespwanPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Offset = new Vector3(0,2,0);
    private  GameObject emptyGO;
    private Transform newTransform;
    void Start()
    {
        emptyGO = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        newTransform = emptyGO.transform;
        newTransform.position = this.transform.position;
        other.gameObject.GetComponent<BallController>().playerSpawnPoint= newTransform;
        other.gameObject.GetComponent<BallController>().playerSpawnPoint.position += Offset;
    }
}
