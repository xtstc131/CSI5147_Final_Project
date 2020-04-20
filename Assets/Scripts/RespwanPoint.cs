using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespwanPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Offset = new Vector3(0, 2, 0);
    // private Transform newTransform
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<BallController>().playerSpawnPoint = this.transform.position + Offset;
    }
}
