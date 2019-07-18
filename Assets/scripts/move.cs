using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float speed=5f;
    public Canvas dead;
    public Canvas pause;

    float obrot = 2;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
            if (Input.GetKey("left")||Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(Vector3.forward * obrot);
                rb.AddForce(Vector3.left * speed);
            }
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(Vector3.back * obrot);
                rb.AddForce(Vector3.right * speed);
            }
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                rb.AddTorque(Vector3.right * obrot);
                rb.AddForce(Vector3.forward * speed);
            }
            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                rb.AddTorque(Vector3.left * obrot);
                rb.AddForce(Vector3.back * speed);
            }
            if (Input.GetKey(KeyCode.P))
            {
                pause.gameObject.SetActive(true);
            }
        

        if (rb.transform.position.y < -3)
        {
            Invoke("Reset", 0.5f);
        }
        speed += Time.deltaTime/10f;
    }
    private void Reset()
    {
        dead.gameObject.SetActive(true);
    }
}
