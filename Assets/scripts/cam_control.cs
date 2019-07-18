using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_control : MonoBehaviour
{
    public Transform sledz;
    public Vector3 przesuniecie=new Vector3(15,10,-20);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(sledz);
        if (transform.position.y >= 2)
        {
            transform.position = sledz.position + przesuniecie;
        }
    }
}
