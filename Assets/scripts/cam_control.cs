using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_control : MonoBehaviour
{
    public Transform sledz;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(sledz);
        if (transform.position.y >= 4)
        {
            transform.position = sledz.position + new Vector3(8, 5, -10);
        }
        else
        {
            transform.position = sledz.position + new Vector3(8, 5, -10);
        }
    }
}
