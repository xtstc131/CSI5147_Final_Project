using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float fallZone = -10f;
    public Vector3 playerSpawnPoint = new Vector3(-1, 3, -33); //create an empty gameobject and assign it to this script  in the inspector   
    Vector3 _InitialPos = new Vector3(-1, 3, -33);
    // Start is called before the first frame update
    private Rigidbody rigid;
    public float Force = 5f;
    private Vector3 dir;

    private bool brake;

    private int spin;
    public int Torque = 10;

    public Button buttonQuit;

    public GameObject Fire;

    private bool isWin = false;

    void Start()
    {
        // var particleSystem = Fire.GetComponent<ParticleSystem>();
        // var em = particleSystem.emission;
        // em.enabled = false;
        // particleSystem.Stop();
        rigid = this.GetComponent<Rigidbody>();
        var leave = buttonQuit.GetComponent<Button>();
        leave.onClick.AddListener(endGame);
    }


    // Update is called once per frame

    void Update()
    {
        if (this.transform.position.y < fallZone && !isWin) //Assuming its a 2D game
        {
            if (playerSpawnPoint != null)
                this.transform.position = playerSpawnPoint;
            else
                this.transform.position = _InitialPos;
            rigid.velocity = new Vector3(0, 0, 0);
        }
        dir = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        brake = Input.GetKey(KeyCode.Space);
        if (Input.GetKey(KeyCode.Q))
        {
            spin = -1;
        }
        else if (Input.GetKey(KeyCode.E))
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

    public void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isWin = true;
            // var particleSystem = Fire.GetComponent<ParticleSystem>();
            // var em = particleSystem.emission;
            // em.enabled = true;
            // particleSystem.Play();
            foreach (Transform child in other.transform.parent)
            {
                child.GetComponent<Rigidbody>().AddExplosionForce(400, other.contacts[0].point, 5, 3, ForceMode.Impulse);
            }
        }
    }
}
