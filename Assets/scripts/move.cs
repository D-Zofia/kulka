using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public float speed=500f;
    public Canvas dead;
    public Canvas pause;

    
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
                rb.AddTorque(Vector3.forward * speed/20f*Time.deltaTime);
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(Vector3.back * speed / 20f * Time.deltaTime);
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
            {
                rb.AddTorque(Vector3.right * speed / 20f * Time.deltaTime);
                rb.AddForce(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
            {
                rb.AddTorque(Vector3.left * speed / 20f * Time.deltaTime);
                rb.AddForce(Vector3.back * speed * Time.deltaTime);
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
