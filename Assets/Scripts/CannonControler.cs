using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControler : MonoBehaviour
{

    private Transform trans;
    private Transform CannonBall;

    public Transform LaunchPoint;
    // Start is called before the first frame update

    public float speed = 4f;
    public float Force = -10f;
    void Start()
    {
        trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CannonBall != null)
        {
            trans.Rotate(Vector3.right * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.F))
            {
                CannonBall.position = LaunchPoint.position;
                CannonBall.gameObject.SetActive(true);
                CannonBall.GetComponent<BallController>().enabled = true;
                CannonBall.GetComponent<Rigidbody>().AddForce(Force * LaunchPoint.forward, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
            CannonBall = other.transform;
            CannonBall.GetComponent<BallController>().enabled = false;
            CannonBall.gameObject.SetActive(false);
            CannonBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            CannonBall.position = this.transform.position;

        }


    }
}
